using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    class CarritoSinEventoException : ExceptionSKD
    {

        public CarritoSinEventoException()
            : base()
        { }

        public CarritoSinEventoException(string message)
            : base(message)
        {
        }

        public CarritoSinEventoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CarritoSinEventoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }




    }
}
