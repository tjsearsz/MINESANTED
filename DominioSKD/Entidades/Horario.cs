using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Horario
    {
        #region Atributos
        private int id;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int horaInicio;
        private int horaFin;
        #endregion

        #region Constructores
        public Horario(int id, DateTime fechaInicio, DateTime fechaFin, int horaInicio, int horaFin)
        {
            this.id = id;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
        }

        public Horario()
        {

        }

        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public int HoraInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public int HoraFin
        {
            get { return horaFin; }
            set { horaFin = value; }
        }

        #endregion
    }
}
