using AutoMapper;
using Bolao.Domain.Commands.Boloes;
using Bolao.Domain.Commands.Campeonatos;
using Bolao.Domain.Commands.Usuarios;
using Bolao.Domain.Entities.Boloes;
using Bolao.Domain.Entities.Campeonatos;
using Bolao.Domain.Entities.Usuarios;
using Bolao.Infrastructure.Interfaces.Repositories.Campeonatos;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.Boloes;
using Bolao.Service.Interfaces.Services.Campeonatos;
using Bolao.Service.Interfaces.Services.Importacoes;
using Bolao.Service.Interfaces.Services.Usuarios;
using Bolao.Service.Services.Importacoes.APIs;
using Core.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Importacoes
{
    public class ImportacaoService : IImportacaoService
    {
        private const int IdCampeonatoPadrao = 1;
        private const string TerminacaoEmailPadrao = "@elsys.com.br";
        private const string SenhaNovosUsuariosPadrao = "q1w2e3r4t5";
        private const string UrlImagemNovosUsuariosPadrao = "https://www.google.com";
        private const int IdBolaoPadrao = 1;

        private const string DiretorioImportacao = @"D:\ProjetosRodrigo\Bolao\01. documentos\Apostas Jogos";
        private readonly string DiretorioProcessados = $@"{DiretorioImportacao}\Processados";

        private readonly Copa2022Service _copa2022Service;
        private readonly ITimeRepository _timeRepository;
        private readonly ICampeonatoTimeRepository _campeonatoTimeRepository;
        private readonly ICampeonatoPartidaService _campeonatoPartidaService;
        private readonly IUsuarioService _usuarioService;
        private readonly IBolaoUsuarioService _bolaoUsuarioService;
        private readonly IBolaoPalpiteService _bolaoPalpiteService;
        private readonly IValidator<CreateTimeCommand> _createTimeCommandValidator;
        private readonly IMapper _mapper;

        public ImportacaoService(ITimeRepository timeRepository, ICampeonatoTimeRepository campeonatoTimeRepository, ICampeonatoPartidaService campeonatoPartidaService, IUsuarioService usuarioService, IBolaoUsuarioService bolaoUsuarioService, IBolaoPalpiteService bolaoPalpiteService, IValidator<CreateTimeCommand> createTimeCommandValidator, IMapper mapper)
        {
            _copa2022Service = new Copa2022Service();
            _timeRepository = timeRepository;
            _campeonatoTimeRepository = campeonatoTimeRepository;
            _campeonatoPartidaService = campeonatoPartidaService;
            _usuarioService = usuarioService;
            _bolaoUsuarioService = bolaoUsuarioService;
            _bolaoPalpiteService = bolaoPalpiteService;
            _createTimeCommandValidator = createTimeCommandValidator;
            _mapper = mapper;
        }

        public async Task<ICommandResult> ImportarCopa2022Async()
        {
            await ImportarTimesAsync();

            await ImportarPartidasAsync();

            // retornar o resultado
            return new CommandResult(true, "Importação da Copa 2022 concluída com sucesso.", /*result*/ null);
        }

        private async Task<bool> ImportarTimesAsync()
        {
            var lista = await _copa2022Service.GetTimesAsync();

            foreach (var item in lista)
            {
                var idAux = (int)item.id;
                var nome = (string)item.name_en;
                var sigla = (string)item.fifa_code;
                var urlImagem = (string)item.flag;

                var createCommand = new CreateTimeCommand()
                {
                    IdAux = idAux,
                    Nome = nome,
                    Sigla = sigla,
                    UrlImagem = urlImagem
                };

                // validação
                var validation = await _createTimeCommandValidator.ValidateAsync(createCommand);
                if (!validation.IsValid)
                {
                    //var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                    //return new CommandResult(false, "Não foi possível criar o Time.", new { Errors = mensagensDeErro });
                    return false;
                }

                // validação de duplicidade
                var entityExistente = await _timeRepository.GetByIdAuxAsync(createCommand.IdAux);
                if (entityExistente is not null)
                {
                    //return new CommandResult(false, "Código do Time já cadastrado.", entityExistente);
                    return false;
                }

                // criar a entidade
                var entity = _mapper.Map<Time>(createCommand);

                // salvar
                var result = await _timeRepository.CreateAsync(entity);
            }

            return true;
        }

        private async Task<bool> ImportarPartidasAsync()
        {
            var lista = await _copa2022Service.GetPartidasAsync();

            foreach (var item in lista)
            {
                var dtPartida = (DateTime)item.local_date;
                var idEstadio = (int)item.stadium_id;

                var idAux1 = (int)item.home_team_id;
                var time1 = await _timeRepository.GetByIdAuxAsync(idAux1);
                var campeonatoTime1 = await _campeonatoTimeRepository.GetByUniqueKeyAsync(IdCampeonatoPadrao, time1.IdTime);

                var idAux2 = (int)item.away_team_id;
                var time2 = await _timeRepository.GetByIdAuxAsync(idAux2);
                var campeonatoTime2 = await _campeonatoTimeRepository.GetByUniqueKeyAsync(IdCampeonatoPadrao, time2.IdTime);

                var createCommand = new CreateCampeonatoPartidaCommand()
                {
                    DtPartida = dtPartida,
                    IdEstadio = idEstadio,
                    IdCampeonatoTime1 = campeonatoTime1.IdCampeonatoTime,
                    IdCampeonatoTime2 = campeonatoTime2.IdCampeonatoTime,
                    Peso = 10  // o peso da partida deverá ser alterado posteriormente conforme os bolões sugerem
                };

                var result = await _campeonatoPartidaService.CreateAsync(createCommand);
            }

            return true;
        }

        public async Task<ICommandResult> ImportarPalpitesCopa2022Async()
        {
            await ImportarPalpitesAsync();

            // retornar o resultado
            return new CommandResult(true, "Importação dos Palpites da Copa 2022 concluída com sucesso.", /*result*/ null);
        }

        private async Task<bool> ImportarPalpitesAsync()
        {
            var arquivos = Directory.GetFiles(DiretorioImportacao);

            foreach (var arquivo in arquivos)
            {
                var result = await ImportarArquivoPalpiteAsync(arquivo);

                if (result)
                {
                    var arquivoProcessado = @$"{DiretorioProcessados}\{Path.GetFileName(arquivo)}";

                    Directory.Move(arquivo, arquivoProcessado);
                }
            }

            return true;
        }

        private async Task<bool> ImportarArquivoPalpiteAsync(string arquivo)
        {
            var placarInvertido = false;

            // localizar as siglas dos times conforme nome do arquivo
            var nomeArquivo = Path.GetFileName(arquivo);
            nomeArquivo = nomeArquivo.Replace(Path.GetExtension(nomeArquivo), "");
            var siglasTimes = nomeArquivo.Split("_");

            var time1 = await _timeRepository.GetBySiglaAsync(siglasTimes[0]);
            var campeonatoTime1 = await _campeonatoTimeRepository.GetByUniqueKeyAsync(IdCampeonatoPadrao, time1.IdTime);

            var time2 = await _timeRepository.GetBySiglaAsync(siglasTimes[1]);
            var campeonatoTime2 = await _campeonatoTimeRepository.GetByUniqueKeyAsync(IdCampeonatoPadrao, time2.IdTime);

            // buscar a partida do campeonato
            var campeonatoPartida = await _campeonatoPartidaService.GetByUniqueKeyAsync(campeonatoTime1.IdCampeonatoTime, campeonatoTime2.IdCampeonatoTime);
            if (campeonatoPartida is null)  // se não existir, buscar invertido
            {
                campeonatoPartida = await _campeonatoPartidaService.GetByUniqueKeyAsync(campeonatoTime2.IdCampeonatoTime, campeonatoTime1.IdCampeonatoTime);

                // inverter também os palpites
                placarInvertido = true;
            }

            var table = FileHelper.GetDataTableFromExcel(arquivo);

            table = CorrigirDados(table);

            foreach (DataRow row in table.Rows)
            {
                var nome = row["Nome"].ToString();

                var palpite = row["Palpite"].ToString();

                if (string.IsNullOrEmpty(palpite))
                    continue;

                var palpites = palpite.Split("X");
                var placarTime1 = Convert.ToInt32(palpites[0]);
                var placarTime2 = Convert.ToInt32(palpites[1]);
                if (placarInvertido)
                {
                    placarTime1 = Convert.ToInt32(palpites[1]);
                    placarTime2 = Convert.ToInt32(palpites[0]);
                }

                var email = row["Email"].ToString();
                email = TratarEmail(email);

                // buscar o usuário, ou criar caso necessário
                var usuario = await _usuarioService.GetByEmailAsync(email);
                if (usuario is null)  // se não existir, buscar por Nome + Email
                {
                    usuario = await _usuarioService.GetByNomeEmailAsync(nome, email);
                    if (usuario is null)  // se não existir, buscar por Nome
                    {
                        usuario = await _usuarioService.GetByNomeAsync(nome);
                        if (usuario is null)  // se não existir, inserir
                        {
                            var createUsuarioCommand = new CreateUsuarioCommand()
                            {
                                Nome = nome,
                                Email = email,
                                Senha = SenhaNovosUsuariosPadrao,
                                SenhaConfirmacao = SenhaNovosUsuariosPadrao,
                                UrlImagem = UrlImagemNovosUsuariosPadrao
                            };

                            var resultUsuario = await _usuarioService.CreateAsync(createUsuarioCommand);

                            // atualizar os dados do usuário inserido
                            usuario = await _usuarioService.GetByEmailAsync(email);

                            // necessário ainda inserir o usuário num bolão padrão
                            var createBolaoUsuarioCommand = new CreateBolaoUsuarioCommand()
                            {
                                IdBolao = IdBolaoPadrao,
                                IdUsuario = usuario.IdUsuario
                            };

                            var resultBolaoUsuario = await _bolaoUsuarioService.CreateAsync(createBolaoUsuarioCommand);
                        }
                    }
                }

                // buscar o bolão padrão do usuário
                var bolaoUsuario = await _bolaoUsuarioService.GetByUniqueKeyAsync(IdBolaoPadrao, usuario.IdUsuario);

                var createBolaoPalpiteCommand = new CreateBolaoPalpiteCommand()
                {
                    IdBolaoUsuario = bolaoUsuario.IdBolaoUsuario,
                    IdCampeonatoPartida = campeonatoPartida.IdCampeonatoPartida,
                    PlacarTime1 = placarTime1,
                    PlacarTime2 = placarTime2
                };

                var result = await _bolaoPalpiteService.SaveAsync(createBolaoPalpiteCommand);
            }

            return true;
        }

        private DataTable CorrigirDados(DataTable table)
        {
            // criando a coluna "Email" faltante, que, durante o processo de cópia da página web para o excel, acaba ficando na linha de baixo
            table.Columns.Add("Email");

            var i = 0;
            while (i < table.Rows.Count)
            {
                var row = table.Rows[i];

                var id = row["#"].ToString();

                if (!string.IsNullOrEmpty(id))
                {
                    i++;
                }
                else
                {
                    var email = row["Nome"].ToString();

                    var rowUpdate = table.Rows[i - 1];
                    rowUpdate["Email"] = email;

                    table.Rows.Remove(row);
                }
            }

            // percorrer todas as linhas e atualizar o "Email" com o "Nome" (nem todos os usuários possuem nome, mas o e-mail sempre é obrigatório)
            foreach (DataRow row in table.Rows)
            {
                if (string.IsNullOrEmpty(row["Email"].ToString()))
                    row["Email"] = row["Nome"];
            }

            return table;
        }

        private string TratarEmail(string email)
        {
            // se não existir, gerar um aleatório
            if (email == "...")
                email = $"{Guid.NewGuid()}{TerminacaoEmailPadrao}";

            // se não tiver provedor, gerar um padrão
            if (email.EndsWith("@..."))
                email = $"{email.Replace("@...", "")}{TerminacaoEmailPadrao}";

            return email;
        }
    }
}
