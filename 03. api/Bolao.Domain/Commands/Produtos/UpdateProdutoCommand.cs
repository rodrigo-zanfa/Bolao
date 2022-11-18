using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class UpdateProdutoCommand : ICommand
    {
        public UpdateProdutoCommand(int idProduto, UpdateProdutoTipoCommand produtoTipo, string codigo, string descricao, string marca, string modelo, string unidade, double valor, string ativo, string usuarioAlteracao, UpdateEstruturaCommand estrutura, UpdateInversorCommand inversor, UpdateCaboCommand cabo, UpdateModuloCommand modulo)
        {
            IdProduto = idProduto;
            ProdutoTipo = produtoTipo;
            Codigo = codigo;
            Descricao = descricao;
            Marca = marca;
            Modelo = modelo;
            Unidade = unidade;
            Valor = valor;
            Ativo = ativo;
            UsuarioAlteracao = usuarioAlteracao;
            Estrutura = estrutura;
            Inversor = inversor;
            Cabo = cabo;
            Modulo = modulo;
        }

        public int IdProduto { get; set; }
        public UpdateProdutoTipoCommand ProdutoTipo { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Unidade { get; set; }
        public double Valor { get; set; }
        public string Ativo { get; set; }
        public string UsuarioAlteracao { get; set; }

        public UpdateEstruturaCommand Estrutura { get; set; }
        public UpdateInversorCommand Inversor { get; set; }
        public UpdateCaboCommand Cabo { get; set; }
        public UpdateModuloCommand Modulo { get; set; }
    }
}
