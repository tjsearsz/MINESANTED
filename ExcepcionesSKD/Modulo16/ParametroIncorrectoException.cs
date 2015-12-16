using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16.ExcepcionesDeDatos
{
    public class ParametroIncorrectoException : ExceptionSKD
    {
        public ParametroIncorrectoException()
            : base()
        {
        }

        public ParametroIncorrectoException(string message)
            : base(message)
        {
        }

        public ParametroIncorrectoException(string message, Exception inner)
            : base(message)
        {
        }

        public ParametroIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
