 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    /// <summary>
    /// Enumeracion para el tipo de documento
    /// </summary>
    public enum TipoDocumento
    {
        Cedula,
        Pasaporte
    }

    /// <summary>
    /// Enumeracion para el tipo de cédula
    /// </summary>
    public enum TipoCedula
    {
        Nacional,
        Extranjera
    }

    /// <summary>
    /// Clase que representa un documento de identidad
    /// </summary>
    public class DocumentoIdentidad : InformacionPersonal
    {

        #region Atributos
        /// <summary>
        /// Numero del documento de identificación
        /// </summary>
        private int _numero;

        /// <summary>
        /// Tipo de documento
        /// </summary>
        public TipoDocumento Tipo;

        /// <summary>
        /// Tipo de cedula en caso de serlo.
        /// </summary>
        public TipoCedula TipoCedula;
        #endregion

        #region Costructor
        public DocumentoIdentidad() : base(-1) { }
        #endregion

        #region Métodos

        /// <summary>
        /// Set y get de Numero
        /// </summary>
        public int Numero {
            set { this._numero = value; }
            get { return this._numero; }
        }

        /// <summary>
        /// Implementacion del metodo ToString
        /// </summary>
        /// <returns>La cedula en formato:
        /// V-15.456.452
        /// E-15.456.452
        /// P-15.456.452
        /// </returns>
       public override string ToString()
        {
            String retorno;
            if (this.Tipo == TipoDocumento.Pasaporte)
                retorno = "P-";
            else
            {
                if (this.TipoCedula == TipoCedula.Extranjera)
                    retorno = "E-";
                else
                    retorno = "V-";
            }
            return retorno + this._numero.ToString("N0");
        }
        #endregion
    }
}
