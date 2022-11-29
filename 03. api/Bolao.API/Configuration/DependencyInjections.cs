using Bolao.Domain.Commands.Boloes;
using Bolao.Domain.Commands.Campeonatos;
using Bolao.Domain.Commands.ClassesParceiros;
using Bolao.Domain.Commands.Produtos;
using Bolao.Domain.Commands.Propostas;
using Bolao.Domain.Commands.TabelasConfiguracoes;
using Bolao.Domain.Commands.Usuarios;
using Bolao.Domain.Configs;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.Interfaces.Repositories.Boloes;
using Bolao.Infrastructure.Interfaces.Repositories.Campeonatos;
using Bolao.Infrastructure.Interfaces.Repositories.ClassesParceiros;
using Bolao.Infrastructure.Interfaces.Repositories.MarcasEstruturas;
using Bolao.Infrastructure.Interfaces.Repositories.Produtos;
using Bolao.Infrastructure.Interfaces.Repositories.Propostas;
using Bolao.Infrastructure.Interfaces.Repositories.Regras;
using Bolao.Infrastructure.Interfaces.Repositories.TabelasConfiguracoes;
using Bolao.Infrastructure.Interfaces.Repositories.TiposFixacoes;
using Bolao.Infrastructure.Interfaces.Repositories.Usuarios;
using Bolao.Infrastructure.Repositories.Boloes;
using Bolao.Infrastructure.Repositories.Campeonatos;
using Bolao.Infrastructure.Repositories.ClassesParceiros;
using Bolao.Infrastructure.Repositories.MarcasEstruturas;
using Bolao.Infrastructure.Repositories.Produtos;
using Bolao.Infrastructure.Repositories.Propostas;
using Bolao.Infrastructure.Repositories.Regras;
using Bolao.Infrastructure.Repositories.TabelasConfiguracoes;
using Bolao.Infrastructure.Repositories.TiposFixacoes;
using Bolao.Infrastructure.Repositories.Usuarios;
using Bolao.Service.Interfaces.Services.Boloes;
using Bolao.Service.Interfaces.Services.Campeonatos;
using Bolao.Service.Interfaces.Services.ClassesParceiros;
using Bolao.Service.Interfaces.Services.Importacoes;
using Bolao.Service.Interfaces.Services.MarcasEstruturas;
using Bolao.Service.Interfaces.Services.Pontuacoes;
using Bolao.Service.Interfaces.Services.Produtos;
using Bolao.Service.Interfaces.Services.Propostas;
using Bolao.Service.Interfaces.Services.Regras;
using Bolao.Service.Interfaces.Services.TabelasConfiguracoes;
using Bolao.Service.Interfaces.Services.TiposFixacoes;
using Bolao.Service.Interfaces.Services.Usuarios;
using Bolao.Service.Services.Boloes;
using Bolao.Service.Services.Campeonatos;
using Bolao.Service.Services.ClassesParceiros;
using Bolao.Service.Services.Importacoes;
using Bolao.Service.Services.MarcasEstruturas;
using Bolao.Service.Services.Pontuacoes;
using Bolao.Service.Services.Produtos;
using Bolao.Service.Services.Propostas;
using Bolao.Service.Services.Regras;
using Bolao.Service.Services.TabelasConfiguracoes;
using Bolao.Service.Services.TiposFixacoes;
using Bolao.Service.Services.Usuarios;
using Bolao.Service.Validators.Commands.Boloes;
using Bolao.Service.Validators.Commands.Campeonatos;
using Bolao.Service.Validators.Commands.ClassesParceiros;
using Bolao.Service.Validators.Commands.Produtos;
using Bolao.Service.Validators.Commands.Propostas;
using Bolao.Service.Validators.Commands.TabelasConfiguracoes;
using Bolao.Service.Validators.Commands.Usuarios;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bolao.API.Configuration
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddCustomDependencyInjections(this IServiceCollection services)
        {
            return services
                .AddApiSettingsAccessorInjection()
                .AddProdutosInjection()
                .AddMarcasEstruturasInjection()
                .AddTiposFixacoesInjection()
                .AddTabelasConfiguracoesInjection()
                .AddPropostasInjection()
                .AddClassesParceirosInjection()
                .AddCampeonatosInjection()
                .AddUsuariosInjection()
                .AddBoloesInjection()
                .AddRegrasInjection()
                .AddImportacoesInjection()
                .AddPontuacoesInjection();
        }

        private static IServiceCollection AddApiSettingsAccessorInjection(this IServiceCollection services)
        {
            return services
                .AddScoped<IApiSettingsAccessor, ApiSettingsAccessor>();
        }

        private static IServiceCollection AddProdutosInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IProdutoRepository, ProdutoRepository>()
                .AddTransient<IProdutoService, ProdutoService>()
                .AddTransient<IValidator<CreateProdutoCommand>, CreateProdutoCommandValidator>()
                .AddTransient<IValidator<UpdateProdutoCommand>, UpdateProdutoCommandValidator>();

            services
                .AddTransient<IEstruturaRepository, EstruturaRepository>()
                .AddTransient<IEstruturaService, EstruturaService>()
                .AddTransient<IValidator<CreateEstruturaCommand>, CreateEstruturaCommandValidator>()
                .AddTransient<IValidator<UpdateEstruturaCommand>, UpdateEstruturaCommandValidator>();

            services
                .AddTransient<IInversorRepository, InversorRepository>()
                .AddTransient<IInversorService, InversorService>()
                .AddTransient<IValidator<CreateInversorCommand>, CreateInversorCommandValidator>()
                .AddTransient<IValidator<UpdateInversorCommand>, UpdateInversorCommandValidator>();

            services
                .AddTransient<ICaboRepository, CaboRepository>()
                .AddTransient<ICaboService, CaboService>()
                .AddTransient<IValidator<CreateCaboCommand>, CreateCaboCommandValidator>()
                .AddTransient<IValidator<UpdateCaboCommand>, UpdateCaboCommandValidator>();

            services
                .AddTransient<IModuloRepository, ModuloRepository>()
                .AddTransient<IModuloService, ModuloService>()
                .AddTransient<IValidator<CreateModuloCommand>, CreateModuloCommandValidator>()
                .AddTransient<IValidator<UpdateModuloCommand>, UpdateModuloCommandValidator>();

            return services;
        }

        private static IServiceCollection AddMarcasEstruturasInjection(this IServiceCollection services)
        {
            return services
                .AddTransient<IMarcaEstruturaRepository, MarcaEstruturaRepository>()
                .AddTransient<IMarcaEstruturaService, MarcaEstruturaService>();
        }

        private static IServiceCollection AddTiposFixacoesInjection(this IServiceCollection services)
        {
            return services
                .AddTransient<ITipoFixacaoRepository, TipoFixacaoRepository>()
                .AddTransient<ITipoFixacaoService, TipoFixacaoService>();
        }

        private static IServiceCollection AddTabelasConfiguracoesInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IConfiguracaoRepository, ConfiguracaoRepository>()
                .AddTransient<IConfiguracaoService, ConfiguracaoService>()
                .AddTransient<IValidator<UpdateConfiguracaoCommand>, UpdateConfiguracaoCommandValidator>();

            services
                .AddTransient<ICartaoCreditoRepository, CartaoCreditoRepository>()
                .AddTransient<ICartaoCreditoService, CartaoCreditoService>()
                .AddTransient<IValidator<UpdateCartaoCreditoCommand>, UpdateCartaoCreditoCommandValidator>();

            return services;
        }

        private static IServiceCollection AddPropostasInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IPropostaRepository, PropostaRepository>()
                .AddTransient<IPropostaService, PropostaService>()
                .AddTransient<IValidator<CalcularItensCommand>, CalcularItensCommandValidator>()
                .AddTransient<IValidator<InserirProdutoCommand>, InserirProdutoCommandValidator>()
                .AddTransient<IValidator<AlterarProdutoQuantidadeCommand>, AlterarProdutoQuantidadeCommandValidator>()
                .AddTransient<IValidator<ExcluirProdutoCommand>, ExcluirProdutoCommandValidator>()
                .AddTransient<IValidator<AlterarFreteCommand>, AlterarFreteCommandValidator>()
                .AddTransient<IValidator<AlterarSeguroCommand>, AlterarSeguroCommandValidator>()
                .AddTransient<IValidator<AlterarCondicaoPagtoCommand>, AlterarCondicaoPagtoCommandValidator>()
                .AddTransient<IValidator<AlterarServicoCommand>, AlterarServicoCommandValidator>();

            services
                .AddTransient<IAuxPropostaRepository, AuxPropostaRepository>()
                /*.AddTransient<IAuxPropostaService, AuxPropostaService>()*/;

            services
                .AddTransient<IAuxPropostaGridRepository, AuxPropostaGridRepository>()
                /*.AddTransient<IAuxPropostaGridService, AuxPropostaGridService>()*/;

            services
                .AddTransient<IAuxPropostaServicoRepository, AuxPropostaServicoRepository>()
                /*.AddTransient<IAuxPropostaServicoService, AuxPropostaServicoService>()*/;

            services
                .AddTransient<IAuxPropostaCartaoRepository, AuxPropostaCartaoRepository>()
                /*.AddTransient<IAuxPropostaCartaoService, AuxPropostaCartaoService>()*/;

            return services;
        }

        private static IServiceCollection AddClassesParceirosInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IClasseParceiroRepository, ClasseParceiroRepository>()
                .AddTransient<IClasseParceiroService, ClasseParceiroService>()
                .AddTransient<IValidator<UpdateClasseParceiroCommand>, UpdateClasseParceiroCommandValidator>();

            services
                .AddTransient<IClasseParceiroDistribuidorRepository, ClasseParceiroDistribuidorRepository>()
                .AddTransient<IClasseParceiroDistribuidorService, ClasseParceiroDistribuidorService>()
                .AddTransient<IValidator<CreateClasseParceiroDistribuidorCommand>, CreateClasseParceiroDistribuidorCommandValidator>()
                .AddTransient<IValidator<UpdateClasseParceiroDistribuidorCommand>, UpdateClasseParceiroDistribuidorCommandValidator>();

            return services;
        }

        private static IServiceCollection AddCampeonatosInjection(this IServiceCollection services)
        {
            services
                .AddTransient<ITimeRepository, TimeRepository>()
                .AddTransient<ITimeService, TimeService>()
                .AddTransient<IValidator<CreateTimeCommand>, CreateTimeCommandValidator>();

            services
                .AddTransient<ICampeonatoTimeRepository, CampeonatoTimeRepository>()
                .AddTransient<ICampeonatoTimeService, CampeonatoTimeService>()
                /*.AddTransient<IValidator<CreateCampeonatoTimeCommand>, CreateCampeonatoTimeCommandValidator>()*/;

            services
                .AddTransient<ICampeonatoPartidaRepository, CampeonatoPartidaRepository>()
                .AddTransient<ICampeonatoPartidaService, CampeonatoPartidaService>()
                .AddTransient<IValidator<CreateCampeonatoPartidaCommand>, CreateCampeonatoPartidaCommandValidator>()
                .AddTransient<IValidator<UpdatePlacarCampeonatoPartidaCommand>, UpdatePlacarCampeonatoPartidaCommandValidator>();

            return services;
        }

        private static IServiceCollection AddUsuariosInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IUsuarioService, UsuarioService>()
                .AddTransient<IValidator<CreateUsuarioCommand>, CreateUsuarioCommandValidator>();

            return services;
        }

        private static IServiceCollection AddBoloesInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IBolaoPalpiteRepository, BolaoPalpiteRepository>()
                .AddTransient<IBolaoPalpiteService, BolaoPalpiteService>()
                .AddTransient<IValidator<CreateBolaoPalpiteCommand>, CreateBolaoPalpiteCommandValidator>();

            return services;
        }

        private static IServiceCollection AddRegrasInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IRegraRepository, RegraRepository>()
                .AddTransient<IRegraService, RegraService>()
                /*.AddTransient<IValidator<CreateRegraCommand>, CreateRegraCommandValidator>()*/;

            return services;
        }

        private static IServiceCollection AddImportacoesInjection(this IServiceCollection services)
        {
            services
                /*.AddTransient<IImportacaoRepository, ImportacaoRepository>()*/
                .AddTransient<IImportacaoService, ImportacaoService>();

            return services;
        }

        private static IServiceCollection AddPontuacoesInjection(this IServiceCollection services)
        {
            services
                /*.AddTransient<IPontuacaoRepository, PontuacaoRepository>()*/
                .AddTransient<IPontuacaoService, PontuacaoService>();

            return services;
        }
    }
}
