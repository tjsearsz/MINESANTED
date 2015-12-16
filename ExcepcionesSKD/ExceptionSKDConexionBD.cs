using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD
{
    public class ExceptionSKDConexionBD : ExceptionSKD
    {
        public ExceptionSKDConexionBD()
            : base()
        { }


        public ExceptionSKDConexionBD(string message)
            : base(message)
        {
        }

        public ExceptionSKDConexionBD(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionSKDConexionBD(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
