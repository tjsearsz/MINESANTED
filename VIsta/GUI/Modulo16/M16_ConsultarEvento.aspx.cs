using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo16;
using InterfazSKD.Contratos.Modulo16;

namespace Vista.GUI.Modulo16
{
    public partial class M16_ConsultarEvento : System.Web.UI.Page,InterfazSKD.Contratos.Modulo16.IContratoListarEvento
    {
        private PresentadorListarEvento presentador;

       
        public void IniciarPresentador()
        {
            presentador = new PresentadorListarEvento(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            /* this.Master.ID = "16";
             this.Master.presentador.CargarMenuLateral();
             presentador.ObtenerVariablesURL();*/
            if (!IsPostBack) 
            {
                this.IniciarPresentador();
                presentador.consultarEventos();
            }
           
        }

      

       //Forma 1.
       /* public void agregarTabla(string laTabla)
        {
           
        }*/

       public Literal tablaEventos
       {

           get
           {
               return this.tlTablaEventos;
           }
       }
       

    }
}