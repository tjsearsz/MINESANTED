using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class ResultadoKata
    {
        #region Atributos
        private int id;
        private int jurado1;
        private int jurado2;
        private int jurado3;
        private Inscripcion inscripcion;
        #endregion

        #region Constructores
        public ResultadoKata(int id, int jurado1, int jurado2, int jurado3, Inscripcion inscripcion)
        {
            this.id = id;
            this.jurado1 = jurado1;
            this.jurado2 = jurado2;
            this.jurado3 = jurado3;
            this.inscripcion = inscripcion;
        }
        public ResultadoKata()
        {
            this.id = 0;
            this.jurado1 = 0;
            this.jurado2 = 0;
            this.jurado3 = 0;
            this.inscripcion = new Inscripcion();
        }
        #endregion

        #region Propiedades
        public int Id_ResKata
        {
            get { return id; }
            set { id = value; }
        }

        public int Jurado1
        {
            get { return jurado1; }
            set { jurado1 = value; }
        }

        public int Jurado2
        {
            get { return jurado2; }
            set { jurado2 = value; }
        }

        public int Jurado3
        {
            get { return jurado3; }
            set { jurado3 = value; }
        }
        public Inscripcion Inscripcion
        {
            get { return inscripcion; }
            set { inscripcion = value; }
        }
        #endregion
    }
}
