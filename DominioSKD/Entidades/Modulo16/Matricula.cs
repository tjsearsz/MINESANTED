using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo16
{

    /// <summary>
    /// Clase que representa una matricula de un Atleta con en un Dojo
    /// </summary>
    public class Matricula : Entidad
    {

        #region Atributos
        /// <summary>

        /// Identificador en DB
        /// </summary>
        private int _id;


        /// <summary>
        /// Identificador de la matricula
        /// </summary>
        private String _identificador;

        /// <summary>
        /// Fecha de creación de la Matricula
        /// </summary>
        private DateTime _creacion;

        /// <summary>
        /// Ultima fecha de pago de la matrícula
        /// </summary>
        private DateTime _ultimaFechaPago;

        /// <summary>
        /// Estado de la matricula
        /// </summary>
        private Boolean _status;

        /// <summary>
        /// Costo de la matricula
        /// </summary>
        private float costo;


        #endregion

        #region Constructores
        public Matricula(int id)
        {
            this._id = id;
        }

        public Matricula()
        {
            this._id = -1;
        }


        #endregion

        #region Métodos

        public float Costo
        {
            get { return costo; }
            set { costo = value; }
        }
        public int ID
        {
            get { return this._id; }
        }

        public String Identificador
        {
            set
            {
                this._identificador = value;
            }
            get
            {
                return this._identificador;
            }
        }

        public DateTime FechaCreacion
        {
            set
            {
                this._creacion = value;
            }
            get
            {
                return this._creacion;
            }
        }

        public DateTime UltimaFechaPago
        {
            set
            {
                this._ultimaFechaPago = value;
            }
            get
            {
                return this._ultimaFechaPago;
            }
        }

        public Boolean Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

    }

}
