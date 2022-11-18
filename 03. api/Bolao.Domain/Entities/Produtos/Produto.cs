using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Produtos
{
    public class Produto : EntityBase
    {
        public Produto()
        {

        }

        public Produto(int idProduto, ProdutoTipo produtoTipo, string codigo, string descricao, string marca, string modelo, string unidade, double valor, string ativo, string usuarioInclusaoOuAlteracao, Estrutura estrutura, Inversor inversor, Cabo cabo, Modulo modulo)
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
            UsuarioInclusao = usuarioInclusaoOuAlteracao;
            UsuarioAlteracao = usuarioInclusaoOuAlteracao;
            Estrutura = estrutura;
            Inversor = inversor;
            Cabo = cabo;
            Modulo = modulo;
        }

        public int IdProduto { get; private set; }
        public ProdutoTipo ProdutoTipo { get; /*private*/ set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Unidade { get; private set; }
        public double Valor { get; private set; }
        public string Ativo { get; /*private*/ set; }

        public Estrutura Estrutura { get; /*private*/ set; }
        public Inversor Inversor { get; /*private*/ set; }
        public Cabo Cabo { get; /*private*/ set; }
        public Modulo Modulo { get; /*private*/ set; }
    }
}
