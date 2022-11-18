using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bolao.Service//.Extensions
{
    public static class ProdutoExtension
    {
        public static bool IsValidCodigo(this string codigo)
        {
            var pattern = "";

            if (string.IsNullOrEmpty(codigo))
                return false;

            switch (codigo.Length)
            {
                case 19:
                    pattern = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}";
                    break;
                case 15:
                    pattern = "[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}";
                    break;
            }

            if (!string.IsNullOrEmpty(pattern))
                return Regex.Match(codigo, pattern).Success;

            return false;
        }
    }
}
