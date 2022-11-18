using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Produtos
{
    public class CreateProdutoCommand : ICommand
    {
        public CreateProdutoCommand(CreateProdutoTipoCommand produtoTipo, string codigo, string descricao, string marca, string modelo, string unidade, double valor, string ativo, string usuarioInclusao, CreateEstruturaCommand estrutura, CreateInversorCommand inversor, CreateCaboCommand cabo, CreateModuloCommand modulo)
        {
            ProdutoTipo = produtoTipo;
            Codigo = codigo;
            Descricao = descricao;
            Marca = marca;
            Modelo = modelo;
            Unidade = unidade;
            Valor = valor;
            Ativo = ativo;
            UsuarioInclusao = usuarioInclusao;
            Estrutura = estrutura;
            Inversor = inversor;
            Cabo = cabo;
            Modulo = modulo;
        }

        public CreateProdutoTipoCommand ProdutoTipo { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Unidade { get; set; }
        public double Valor { get; set; }
        public string Ativo { get; set; }
        public string UsuarioInclusao { get; set; }

        public CreateEstruturaCommand Estrutura { get; set; }
        public CreateInversorCommand Inversor { get; set; }
        public CreateCaboCommand Cabo { get; set; }
        public CreateModuloCommand Modulo { get; set; }
    }
}
