using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    class AgregarEventoaCarritoFallidoException : ExceptionSKD
    {

        public AgregarEventoaCarritoFallidoException()
            : base()
        { }

        public AgregarEventoaCarritoFallidoException(string message)
            : base(message)
        {
        }

        public AgregarEventoaCarritoFallidoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public AgregarEventoaCarritoFallidoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
