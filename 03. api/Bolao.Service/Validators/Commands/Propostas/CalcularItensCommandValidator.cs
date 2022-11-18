using Bolao.Domain.Commands.Propostas;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Validators.Commands.Propostas
{
    public class CalcularItensCommandValidator : AbstractValidator<CalcularItensCommand>
    {
        public CalcularItensCommandValidator()
        {

        }
    }
}
