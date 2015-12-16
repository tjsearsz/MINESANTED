using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD
{
    public class InformacionPersonalInvalidaException : ExceptionSKD
    {
        public InformacionPersonalInvalidaException()
            : base()
        { }

        public InformacionPersonalInvalidaException(string message)
            : base(message)
        {
        }

        public InformacionPersonalInvalidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public InformacionPersonalInvalidaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
