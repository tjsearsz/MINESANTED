using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo16;

namespace DominioSKD
{
    public class Inscripcion
    {
        #region Atributos
        private int id;
        private DateTime fecha;
        private Persona persona;
        private SolicitudPlanilla solicitud;
        private Competencia competencia;
        private Evento evento;
        private List<Asistencia> asistencias;
        private List<ResultadoAscenso> resAscenso;
        private List<ResultadoKata> resKata;
        private List<ResultadoKumite> resKumite;
        #endregion

        #region Constructores
        public Inscripcion(int id, DateTime fecha, Persona persona, Evento evento)
        {
            this.id = id;
            this.fecha = fecha;
            this.persona = persona;
            this.evento = evento;
            //this.solicitud = new SolicitudPlanilla();
            this.competencia = new Competencia();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<ResultadoAscenso>();
            this.resKata = new List<ResultadoKata>();
            this.resKumite = new List<ResultadoKumite>();

        }
        public Inscripcion(int id, DateTime fecha, Persona persona, Competencia competencia)
        {
            this.id = id;
            this.fecha = fecha;
            this.persona = persona;
            this.competencia = competencia;
            //this.solicitud = new SolicitudPlanilla();
            this.evento = new Evento();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<ResultadoAscenso>();
            this.resKata = new List<ResultadoKata>();
            this.resKumite = new List<ResultadoKumite>();
        }

        public Inscripcion(int id, DateTime fecha, Persona persona, Evento evento, SolicitudPlanilla solicitud)
        {
            this.id = id;
            this.fecha = fecha;
            this.persona = persona;
            this.evento = evento;
            this.solicitud = solicitud;
            this.competencia = new Competencia();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<ResultadoAscenso>();
            this.resKata = new List<ResultadoKata>();
            this.resKumite = new List<ResultadoKumite>();

        }
        public Inscripcion(int id, DateTime fecha, Persona persona, Competencia competencia, SolicitudPlanilla solicitud)
        {
            this.id = id;
            this.fecha = fecha;
            this.persona = persona;
            this.competencia = competencia;
            this.solicitud = solicitud;
            this.evento = new Evento();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<ResultadoAscenso>();
            this.resKata = new List<ResultadoKata>();
            this.resKumite = new List<ResultadoKumite>();
        }
        public Inscripcion()
        {
            this.id = 0;
            this.fecha = new DateTime();
            this.persona = new Persona();
            this.competencia = new Competencia();
            //this.solicitud = new SolicitudPlanilla();
            this.evento = new Evento();
            this.asistencias = new List<Asistencia>();
            this.resAscenso = new List<ResultadoAscenso>();
            this.resKata = new List<ResultadoKata>();
            this.resKumite = new List<ResultadoKumite>();
        }
        #endregion

        #region Propiedades
        public int Id_Inscripcion
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        public SolicitudPlanilla Solicitud
        {
            get { return solicitud; }
            set { solicitud = value; }
        }
        public Competencia Competencia
        {
            get { return competencia; }
            set { competencia = value; }
        }
        public Evento Evento
        {
            get { return evento; }
            set { evento = value; }
        }
        public List<Asistencia> Asistencias
        {
            get { return asistencias; }
            set { asistencias = value; }
        }
        public List<ResultadoAscenso> ResAscenso
        {
            get { return resAscenso; }
            set { resAscenso = value; }
        }
        public List<ResultadoKata> ResKata
        {
            get { return resKata; }
            set { resKata = value; }
        }
        public List<ResultadoKumite> ResKumite
        {
            get { return resKumite; }
            set { resKumite = value; }
        }
        #endregion
    }
}
