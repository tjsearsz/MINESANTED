using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD.Modulo16;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

namespace templateApp.GUI.Modulo16
{
    /// <summary>
    /// Code Behind de VerCarrito.aspx
    /// </summary>
    public partial class M16_VerCarrito : System.Web.UI.Page
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        public Carrito carritoCompras;
        public Logicacarrito logicaCarrito;
        public static int usuario = 0;
       
        /// <summary>
        /// Metodo que carga las configuraciones por defecto y opciones especiales de su ventana correspondiente
        /// </summary>
        /// <param name="sender">Objeto que ejecuta esta accion</param>
        /// <param name="e">Clase base para las clases que contienen la informacion del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);               

                //Obtengo el ID del usuario
                M16_VerCarrito.usuario = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

                //Si estoy entrando por primera vez lleno la tabla
                if (!IsPostBack)
                {

                    //Lleno la tabla
                    Llenartabla();


                }

                //Nos indica si hubo alguna accion de agregar, registrar pago o eliminar
                String accion = Request.QueryString["accion"];
                String exito = Request.QueryString["exito"];
                switch (accion)
                {
                    case "1":
                       
                        //Si el registrar pago fue exitoso o no se procedera dar la alerta correspondiente
                        if (exito.Equals("1"))
                        {
                            //Limpiamos y mostramos la informacion
                            this.carritoCompras.limpiar();
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El producto se ha" +
                                " agregado exitosamente</div>";
                        }
                        else
                        {
                            //Si el registrar pago fue fallido mostramos la alerta
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El producto no se ha" +
                                " agregado exitosamente</div>";
                        }
                        break;
                    //Si se viene de un registrar pago se procedera a mostrar la alerta correspondiente
                    case "2":
                        
                        //Si el registrar pago fue exitoso o no se procedera dar la alerta correspondiente
                        if (exito.Equals("1"))
                        {
                            //Limpiamos y mostramos la informacion
                            this.carritoCompras.limpiar();
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago se ha" +
                                " realizado exitosamente</div>";
                        }
                        else
                        {
                            //Si el registrar pago fue fallido mostramos la alerta
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago no se ha" +
                                " realizado exitosamente</div>";
                        }
                        break;

                    //Si se viene de un eliminar se procedera a eliminar y mostrar la alerta correspondiente
                    case "3":

                        //Se obtiene el exito o fallo de la eliminacion y se evalua
                        bool respuesta = true;
                        if (respuesta)
                        {
                            //Si el eliminar fue exitoso mostramos esta alerta
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El item ha sido" +
                                " eliminado exitosamente</div>";
                        }
                        else
                        {
                            //Si el eliminar no fue exitoso mostramos esta alerta
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El item no ha" +
                                " sido eliminado</div>";
                        }
                        break;

                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch (ReferenciaNulaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";
            }
            catch (System.Web.HttpException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";

            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            } 
        }

        #region LlenarTabla
        /// <summary>
        /// Metodo que se encarga de llenar el GRIDVIEW con todos los elementos que hayan en el carrito del Usuario
        /// </summary>
        public void Llenartabla()
        {
            try
            {   
                
                    //Instancio la logica correspondiente y me traigo el carrito de compras
                    Logicacarrito logicaCarrito = new Logicacarrito();
                    carritoCompras = logicaCarrito.verCarrito(usuario);

                    //Recorro La lista de los implementos en el carrito para anexarlas al GRIDVIEW
                    foreach (Implemento implemento in carritoCompras.ListaImplemento)
                    {
                        //Creo la fila de la tabla
                        this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TR_INVENTARIO + implemento.Id_Implemento +">";

                        //Agrego los datos correspondientes de la tabla
                       // this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + implemento.Imagen_implemento + 
                         //   M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + implemento.Nombre_Implemento + 
                            M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD + implemento.Precio_Implemento + 
                            M16_Recursointerfaz.CERRAR_TD;

                        //Agrego los botones
                        this.laTabla1.Text += M16_Recursointerfaz.ABRIR_TD;

                        
                        this.laTabla1.Text += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + implemento.Id_Implemento+ 
                            M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla1.Text += M16_Recursointerfaz.BOTON_ELIMINAR_GENERAL + implemento.Id_Implemento +"_I" +
                            M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla1.Text += M16_Recursointerfaz.CERRAR_TD;

                        //Cierro la fila creada
                        this.laTabla1.Text += M16_Recursointerfaz.CERRAR_TR;
                    }
            
                    //Recorro la lista de las matriculas en el carrito para anexarlas al GRIDVIEW
                    foreach (Matricula matricula in carritoCompras.Listamatricula)
                    {
                        //Creo la fila de la tabla
                        this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TR_MATRICULA +">";

                        //Agrego los datos correspondientes de la tabla con sus botones
                        this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + matricula.Identificador + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + matricula.FechaCreacion + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD + matricula.UltimaFechaPago + M16_Recursointerfaz.CERRAR_TD;
                
                        //Agrego los botones
                        this.laTabla2.Text += M16_Recursointerfaz.ABRIR_TD;
                        this.laTabla2.Text += M16_Recursointerfaz.BOTON_ELIMINAR_GENERAL + matricula.Id + "_M" +
                            M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla2.Text += M16_Recursointerfaz.CERRAR_TD;

                        //Cierro la fila creada
                        this.laTabla2.Text += M16_Recursointerfaz.CERRAR_TR;
                    }

                    //Recorro la lista de eventos en el carrito para anexarlas al GRIDVIEW
                    foreach (Evento evento in carritoCompras.Listaevento)
                    {
                        //Creo la fila de la tabla
                        this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TR_EVENTO + evento.Id_evento +">";

                        //Agrego los datos correspondientes de la tabla con sus botones
                        this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + evento.Nombre +
                            M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD + evento.Costo + 
                            M16_Recursointerfaz.CERRAR_TD;
                

                        //Agrego los botones
                        this.laTabla3.Text += M16_Recursointerfaz.ABRIR_TD;
                        //Arreglar el boton info
                        this.laTabla3.Text += M16_Recursointerfaz.BOTON_INFO_EVENTO_CARRITO + evento.Id_evento + 
                            M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla1.Text += M16_Recursointerfaz.BOTON_ELIMINAR_GENERAL + evento.Id_evento + "_E" +
                            M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla3.Text += M16_Recursointerfaz.CERRAR_TD;

                        //Cierro la fila creada
                        this.laTabla3.Text += M16_Recursointerfaz.CERRAR_TR;

                    }
                    //Escribo en el logger la salida a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReferenciaNulaException(M16_Recursointerfaz.CODIGO_REFERENCIA_NULA_EXCEPTION,
                    M16_Recursointerfaz.MENSAJE_REFERENCIA_NULA_EXCEPTION, ex);
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw ex;

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;

            } 

        }
        #endregion

        #region Llenar Modales de Implemento y Evento 

                #region Llamada para el Detalle del Implemento por id
                protected void llenarModalInfoImplemento(int Id_implemento)
                {
                    try
                    {
                        //Escribo en el logger la entrada a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                         M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);   

                        Implemento elProducto = new Implemento();
                        Logicainventario logica = new Logicainventario();
                        elProducto = logica.detalleImplementoXId(Id_implemento);

                        //Escribo en el logger la salida a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                            M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                    catch (NullReferenceException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                            "al buscar alguno de los items de su carrito </div>";
                    }
                    catch (LoggerException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                            "interno</div>";

                    }
                    catch (ParseoVacioException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoFormatoInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoEnSobrecargaException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParametroInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKDConexionBD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (Exception ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";
                    } 
                    
                }
                #endregion


                #region Llamada para el Detalle del Evento por id
                protected void llenarModalInfoEvento(int Id_evento)
                {
                    try
                    {
                        //Escribo en el logger la entrada a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                         M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);   

                        Evento elEvento = new Evento();
                        Logicaevento logica = new Logicaevento();
                        elEvento = logica.detalleEventoXId(Id_evento);

                        //Escribo en el logger la salida a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                            M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                    catch (NullReferenceException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                            "al buscar alguno de los items de su carrito </div>";
                    }
                    catch (LoggerException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                            "interno</div>";

                    }
                    catch (ParseoVacioException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoFormatoInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoEnSobrecargaException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParametroInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKDConexionBD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (Exception ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    } 
                    
                }
                
                #endregion

        #endregion

        #region Pintar la informacion en el modal

                #region Llenado del Modal de Informacion del Implemento
                [System.Web.Services.WebMethod]
                public static string pruebaImplemento(string id)
                {
                    try
                    {
                        //Escribo en el logger la entrada a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                         M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name); 

                        Implemento elProducto = new Implemento();
                        Logicainventario logica = new Logicainventario();
                        elProducto = logica.detalleImplementoXId(int.Parse(id));
                        string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(elProducto);

                        //Escribo en el logger la salida a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                            M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        return json;
                    }
                    catch (NullReferenceException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                            "al buscar alguno de los items de su carrito </div>";
                    }
                    catch (LoggerException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                            "interno</div>";

                    }
                    catch (ParseoVacioException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoFormatoInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoEnSobrecargaException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParametroInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKDConexionBD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (Exception ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }

                    return null;
                    
                }
                #endregion

                #region Llenado del Modal de Informacion del evento
                [System.Web.Services.WebMethod]
                public static string pruebaEvento(string id)
                {
                    try
                    {
                        //Escribo en el logger la entrada a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                         M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name); 

                        Evento elEvento = new Evento();
                        Logicaevento logica = new Logicaevento();
                        elEvento = logica.detalleEventoXId(int.Parse(id));
                        string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(elEvento);

                        //Escribo en el logger la salida a este metodo
                        Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                            M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        return json;
                    }
                    catch (NullReferenceException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                            "al buscar alguno de los items de su carrito </div>";
                    }
                    catch (LoggerException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                            "interno</div>";

                    }
                    catch (ParseoVacioException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoFormatoInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParseoEnSobrecargaException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ParametroInvalidoException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKDConexionBD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (ExceptionSKD ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }
                    catch (Exception ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                            "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                            "podido consultar</div>";

                    }

                    return null;
                    
                }
                #endregion

        #endregion

        #region Eliminar y Registrar
        /// <summary>
        /// Metodo que se encarga de eliminar un item determinado del carrito
        /// </summary>
        /// <returns>El exito o fallo del proceso</returns>
        [System.Web.Services.WebMethod]
        public static string eliminarItem(int tipoObjeto, int idObjeto)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name); 

                //Creo el objeto de la capa de  Logica y la respuesta a recibir
            Logicacarrito logica = new Logicacarrito();
            bool exito = false;

            //Recibo la respuesta del eliminar
            exito = logica.eliminarItem(tipoObjeto, idObjeto, usuario);

            //Devuelvo la respuesta a la peticion ajax
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(exito);

            //Escribo en el logger la salida a este metodo
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return json;
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                    "al buscar alguno de los items de su carrito </div>";
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }

            return null;
        }
            

        /// <summary>
        /// Metodo que se encarga de efectuar el pago de los productos en el carrito
        /// </summary>

        protected void registrarPago(object sender, EventArgs e)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name); 

                //Lista que almacenara los datos correspondientes segun el tipo de pago
                List<int> datosPago = new List<int>();

                //Si se ha elegido un tipo de pago correcto
                if (!DropDownList1.Value.Equals("-1"))
                {
                    //Si se ha elegido tarjeta se procede a guardar sus datos
                    if (DropDownList1.Value.Equals("1"))
                    {
                        datosPago.Add(int.Parse(Text1.Value));
                        datosPago.Add(int.Parse(Text2.Value));
                        datosPago.Add(int.Parse(Text3.Value));
                        datosPago.Add(int.Parse(Text4.Value));
                    }
                    //Si se ha elegido deposito se procede a guardar sus datos
                    else if (DropDownList1.Value.Equals("2"))
                    {
                        datosPago.Add(int.Parse(Text5.Value));
                        datosPago.Add(int.Parse(Text6.Value));
                        datosPago.Add(int.Parse(Text7.Value));
                    }
                    //Si se ha elegido transferencia se procede a guardar sus datos
                    else
                    {
                        datosPago.Add(int.Parse(Text8.Value));
                        datosPago.Add(int.Parse(Text9.Value));
                        datosPago.Add(int.Parse(Text10.Value));
                    }

                    //Obtengo el ID del usuario
                    //int idUsuario = (int)(Session[RecursosInterfaz);
                    int tipoPago = int.Parse(DropDownList1.Value);

                    Logicacarrito logica = new Logicacarrito();

                    //Se registra el pago y se obtiene el exito o fallo
                    bool exito = logica.registrarPago(tipoPago, datosPago, usuario);

                    //Analizamos las condiciones
                    if (exito)
                    {
                        //Si se pudo registrar el pago
                        HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=1");
                    }
                    else
                        //Si no se pudo registrar el pago
                        HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=0");

                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

            }
            catch(ArgumentOutOfRangeException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                    "al buscar alguno de los items de su carrito </div>";
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error" +
                    "al buscar alguno de los items de su carrito </div>";
            }
            catch (LoggerException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "interno</div>";

            }
            catch (ParseoVacioException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoFormatoInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParseoEnSobrecargaException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ParametroInvalidoException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKDConexionBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (ExceptionSKD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Los eventos no se han " +
                    "podido consultar</div>";

            }
        }
        #endregion

    }
            
}
