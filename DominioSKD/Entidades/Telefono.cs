using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesSKD;

namespace DominioSKD
{
    /// <summary>
    /// Clase Telefono, una instancia representa un numero telefoónico en
    /// Venezueal
    /// </summary>
    public class Telefono : InformacionPersonal
    {

        #region Atributos
        /// <summary>
        /// Numero telefónico de 11 dígitos.
        /// </summary>
        private String _numero;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor Vacio
        /// </summary>
        /// <param name="id">Identificador en DB</param>
        public Telefono(int id) : base(id) { }
        public Telefono() : base(-1) { }

        #endregion

        #region Métodos Privados
        /// <summary>
        /// Chequea que el string solo contenga digitos;
        /// </summary>
        /// <param name="value">String a chequear</param>
        /// <exception cref="ExcepcionesSKD.InformacionPersonalInvalidaException">
        /// Si el el valor contiene algún caracter que no sea dígito.
        /// </exception>
        private void CheckDigits(String value)
        {
            if (!value.All(char.IsDigit))
                throw new InformacionPersonalInvalidaException("La información de Telefono solo deben ser digitos.");
        }

        /// <summary>
        /// Cheqea el largo del string
        /// </summary>
        /// <param name="value">String a chequear</param>
        /// <param name="length">Largo que deberia de tener el string</param>
        /// <exception cref="ExcepcionesSKD.InformacionPersonalInvalidaException">
        /// Si el valor no tiene el largo pasado en el atributo length
        /// </exception>
        private void CheckLength(String value, int length)
        {
            if (value.Length != length)
                throw new InformacionPersonalInvalidaException("La información de Telefono no tiene el tamaño de un número telefónico.");
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Get y set del atributo Numero
        /// </summary>
        /// <exception cref="ExcepcionesSKD.InformacionPersonalInvalidaException">
        /// Vet CheckDigits y CheckLength
        /// </exception>
        public String Numero
        {
            get { return this._numero; }
            set
            {
                this.CheckDigits(value);
                this.CheckLength(value, 11);
                this._numero = value;
            }
        }

        /// <summary>
        /// Sobre escritura del metodo ToString
        /// </summary>
        /// <returns> Numero telefonico en formato dddd-ddddddd
        /// en donde d es un dígito.
        /// </returns>
        public override string ToString()
        {
            return this._numero.Substring(0, 4) + "-" + this._numero.Substring(4);
        }
        #endregion

    }
}
