using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Domain.Commands.Boloes
{
    public class CreateBolaoUsuarioCommand : ICommand
    {
        public int IdBolao { get; set; }
        public int IdUsuario { get; set; }
    }
}
