namespace Bolao.Service.Constants
{
    public static class ValidatorMessageConstant
    {
        public static class Produto
        {
            public const string IdInvalido = "Id do Produto deve ser preenchido.";
            public const string IdProdutoTipo = "Tipo de Produto deve ser preenchido.";
            public const string CodigoInvalido = "Código do Produto deve ser preenchido.";
            public const string DescricaoInvalida = "Descrição do Produto deve ser preenchida.";
            public const string MarcaObrigatoria = "Ao informar o Modelo, a Marca também deve ser informada.";
            public const string MarcaInvalida = "Marca do Produto deve ser preenchida.";
            public const string ModeloObrigatorio = "Ao informar a Marca, o Modelo também deve ser informado.";
            public const string ModeloInvalido = "Modelo do Produto deve ser preenchido.";
            public const string UnidadeInvalida = "Unidade do Produto deve ser preenchida.";
            public const string ValorInvalido = "Valor do Produto deve ser maior do que 0,00.";
            public const string EstruturaInvalida = "Estrutura do Produto deve ser preenchida.";
            public const string InversorInvalido = "Inversor do Produto deve ser preenchido.";
            public const string ModuloInvalido = "Módulo do Produto deve ser preenchido.";
        }

        public static class Estrutura
        {
            public const string IdInvalido = "Id da Estrutura deve ser preenchido.";
            public const string IdTelhadoInvalido = "Id do Telhado deve ser preenchido.";
        }

        public static class Inversor
        {
            public const string IdInvalido = "Id do Inversor deve ser preenchido.";
            public const string PotenciaSaidaInvalida = "POut (Potência de Saída) do Inversor deve ser maior do que 0,00.";
        }

        public static class Cabo
        {
            public const string IdInvalido = "Id do Cabo deve ser preenchido.";
            public const string IdTipoInversorInvalido = "Id do Tipo de Inversor deve ser preenchido.";
        }

        public static class Modulo
        {
            public const string IdInvalido = "Id do Módulo deve ser preenchido.";
            public const string DescricaoGridInvalida = "Descrição (Grid) do Módulo deve ser preenchida.";
            public const string PotenciaInvalida = "Potência do Módulo (kWp) deve ser maior do que 0,00.";
        }

        public static class ItemKit
        {
            public const string IdInvalido = "Deve haver um Id do item.";
            public const string KitIdInvalido = "Deve haver um vínculo com o Kit.";
            public const string ProdutoIdInvalido = "Esse item precisa ter um produto vinculado.";
            public const string QuantidadeInvalida = "A quantidade deve ser preenchida e superior a zero.";
            public const string PrecoUnitarioInvalido = "O item deve conter seu preço unitário.";
            public const string PrecoTotalInvalido = "O item deve conter seu preço total.";
        }

        public static class Kit
        {
            public const string IdInvalido = "Deve haver um Id do Kit.";
            public const string DescricaoInvalida = "Deve haver uma descrição para o Kit.";
            public const string TipoTelhadoIdInvalido = "Deve haver um tipo de telhado vinculado ao Kit.";
            public const string MarcaEstruturaIdInvalida = "Deve haver uma marca vinculada ao Kit.";
            public const string QuantidadeFileirasEstruturaInvalida = "Deve existir uma quantidade de fileiras para a estrutura.";
            public const string QuantidadeModulosFileiraInvalida = "Deve existir uma quantidade de módulos por fileira.";
            public const string PotenciaTotalInvalida = "Deve ser informado a potência total do Kit.";
            public const string PrecoTotalInvalido = "Deve ser informado o preço total do Kit.";
        }

        public static class ComprarKit
        {
            public const string GuidInvalido = "Deve haver um Guid vinculado ao Kit.";
            public const string KitIdInvalido = "Deve haver um Id do Kit.";
            public const string NomeProjetoInvalido = "Deve haver um nome de projeto.";
            public const string EstadoIdInvalido = "Deve haver um estado vinculado.";
            public const string CidadeIdInvalido = "Deve haver uma cidade vinculada.";
            public const string TipoFreteInvalido = "Deve haver um tipo de frete.";
            public const string TipoPagamentoInvalido = "Deve haver um tipo de pagamento válido.";
            public const string UnidadeSolarInvalido = "Deve haver uma unidade válida.";
            public const string PrecoTotalInvalido = "Deve haver um preço válido para o Kit.";
            public const string UsuarioInvalido = "Deve haver um usuário válido para o Kit.";
        }

        public static class AuxProposta
        {
            public const string TipoFreteInvalido = "Tipo de Frete deve ser preenchido.";
            public const string HabilitaSeguroInvalido = "Seguro deve ser preenchido.";
            public const string IdCondicaoPagtoInvalido = "Id da Condição de Pagamento deve ser preenchido.";
            public const string IdUsuarioInvalido = "Id do Usuário deve ser preenchido.";
            public const string IdLojaInvalido = "Id da Loja deve ser preenchido.";
            public const string GuidPropostaInvalido = "Guid da Proposta deve ser preenchido.";
            public const string RealizarCalculosViaAPIInvalido = "Necessário informar se os cálculos da Proposta será realizado via API ou Procedures.";
        }

        public static class AuxPropostaGrid
        {
            public const string IdAuxInvalido = "Id do item da Proposta deve ser preenchido.";
            public const string CodProdutoInvalido = "Código do Produto do item da Proposta deve ser preenchido.";
            public const string QtdDesejadaInvalida = "Quantidade do item da Proposta deve ser maior do que 0.";
        }

        public static class AuxPropostaServico
        {
            public const string ValorProjetoInvalido = "Valor do Projeto deve ser maior ou igual à 0,00.";
            public const string ValorInstalacaoInvalido = "Valor da Instalação deve ser maior ou igual à 0,00.";
        }

        public static class AuxPropostaCartao
        {
            public const string IdOperadoraInvalido = "Id da Operadora do Cartão deve ser preenchido.";
            public const string QuantidadeParcelasInvalida = "Quantidade de Parcelas do Cartão deve ser maior do que 0.";
        }

        public static class ClasseParceiro
        {
            public const string IdClasseParceiroInvalido = "Id deve ser preenchido.";
            public const string DescricaoInvalida = "Descrição da Classe do Parceiro deve ser preenchida.";
            public const string PorcentagemElsysInvalida = "Porcentagem da Classe do Parceiro deve ser maior ou igual à 0,00.";
        }

        public static class ClasseParceiroDistribuidor
        {
            public const string IdClasseParceiroDistribuidorInvalido = "Id deve ser preenchido.";
            public const string IdLojaInvalido = "Id da Loja deve ser preenchido.";
            public const string IdClasseParceiroInvalido = "Id da Classe do Parceiro deve ser preenchido.";
            public const string PorcentagemParceiroInvalida = "Porcentagem do Parceiro deve ser maior ou igual à 0,00.";
        }

        public static class Configuracao
        {
            public const string IdConfiguracaoInvalido = "Id deve ser preenchido.";
            public const string QuantidadeDiasVencimentoPropostaInvalida = "Quantidade de Dias para vencimento das Propostas deve ser maior do que 0.";
            public const string PorcentagemFreteInvalida = "Porcentagem de Frete deve ser maior ou igual à 0,00.";
            public const string PorcentagemImpostoInvalida = "Porcentagem de Imposto deve ser maior ou igual à 0,00.";
            public const string PorcentagemInadimplenciaInvalida = "Porcentagem de Inadimplência deve ser maior ou igual à 0,00.";
            public const string PorcentagemMarketingInvalida = "Porcentagem de Marketing deve ser maior ou igual à 0,00.";
            public const string PorcentagemGarantiaInvalida = "Porcentagem de Garantia deve ser maior ou igual à 0,00.";
            public const string PorcentagemSeguroInvalida = "Porcentagem de Seguro deve ser maior ou igual à 0,00.";
        }

        public static class CartaoCredito
        {
            public const string IdCartaoCreditoInvalido = "Id deve ser preenchido.";
            public const string BandeiraInvalida = "Bandeira deve ser preenchida.";
            public const string Taxa01XInvalida = "Taxa 01 Parcela deve ser maior ou igual à 0,00.";
            public const string Taxa02XInvalida = "Taxa 02 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa03XInvalida = "Taxa 03 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa04XInvalida = "Taxa 04 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa05XInvalida = "Taxa 05 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa06XInvalida = "Taxa 06 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa07XInvalida = "Taxa 07 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa08XInvalida = "Taxa 08 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa09XInvalida = "Taxa 09 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa10XInvalida = "Taxa 10 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa11XInvalida = "Taxa 11 Parcelas deve ser maior ou igual à 0,00.";
            public const string Taxa12XInvalida = "Taxa 12 Parcelas deve ser maior ou igual à 0,00.";
        }

        public static class Time
        {
            public const string IdAuxInvalido = "Id Auxiliar deve ser preenchido.";
            public const string NomeInvalido = "Nome do Time deve ser preenchido.";
            public const string SiglaInvalida = "Sigla do Time deve ser preenchida.";
            public const string UrlImagemInvalida = "URL da imagem do Time deve ser preenchida.";
        }

        public static class CampeonatoPartida
        {
            public const string IdCampeonatoPartidaInvalido = "Id da Partida do Campeonato deve ser preenchido.";
            public const string DtPartidaInvalida = "Data da Partida deve ser maior ou igual à data atual.";
            public const string IdEstadioInvalido = "Id do Estádio deve ser preenchido.";
            public const string IdCampeonatoTime1Invalido = "Id do Campeonato/Time 1 deve ser preenchido.";
            public const string IdCampeonatoTime2Invalido = "Id do Campeonato/Time 2 deve ser preenchido.";
            public const string PesoInvalido = "Peso da Partida deve ser preenchido.";
            public const string PlacarTime1Invalido = "Placar do Time 1 deve ser preenchido.";
            public const string PlacarTime2Invalido = "Placar do Time 2 deve ser preenchido.";
        }

        public static class Usuario
        {
            public const string NomeInvalido = "Nome do Usuário deve ser preenchido.";
            public const string EmailInvalido = "E-mail do Usuário deve ser preenchido.";
            public const string SenhaInvalida = "Senha do Usuário deve ser preenchida.";
            public const string SenhaConfirmacaoInvalida = "Confirmação da Senha do Usuário deve ser preenchida.";
            public const string SenhasNaoConferem = "As Senhas informadas não conferem.";
            public const string UrlImagemInvalida = "URL da imagem do Usuário deve ser preenchida.";
        }

        public static class BolaoPalpite
        {
            public const string IdBolaoUsuarioInvalido = "Id do Bolão Usuário deve ser preenchido.";
            public const string IdCampeonatoPartidaInvalido = "Id do Campeonato Partida deve ser preenchido.";
            public const string PlacarTime1Invalido = "Placar do Time 1 deve ser preenchido.";
            public const string PlacarTime2Invalido = "Placar do Time 2 deve ser preenchido.";
        }

        public static class BolaoUsuario
        {
            public const string IdBolaoInvalido = "Id do Bolão deve ser preenchido.";
            public const string IdUsuarioInvalido = "Id do Usuário deve ser preenchido.";
        }
    }
}
