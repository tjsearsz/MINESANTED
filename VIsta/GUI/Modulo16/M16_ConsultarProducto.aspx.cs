using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioSKD;
using LogicaNegociosSKD;
using LogicaNegociosSKD.Modulo16;
using System.Web.Script.Serialization;
using templateApp.GUI.Master;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;


namespace templateApp.GUI.Modulo16
{
    public partial class M16_ConsultarProducto : System.Web.UI.Page
    {
        private List<Implemento> laLista = new List<Implemento>();

        public static int usuario = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ((SKD)Page.Master).IdModulo = "16";

            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                M16_ConsultarProducto.usuario = int.Parse(Session[RecursosInterfazMaster.sessionUsuarioID].ToString());

                String detalleString = Request.QueryString["impDetalle"];
                String producto = Request.QueryString["compAgregar"];

                //Nos indica si hubo alguna accion de agregar, registrar pago o eliminar
                String accion = Request.QueryString["accion"];
                switch (accion)
                {
                    //Si se viene de un agregar se procedera a mostrar la alerta correspondiente
                    case "1":
                        //Obtenemos el ID del implemento
                        String exito = Request.QueryString["id"];

                        //Si el Agregar fue exitoso o no se procedera dar la alerta correspondiente
                        if (exito.Equals("1"))
                        {
                            //Limpiamos y mostramos la informacion
                            alert.Attributes["class"] = "alert alert-success alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago se ha" +
                                " realizado exitosamente</div>";
                        }
                        else
                        {
                            //Si el agregar fue fallido mostramos la alerta
                            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert.Attributes["role"] = "alert";
                            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                                "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El pago no se ha" +
                                " realizado exitosamente</div>";
                        }
                        break;

                }

                if (detalleString != null)
                {
                    llenarModalInfo(int.Parse(detalleString));
                }

                if (usuario != null && producto != null)
                {
                    // agregarImplementoAcarrito(1, 1);
                }

                #region Llenar Data Table Con Inventario
                //Instancio la logica correspondiente
                Logicacarrito logComp = new Logicacarrito();
                if (!IsPostBack)
                {

                    //me traigo los implementos disponibles
                    laLista = logComp.ListarImplemento();

                    //Recorro La lista de los implementos en el carrito para anexarlas al GRIDVIEW
                    foreach (Implemento c in laLista)
                    {
                        //Creo la fila de la tabla
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TR;

                        //Agrego los datos correspondientes de la tabla
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                        // this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Id_Implemento.ToString() 
                        //   + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Imagen_implemento.ToString()
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Nombre_Implemento.ToString()
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Marca_Implemento.ToString()
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Tipo_Implemento.ToString()
                            + M16_Recursointerfaz.CERRAR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD + c.Precio_Implemento.ToString()
                            + M16_Recursointerfaz.CERRAR_TD;

                        //Agrego los botones y combo
                        this.laTabla.Text += M16_Recursointerfaz.ABRIR_TD;
                        this.laTabla.Text += M16_Recursointerfaz.COMBOCANTIDAD + c.Id_Implemento.ToString() + "_combo" + M16_Recursointerfaz.CERRAR_COMBO;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_INFO_PRODUCTO + c.Id_Implemento + M16_Recursointerfaz.BOTON_CERRAR;
                        this.laTabla.Text += M16_Recursointerfaz.BOTON_AGREGAR_IMPLEMENTO_CARRITO_2 + c.Id_Implemento + "_" + c.Precio_Implemento + M16_Recursointerfaz.BOTON_CERRAR_IMPLEMENTO_CARRITO_2;
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TD;

                        //Cierro la fila creada
                        this.laTabla.Text += M16_Recursointerfaz.CERRAR_TR;
                    }


                }
                #endregion
                
            

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

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

        #region Llamada para el Detalle del Implemento por id
        protected void llenarModalInfo(int Id_implemento)
        {
            try
            {
                //logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                Implemento laCompetencia = new Implemento();
                Logicainventario logica = new Logicainventario();
                laCompetencia = logica.detalleImplementoXId(Id_implemento);

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
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

        #region Llenado del Modal de Informacion del producto
        [System.Web.Services.WebMethod]
        public static string prueba(string id)
        {
            try
            {
                //logger la entrada a este metodo
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
                         
            catch (System.Web.HttpException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";

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

        #region Agregar el producto al carrito
        [System.Web.Services.WebMethod]
        public static string agregarImplementoAcarrito(int idImplemento, int cantidad, int precio)
        {
            try
            {
                //logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                     M16_Recursointerfaz.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                Logicacarrito logica = new Logicacarrito();

                bool agregar = false;

                agregar = logica.agregarInventarioaCarrito(usuario, idImplemento, cantidad, precio);

                string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(agregar);

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    M16_Recursointerfaz.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

               /* if (agregar)
                {
                    //Si se pudo registrar el pago
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=1");
                }
                else
                    //Si no se pudo registrar el pago
                    HttpContext.Current.Response.Redirect("M16_VerCarrito.aspx?accion=2&exito=0");*/

                return json;
            }

            catch (System.Web.HttpException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                System.Web.UI.HtmlControls.HtmlGenericControl alert = new System.Web.UI.HtmlControls.HtmlGenericControl();
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
                    "aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ha ocurrido un error " +
                    "en esta pagina presentada</div>";

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
    }
}