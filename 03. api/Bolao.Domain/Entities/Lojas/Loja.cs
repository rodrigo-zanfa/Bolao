using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Entities.Lojas
{
    public class Loja
    {
        public int IdLoja { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string Endereco { get; private set; }
        public string NumEndereco { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
        public string Fone { get; private set; }
    }
}
