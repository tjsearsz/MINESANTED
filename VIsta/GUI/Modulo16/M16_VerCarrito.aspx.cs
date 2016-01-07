using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using Contratos.Modulo16;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo16
{
    /// <summary>
    /// Clase parcial que Representa CodeBehind de la interfaz de VerCarrito
    /// </summary>
    public partial class M16_VerCarrito : System.Web.UI.Page, IcontratoVerCarrito
    {
        #region Atributos
        //Presentador pertinente que manipulara la vista
        private PresentadorVerCarrito elPresentador;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del literal Implemento
        /// </summary>
        public Literal tablaImplemento
        {
            get
            {

                return this.laTabla1;
            }
        }

        /// <summary>
        /// Propiedad del literal Evento
        /// </summary>
        public Literal tablaEvento
        {
            get
            {

                return this.laTabla2;

            }
        }

        /// <summary>
        /// Propiedad del literal Matricula 
        /// </summary>
        public Literal tablaMatricula
        {
            get
            {

                return this.laTabla3;

            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la vista de VerCarrito que instancia su presentador;
        /// </summary>
        public M16_VerCarrito()
        {
            this.elPresentador = new PresentadorVerCarrito(this);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            //Obtengo el Carrito de la Persona
            //this.elPresentador.LlenarTabla();

            //Verificamos si estamos ingresando a la pagina web sin ser redireccionamiento a ella misma
            // if (!IsPostBack)

        }
    }        
}
