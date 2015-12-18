using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Rol
    {
        #region atributos
        private int id_rol;
        private String nombre;
        private String descripcion;
        private DateTime fecha_creacion;
        #endregion

        #region propiedades
        public int Id_rol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime Fecha_creacion
        {
            get { return fecha_creacion; }
            set { fecha_creacion = value; }
        }
        #endregion

        #region constructores
        /// <summary>
        /// constructor sin parametros de rol
        /// </summary>
        public Rol()
        {
            id_rol = 0;
            nombre = "";
            descripcion = "";
            fecha_creacion = new DateTime();
        }
        /// <summary>
        /// constructor con parametros de rol
        /// </summary>
        /// <param name="elId"> el id del rol</param>
        /// <param name="elNombre">el nombre del rol</param>
        /// <param name="laDescripcion"> la descripcion del rol</param>
        /// <param name="laFecha">la fecha en que fue creado el rol</param>
        public Rol(int elId, String elNombre, String laDescripcion, DateTime laFecha)
        {
            id_rol = elId;
            nombre = elNombre;
            descripcion = laDescripcion;
            fecha_creacion = laFecha;
        }
        /// <summary>
        /// constructor numero 3 de rol el cual recibe algunos parametros
        /// </summary>
        /// <param name="elId">el id del rol</param>
        /// <param name="elNombre">el nombre del rol</param>
        /// <param name="laDescripcion">la descripcion del rol </param>
        public Rol(int elId, String elNombre, String laDescripcion)
        {
            id_rol = elId;
            nombre = elNombre;
            descripcion = laDescripcion;
        }
        #endregion
    }
}
