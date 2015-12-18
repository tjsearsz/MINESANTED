using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class SolicitudPlanilla
    {
        #region atributos

        private int id;
        private DateTime fechaCreacion;
        private DateTime fechaRetiro;
        private DateTime fechaReincorporacion;
        private string motivo;
        private Planilla planilla;
        private int idInscripcion;
        private int idPersona;
        private string evento;

        #endregion

        #region metodos
        public SolicitudPlanilla()
        {
        }
        public SolicitudPlanilla(DateTime fechaCreacion, DateTime fechaRetiro, DateTime fechaReincorporacion,
            string motivo, Planilla planilla, int idInscripcion, int idPersona)
        {
            this.fechaCreacion = fechaCreacion;
            this.fechaRetiro = fechaRetiro;
            this.fechaReincorporacion = fechaReincorporacion;
            this.motivo = motivo;
            this.planilla = planilla;
            this.idInscripcion = idInscripcion;
            this.idPersona = idPersona;
        }

        public SolicitudPlanilla(int id,DateTime fechaCreacion, DateTime fechaRetiro, DateTime fechaReincorporacion,
            string motivo, Planilla planilla, int idInscripcion, int idPersona)
        {
            this.id = id;
            this.fechaCreacion = fechaCreacion;
            this.fechaRetiro = fechaRetiro;
            this.fechaReincorporacion = fechaReincorporacion;
            this.motivo = motivo;
            this.planilla = planilla;
            this.idInscripcion = idInscripcion;
            this.idPersona = idPersona;
        }

        public SolicitudPlanilla(DateTime fechaCreacion, Planilla planilla, int idInscripcion, int idPersona)
        {
            this.fechaCreacion = fechaCreacion;
            this.planilla = planilla;
            this.idInscripcion = idInscripcion;
            this.idPersona = idPersona;
        }

        public SolicitudPlanilla(int id, DateTime fechaCreacion, Planilla planilla, int idInscripcion, int idPersona)
        {
            this.id = id;
            this.fechaCreacion = fechaCreacion;
            this.planilla = planilla;
            this.idInscripcion = idInscripcion;
            this.idPersona = idPersona;
        }

        public SolicitudPlanilla(DateTime fechaRetiro, DateTime fechaReincorporacion, string motivo, Planilla planilla)
        {
            this.fechaRetiro = fechaRetiro;
            this.fechaReincorporacion = fechaReincorporacion;
            this.motivo = motivo;
            this.planilla = planilla;
        }
        #endregion

        #region gets y sets

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        public DateTime FechaRetiro
        {
            get { return fechaRetiro; }
            set { fechaRetiro = value; }
        }

        public DateTime FechaReincorporacion
        {
            get { return fechaReincorporacion; }
            set { fechaReincorporacion = value; }
        }

        public Planilla Planilla
        {
            get { return planilla; }
            set { planilla = value; }
        }

        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        public int IdInscripcion
        {
            get { return idInscripcion; }
            set { idInscripcion = value; }
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public string Evento
        {
            get { return evento; }
            set { evento = value; }
        }
        #endregion

    }
}
