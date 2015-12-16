using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class TipoEvento
    {
        #region Atributos
        private int id;
        private String nombre;
        #endregion

        #region Constructores
        public TipoEvento(int id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public TipoEvento()
        {
            id = 0;
            nombre = "";
        }
        #endregion

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion
    }
}
