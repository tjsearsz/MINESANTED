using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class ResultadoKumite
    {
        #region Atributos
        private int id;
        private int puntaje1;
        private int puntaje2;
        private Inscripcion inscripcion1;
        private Inscripcion inscripcion2;
        #endregion

        #region Constructores
        public ResultadoKumite(int id, int puntaje1, int puntaje2, Inscripcion inscripcion1, Inscripcion inscripcion2)
        {
            this.id = id;
            this.puntaje1 = puntaje1;
            this.puntaje2 = puntaje2;
            this.inscripcion1 = inscripcion1;
            this.inscripcion2 = inscripcion2;
        }

        public ResultadoKumite()
        {
            this.id = 0;
            this.puntaje1 = 0;
            this.puntaje2 = 0;
            this.inscripcion1 = new Inscripcion();
            this.inscripcion2 = new Inscripcion();
        }
        #endregion

        #region Propiedades
        public int Id_ResKumite
        {
            get { return id; }
            set { id = value; }
        }
        public int Puntaje1
        {
            get { return puntaje1; }
            set { puntaje1 = value; }
        }
        public int Puntaje2
        {
            get { return puntaje2; }
            set { puntaje2 = value; }
        }
        public Inscripcion Inscripcion1
        {
            get { return inscripcion1; }
            set { inscripcion1 = value; }
        }
        public Inscripcion Inscripcion2
        {
            get { return inscripcion2; }
            set { inscripcion2 = value; }
        }
        #endregion
    }
}
