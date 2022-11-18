using FluentValidation.Results;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Helpers
{
    public static class ValidationErrorMessagesHelper
    {
        public static List<string> GetMessages(List<ValidationFailure> errors, bool exibirErrosDetalhados = true)
        {
            var result = new List<string>();

            foreach (var erro in errors)
            {
                var mensagem = erro.ErrorMessage;

                if (exibirErrosDetalhados)
                {
                    if (erro.ErrorCode == "LengthValidator")
                    {
                        if (mensagem.EndsWith(".")) mensagem = mensagem.Remove(mensagem.Length - 1);
                        mensagem += $" (informado {"caracter".ToQuantity(Convert.ToInt32(erro.FormattedMessagePlaceholderValues["TotalLength"]))}, mas deve estar entre {erro.FormattedMessagePlaceholderValues["MinLength"]} e {erro.FormattedMessagePlaceholderValues["MaxLength"]}).";
                    }
                }

                result.Add(mensagem);
            }

            return result;
        }
    }
}
