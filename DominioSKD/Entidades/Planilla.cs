using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Planilla
    {
        #region atributos

        private int id;
        private string nombre;
        private Boolean status;
        private string tipoPlanilla;
        private int idTipoPlanilla;
        private Diseño diseño;
        private List<SolicitudPlanilla> solicitud;
        private List<String> datos;
        #endregion

        #region metodos

        public Planilla()
        {
            
        }
        public Planilla(string nombre, Boolean status, string tipoPlanilla)
        {
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla=tipoPlanilla;
        }

        public Planilla(int id, string nombre, Boolean status, string tipoPlanilla)
        {
            this.id = id;
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla=tipoPlanilla;
        }
        
        public void AgregarSolicitud(SolicitudPlanilla solicitud)
        {
            this.solicitud.Add(solicitud);
        }
        public Planilla(string nombre, bool status, string tipoPlanilla, List<String> datos)
        {
            this.nombre = nombre;
            this.status = status;
            this.tipoPlanilla = tipoPlanilla;
            this.datos = datos;
        }
        public Planilla(string nombre, bool status, int idTipoPlanilla, List<String> datos)
        {
            this.nombre = nombre;
            this.status = status;
            this.idTipoPlanilla = idTipoPlanilla;
            this.datos = datos;
        }
        public Planilla(int id,string nombre, bool status, int idTipoPlanilla, List<String> datos)
        {
            this.id = id;
            this.nombre = nombre;
            this.status = status;
            this.idTipoPlanilla = idTipoPlanilla;
            this.datos = datos;
        }
        public Planilla(int idTipoPlanilla, string tipoPlanilla)
        {
            this.idTipoPlanilla = idTipoPlanilla;
            this.tipoPlanilla = tipoPlanilla;

        }

        public Planilla(string nombre, bool status, int idTipoPlanilla)
        {
            this.nombre = nombre;
            this.status = status;
            this.idTipoPlanilla = idTipoPlanilla;
        }

        public Planilla(List<String> datos)
        {
            this.datos = datos;
        }

        #endregion

        #region gets y sets


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public string TipoPlanilla
        {
            get { return tipoPlanilla; }
            set { tipoPlanilla = value; }
        }

        public int IDtipoPlanilla
        {
            get { return idTipoPlanilla; }
            set { idTipoPlanilla = value; }
        }



        public Diseño Diseño
        {
            get { return diseño; }
            set { diseño = value; }
        }

        public List<SolicitudPlanilla> Solicitud
        {
            get { return solicitud; }
            set { solicitud = value; }
        }

        public List<String> Dato
        {
            get { return datos; }
            set { datos = value; }
        }

        public List<int> IdDatos
        {
            get { return IdDatos; }
            set { IdDatos = value; }
        }
        #endregion
    }
}
