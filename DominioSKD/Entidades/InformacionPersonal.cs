using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DominioSKD
{
    /// <summary>
    /// Clase Abstracta para los datos personales
    /// </summary>
    public abstract class InformacionPersonal
    {
        /// <summary>
        /// Identificador en Base de datos
        /// </summary>
        private int _id;

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="id">Identificador en Base de datos</param>
        public InformacionPersonal(int id)
        {
            this._id = id;
        }

        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }

        /// <summary>
        /// Forzar la imprementación de ToString
        /// </summary>
        public abstract override string ToString();
    }
}
