using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    public class ReferenciaNulaException : ExceptionSKD
    {
        public ReferenciaNulaException() : base() { }

        public ReferenciaNulaException(String mensaje) : base(mensaje) { }

        public ReferenciaNulaException(String mensaje, Exception e) : base(mensaje, e) { }

        public ReferenciaNulaException(String codigo, String mensaje, Exception e) : base(codigo, mensaje, e) { }


    }
}
