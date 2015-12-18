using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    class CarritoSinInventarioException : ExceptionSKD
    {


        public CarritoSinInventarioException()
            : base()
        { }

        public CarritoSinInventarioException(string message)
            : base(message)
        {
        }

        public CarritoSinInventarioException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CarritoSinInventarioException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }







    }
}
