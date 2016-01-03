using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesSKD.Modulo16
{
    /// <summary>
    /// Clase que controla la excepcion al tenerse una persona que es nula o no es de tipo Persona
    /// </summary>
    public class PersonaNoValidaException:ExceptionSKD
    {
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public PersonaNoValidaException():base()
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje de la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        public PersonaNoValidaException(String mensaje):base(mensaje)
        {

        }

        /// <summary>
        /// Constructor que obtiene el mensaje y la excepcion
        /// </summary>
        /// <param name="mensaje">El mensaje de error que se pasa al ocurrir la excepcion</param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public PersonaNoValidaException(String mensaje, Exception excepcion):base(mensaje, excepcion)
        {

        }

        // <summary>
        /// Constructor que obtiene el codigo del error, el mensaje y la excepcion
        /// </summary>
        /// <param name="codigo">Identificador especifico del error ocurrido</param>
        /// <param name="mensaje"><El mensaje de error que se pasa al ocurrir la excepcion/param>
        /// <param name="excepcion">La excepcion como tal capturada</param>
        public PersonaNoValidaException(String codigo, String mensaje, Exception excepcion)
            :base(codigo, mensaje, excepcion)
        {

        }
    }
}
