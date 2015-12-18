using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    class CarritosSinInventarioException : ExceptionSKD
    {

        public CarritosSinInventarioException()
            : base()
        { }

        public CarritosSinInventarioException(string message)
            : base(message)
        {
        }

        public CarritosSinInventarioException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public CarritosSinInventarioException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


    }
}
