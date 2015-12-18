using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    public class ErrorEnHTTPException : ExceptionSKD
    {
        public ErrorEnHTTPException() : base() { }

        public ErrorEnHTTPException(String mensaje) : base(mensaje) { }

        public ErrorEnHTTPException(String mensaje, Exception e) : base(mensaje, e) { }

        public ErrorEnHTTPException(String codigo, String mensaje, Exception e) : base(codigo, mensaje, e) { }
    }
}
