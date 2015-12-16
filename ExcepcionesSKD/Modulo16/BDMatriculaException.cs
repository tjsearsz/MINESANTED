using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16.ExcepcionesDeDatos
{
    public class BDMatriculaException : ExceptionSKD
    {
        public BDMatriculaException()
            : base()
        {
        }

        public BDMatriculaException(string message)
            : base(message)
        {
        }

        public BDMatriculaException(string message, Exception inner)
            : base(message)
        {
        }

        public BDMatriculaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
