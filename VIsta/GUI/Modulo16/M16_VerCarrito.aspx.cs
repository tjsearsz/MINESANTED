using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using Contratos.Modulo16;
using Presentadores.Modulo16;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;
using DominioSKD.Fabrica;

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
        /// Propiedad de la tablaImplemento
        /// </summary>
        public Table tablaImplemento
        {
            get { return this.TablaImplemento; }
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
            //Persona de prueba que ya tiene cosas en el carrito
            Entidad persona = FabricaEntidades.ObtenerPersona();
            persona.Id = 11;

            //Lleno la tabla
            this.elPresentador.LlenarTabla(persona);

            //Nos indica si hubo alguna accion de agregar, modificar o eliminar
            String accion = Request.QueryString["accion"];

            //Revisamos si es alguno de los casos a continuacion
            switch(accion)
            {
                //Si se viene de un modificar obtenemos esta alerta
                case "1":
                    //Obtenemos el exito o fallo del proceso
                    String exito = Request.QueryString["exito"];

                    if (exito.Equals("1"))
                    {
                        //Si el modificar fue exitoso mostramos esta alerta
                         alert.Attributes["class"] = "alert alert-success alert-dismissible";
                         alert.Attributes["role"] = "alert";
                         alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\""+
                             " aria-la"+"bel=\"Close\"><span aria-hidden=\"true\">&times;</span></button>"+
                             "Cantidad modificada exitosamente</div>";
                     }
                    else
                    {
                        //Si el modificar fue fallido mostramos esta alerta
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            " aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
                            "No existe tal cantidad en el inventario</div>";
                    }
                    break;            }

            /*
            Button boton = new Button();
            boton.Click += Prueba_click;
            boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
            boton.Width = 75;
            boton.Height = 20;
            boton.ID = "Boton1";

            Entidad persona = FabricaEntidades.ObtenerPersona();
            persona.Id = 11;

            TableRow fila = new TableRow();

            TableCell celda = new TableCell();
            celda.Text = "1";
            fila.Cells.Add(celda);

            celda = new TableCell();
            celda.Text = "2";
            fila.Cells.Add(celda);

            celda = new TableCell();
            TextBox text = new TextBox();
            text.Text = "11";
            celda.Controls.Add(text);
            fila.Cells.Add(celda);

            celda = new TableCell();
            celda.Controls.Add(boton);
            fila.Cells.Add(celda);            
            
            this.tablaImplemento.Rows.Add(fila);

            boton = new Button();
            boton.Click += Prueba_click;
            boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
            boton.Width = 75;
            boton.Height = 20;
            boton.ID = "Boton2";

            persona = FabricaEntidades.ObtenerPersona();
            persona.Id = 11;

            fila = new TableRow();

            celda = new TableCell();
            celda.Text = "1";
            fila.Cells.Add(celda);

            celda = new TableCell();
            celda.Text = "2";
            fila.Cells.Add(celda);

            celda = new TableCell();
            text = new TextBox();
            text.Text = "11";
            celda.Controls.Add(text);
            fila.Cells.Add(celda);

            celda = new TableCell();
            celda.Controls.Add(boton);
            fila.Cells.Add(celda);
            this.tablaImplemento.Rows.Add(fila);

            //Obtengo el Carrito de la Persona
            //this.elPresentador.LlenarTabla(persona);*/

            //Verificamos si estamos ingresando a la pagina web sin ser redireccionamiento a ella misma
            // if (!IsPostBack)

        }

        /*
        public void Prueba_click(object sender, EventArgs e)
        {
            Button aux2 = (Button)sender;
            String id = aux2.ID;
            int numero = this.Table1.Rows.Count;

            foreach(TableRow aux in this.Table1.Rows)
            {
                if ((aux is TableHeaderRow) != true)
                {
                    Button aux3 = aux.Cells[3].Controls[0] as Button;
                    if (aux3.ID == id)
                    {

                        TextBox eltexto = aux.Cells[2].Controls[0] as TextBox;
                        string textofinal = eltexto.Text;
                    }
                }
                
            }
        }*/
    }        
}
