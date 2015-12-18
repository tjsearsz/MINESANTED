using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo16;
namespace DominioSKD
{
    public class Asistencia
    {
        #region Atributos
        private string asistio;
        private Inscripcion inscripcion;
        private Evento evento;
        private Competencia competencia;
        #endregion

        #region Constructores
        public Asistencia(String asistio, Inscripcion inscripcion, Evento evento)
        {
            this.asistio = asistio;
            this.inscripcion = inscripcion;
            this.evento = evento;
        }

        public Asistencia(String asistio, Inscripcion inscripcion, Competencia competencia)
        {
            this.asistio = asistio;
            this.inscripcion = inscripcion;
            this.competencia = competencia;
        }

        public Asistencia()
        {
            this.asistio = " ";
            this.inscripcion = new Inscripcion();
            this.competencia = new Competencia();
            this.evento = new Evento();
        }

        #endregion

        #region Propiedades
        public String Asistio
        {
            get { return asistio; }
            set { asistio = value; }
        }

        public Inscripcion Inscripcion
        {
            get { return inscripcion; }
            set { inscripcion = value; }
        }

        public Evento Evento
        {
            get { return evento; }
            set { evento = value; }
        }

        public Competencia Competencia
        {
            get { return competencia; }
            set { competencia = value; }
        }
        #endregion
    }
}
