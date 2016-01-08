using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos.Modulo16;
using DominioSKD;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD.Comandos.Fabrica;
using DominioSKD.Entidades.Modulo16;
using System.Web.UI.WebControls;
using DominioSKD.Fabrica;
using System.Web;

namespace Presentadores.Modulo16
{
    public class PresentadorVerCarrito
    {
        #region Atributos
        //Interfaz a usar de su vista
        IcontratoVerCarrito laVista;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase que recibe la interfaz
        /// </summary>
        /// <param name="laVista">Interfaz que es la vista a la que se manipulara</param>
        public PresentadorVerCarrito(IcontratoVerCarrito laVista)
        {
            this.laVista = laVista;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo del presentador que obtiene el carrito de una persona
        /// </summary>
        /// <param name="persona">La Persona a la que se desea ver su carrito</param>
        public void LlenarTabla(Entidad persona)
        {
            //Instancio el comando para ver el carrito, obtengo el carrito de la persona y casteo
            Comando<Entidad> VerCarrito = FabricaComandos.CrearComandoVerCarrito(persona);
            Carrito elCarrito = (Carrito)VerCarrito.Ejecutar();
                        
            //Obtenemos cada implemento para ponerlos en la tabla
            foreach (KeyValuePair<Entidad, int> aux in elCarrito.ListaImplemento)
            {
                //Casteamos la entidad como un implemento
                Implemento item = aux.Key as Implemento;
                
                //Creamos la nueva fila que ira en la tabla
                TableRow fila = new TableRow();

                //Nueva celda que tendra el nombre del implemento
                TableCell celda = new TableCell();
                celda.Text = item.Nombre_Implemento;

                //Agrego la Celda a la fila
                fila.Cells.Add(celda);

                //Nueva celda que tendra el costo del implemento
                celda = new TableCell();
                celda.Text = item.Precio_Implemento.ToString();

                //Agrego la celda a la fila
                fila.Cells.Add(celda);

                //Nueva celda que tendra el textbox para poner la cantidad del implemento
                celda = new TableCell();
                TextBox texto = new TextBox();
                texto.Text = aux.Value.ToString();
                celda.Controls.Add(texto);

                //Agrego la celda a la fila
                fila.Cells.Add(celda);    
            
                //Celda que tendra los botones de Detallar, Modificar y Eliminar
                celda = new TableCell();
                Button boton = new Button();
                boton.Click += Modificar_Carrito;
                boton.CssClass = "btn btn-success glyphicon glyphicon-shopping-cart";
                boton.ID = "Implemento-" + item.Id_Implemento.ToString();
                celda.Controls.Add(boton);

                //Boton informacion
                boton = new Button();
                boton.CssClass = "btn btn-primary glyphicon glyphicon-info-sign";
                boton.ID = "Informacion-" + item.Id_Implemento.ToString();

                //Aqui agregamos atributos para que pueda hacer la llamada de cargar los modales
                boton.Attributes.Add("data-toggle","modal");
                boton.Attributes.Add("data-target", "#modal-info1");

                //Se modifica para que el boton no haga postback
                boton.OnClientClick = "return false;";
                boton.UseSubmitBehavior = false;
                celda.Controls.Add(boton);

                //Agrego la celda a la fila
                fila.Cells.Add(celda);

                //Agrego la fila a la tabla
                this.laVista.tablaImplemento.Rows.Add(fila);
               
            }
            
/*
            //Obtenemos los eventos del carrito de una persona para añadir sus datos al codigo HTML
            string tablaEventosHTML = "";
            foreach (KeyValuePair<Entidad, int> aux in elCarrito.Listaevento)
            {
                //Casteamos la entidad como un implemento y anexamos los valores que se desean
                Evento item = aux.Key as Evento;
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TR + '"' + item.Id_evento.ToString() + '"' + ">";
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + item.Nombre
                    + M16_Recursointerfaz.CERRAR_TD;
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + aux.Value.ToString()
                    + M16_Recursointerfaz.CERRAR_TD;
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + item.Costo.ToString()
                    + M16_Recursointerfaz.CERRAR_TD;

                //Botones ARREGLAR!!!
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD;

                tablaImplementosHTML += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + item.Id_evento.ToString()
                    + M16_Recursointerfaz.BOTON_CERRAR;
                tablaImplementosHTML += M16_Recursointerfaz.BOTON_AGREGAR_IMPLEMENTO_CARRITO_2
                    + item.Id_evento.ToString() + "_" + item.Costo + M16_Recursointerfaz.BOTON_CERRAR;
                tablaImplementosHTML += M16_Recursointerfaz.BOTON_ELIMINAR_ACCION_IMPLEMENTO
                    + item.Id_evento + M16_Recursointerfaz.BOTON_CERRAR;

                tablaImplementosHTML += M16_Recursointerfaz.CERRAR_TD;
                tablaImplementosHTML += M16_Recursointerfaz.CERRAR_TR;
            }
            laVista.tablaEvento.Text = tablaEventosHTML;

            //Obtenemos las matriculas del carrito de una persona para añadir sus datos al codigo HTML
            string tablaMatriculasHTML = "";
            foreach (KeyValuePair<Entidad, int> aux in elCarrito.Listamatricula)
            {
                //Casteamos la entidad como un implemento y anexamos los valores que se desean
                Matricula item = aux.Key as Matricula;
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TR + '"' + item.Id.ToString() + '"' + ">";
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + item.Identificador
                    + M16_Recursointerfaz.CERRAR_TD;
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + aux.Value.ToString()
                    + M16_Recursointerfaz.CERRAR_TD;
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD + item.Costo.ToString()
                    + M16_Recursointerfaz.CERRAR_TD;

                //Botones ARREGLAR!!!
                tablaImplementosHTML += M16_Recursointerfaz.ABRIR_TD;

                tablaImplementosHTML += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + item.Id.ToString()
                    + M16_Recursointerfaz.BOTON_CERRAR;
                tablaImplementosHTML += M16_Recursointerfaz.BOTON_AGREGAR_IMPLEMENTO_CARRITO_2
                    + item.Id.ToString() + "_" + item.Costo + M16_Recursointerfaz.BOTON_CERRAR;
                tablaImplementosHTML += M16_Recursointerfaz.BOTON_ELIMINAR_ACCION_IMPLEMENTO
                    + item.Id + M16_Recursointerfaz.BOTON_CERRAR;

                tablaImplementosHTML += M16_Recursointerfaz.CERRAR_TD;
                tablaImplementosHTML += M16_Recursointerfaz.CERRAR_TR;
            }
            laVista.tablaMatricula.Text = tablaMatriculasHTML;*/
        }

        /// <summary>
        /// Metodo del presentador que modifica la cantidad de un item determinado en el carrito de una persona
        /// </summary>
        /// <param name="sender">El boton que manda la accion</param>
        /// <param name="e">El evento</param>
        public void Modificar_Carrito(object sender, EventArgs e)
        {
            //Persona que eventualmente la buscaremos por el session
            Entidad persona = FabricaEntidades.ObtenerPersona();
            persona.Id = 11;

            //Transformo el boton y obtengo la informacion de que item quiero agregar y su ID
            Button aux = (Button)sender;
            String[] datos = aux.ID.Split('-');    
        
            //Cantidad Deseada nueva por el usuario
            int cantidad = 0;
            
            //Si se trata de un implemento, me voy a la tabla correspondiente
            if (datos[0] == "Implemento")
            {
                //Recorro cada fila para saber a cual me refiero y obtener la cantidad a modificar
                foreach(TableRow aux2 in this.laVista.tablaImplemento.Rows)
                {
                    //Si la fila no es de tipo Header puedo comenzar a buscar
                    if ((aux2 is TableHeaderRow) != true)
                    {
                        //En la celda 3 siempre estaran los botones, casteo el boton
                        Button aux3 = aux2.Cells[3].Controls[0] as Button;

                        //Si el ID del boton en la fila actual corresponde con el ID del boton que realizo la accion
                        //Obtenemos el numero del textbox que el usuario desea
                        if (aux3.ID == aux.ID)
                        {
                            //En la celda 2 siempre estara el textbox, lo obtengo y agarro la cantidad que el usuario desea
                            TextBox eltexto = aux2.Cells[2].Controls[0] as TextBox;
                            cantidad = int.Parse(eltexto.Text);
                            break;
                        }
                    }
                }

                //Decimos que se trata de un implemento
                int TipoObjeto = 1;

                //Creo el implemento y le pasamos el ID que vino del boton
                Implemento objeto = (Implemento)FabricaEntidades.ObtenerImplemento();
                objeto.Id = int.Parse(datos[1]);

                //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
                Comando<bool> ModificarCarrito = FabricaComandos.CrearComandoModificarCarrito(persona, objeto, TipoObjeto, cantidad);
                bool respuesta = ModificarCarrito.Ejecutar();

                //Obtenemos la respuesta y redireccionamos para mostrar el exito o fallo
                if (respuesta)
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=1&exito=1");
                else
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=1&exito=0");
            }            
                        
        }      

        /// <summary>
        /// Metodo del presentador que registra el pago de los productos que hay en el carrito de una persona
        /// </summary>
        /// <param name="persona">La persona que desea comprar los productos</param>
        /// <param name="pago">El tipo de pago con el cual realizo la transaccion</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool RegistrarPago(Entidad persona, String pago)
        {
            //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
            Comando<bool> registrarPago = FabricaComandos.CrearComandoRegistrarPago(persona, pago);
            bool respuesta = registrarPago.Ejecutar();

            //Retorno la respuesta
            return respuesta;
        }

        /*
        /// <summary>
        /// Metodo del presentador que modifica la cantidad de un item determinado en el carrito de una persona
        /// </summary>
        /// <param name="persona">La persona a la que se le modificara el carrito</param>
        /// <param name="objeto">El item en especifico el cual se alterara</param>
        /// <param name="TipoObjeto">indica si se trata de un implemento, evento o matricula</param>
        /// <param name="cantidad">Cantidad nueva que se quiere de ese item</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool ModificarCarrito(Entidad persona, Entidad objeto, int TipoObjeto, int cantidad)
        {
            //Instancio el comando para Registrar un Pago y obtengo el exito o fallo del proceso
            Comando<bool> ModificarCarrito = FabricaComandos.CrearComandoModificarCarrito(persona, objeto, TipoObjeto, cantidad);
            bool respuesta = ModificarCarrito.Ejecutar();

            //Retorno la respuesta
            return respuesta;
        }*/
        #endregion
    }
}
