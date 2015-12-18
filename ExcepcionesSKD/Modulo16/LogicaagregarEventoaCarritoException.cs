using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    class LogicaagregarEventoaCarritoException : ExceptionSKD
    {

        public LogicaagregarEventoaCarritoException()
            : base()
        { }

        public LogicaagregarEventoaCarritoException(string message)
            : base(message)
        {
        }

        public LogicaagregarEventoaCarritoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public LogicaagregarEventoaCarritoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

    }
}
