using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    /// <summary>
    /// Clase que controla la excepcion al encontrarse un item que no corresponde o esta vacio
    /// </summary>
    public class ItemInvalidoException:ExceptionSKD
    {
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public ItemInvalidoException():base()
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje de la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        public ItemInvalidoException(String mensaje):base(mensaje)
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje y la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public ItemInvalidoException(String mensaje, Exception excepcion):base(mensaje, excepcion)
        {

        }

        /// <summary>
        /// Constructor que obtiene el codigo del error, el mensaje y la excepcion
        /// </summary>
        /// <param name="codigo">Identificador especifico del error ocurrido</param>
        /// <param name="mensaje"><El mensaje de error que se pasa al ocurrir la excepcion/param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public ItemInvalidoException(String codigo, String mensaje, Exception excepcion)
            :base(codigo, mensaje, excepcion)
        {

        }
    }
}
