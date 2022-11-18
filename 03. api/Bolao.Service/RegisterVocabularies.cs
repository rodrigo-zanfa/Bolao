using Humanizer.Inflections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service
{
    public static class RegisterVocabularies
    {
        public static void Configure()
        {
            Vocabularies.Default.AddPlural("caracter", "caracteres");
        }
    }
}
