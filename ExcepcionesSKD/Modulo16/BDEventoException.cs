using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16.ExcepcionesDeDatos
{
    public class BDEventoException : ExceptionSKD
    {
        public BDEventoException()
            : base()
        {
        }

        public BDEventoException(string message)
            : base(message)
        {
        }

        public BDEventoException(string message, Exception inner)
            : base(message)
        {
        }

        public BDEventoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
