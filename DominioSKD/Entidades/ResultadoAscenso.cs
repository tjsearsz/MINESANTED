using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class ResultadoAscenso
    {
        #region Atributos
        private int id;
        private string aprobado;
        private Inscripcion inscripcion;
        #endregion

        #region Constructores
        public ResultadoAscenso(int id, string aprobado, Inscripcion inscripcion)
        {
            this.id = id;
            this.aprobado = aprobado;
            this.inscripcion = inscripcion;
        }
        public ResultadoAscenso()
        {
            this.id = 0;
            this.aprobado = " ";
            this.inscripcion = new Inscripcion();
        }
        #endregion

        #region Propiedades
        public int Id_ResAscenso
        {
            get { return id; }
            set { id = value; }
        }
        public string Aprobado
        {
            get { return aprobado; }
            set { aprobado = value; }
        }
        public Inscripcion Inscripcion
        {
            get { return inscripcion; }
            set { inscripcion = value; }
        }
        #endregion
    }
}
