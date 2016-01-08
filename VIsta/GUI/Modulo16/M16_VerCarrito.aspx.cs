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
        /// Propiedad del literal Implemento
        /// </summary>
        public Literal tablaImplemento
        {
            get
            {

               throw new NotImplementedException();
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
            
            this.tabla1.Rows.Add(fila);

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
            this.tabla1.Rows.Add(fila);

            //Obtengo el Carrito de la Persona
            //this.elPresentador.LlenarTabla(persona);

            //Verificamos si estamos ingresando a la pagina web sin ser redireccionamiento a ella misma
            // if (!IsPostBack)

        }

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
        }


        public Table tabla1
        {
            get { return this.Table1; }
        }
    }        
}
