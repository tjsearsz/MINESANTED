using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;
using templateApp.GUI.Modulo1;
using DominioSKD;
using LogicaNegociosSKD.Modulo2;

namespace templateApp
{
    public partial class SKD : System.Web.UI.MasterPage
    {
        private string idModulo;
        public Cuenta userLogin = new Cuenta();
        public string DES=RecursosLogicaModulo2.claveDES;
        public AlgoritmoDeEncriptacion cripto=new AlgoritmoDeEncriptacion();
        private Dictionary<string, string> opcionesDelMenu = new Dictionary<string, string>();
        private Dictionary<string, string[,]> subOpcionesDelMenu = new Dictionary<string, string[,]>(); //Se guardaran las sub opciones del menú
        private string[] rolesUsuario = new string[10];//los roles que el usuario tiene registrado

        public string IdModulo
        {
            get { return idModulo; }
            set { idModulo = value; }
        }
        public Dictionary<string, string> OpcionesDelMenu
        {
            get { return opcionesDelMenu; }
            set { opcionesDelMenu = value; }
        }
        public Dictionary<string, string[,]> SubOpcionesDelMenu
        {
            get { return subOpcionesDelMenu; }
            set { subOpcionesDelMenu = value; }
        }
        public string[] RolesUsuario
        {
            get { return rolesUsuario; }
            set { rolesUsuario = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[RecursosInterfazMaster.sessionUsuarioID].ToString() != null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Server.MapPath(RecursosInterfazMaster.direccionMaster_MenuLateral));
                    idModulo = IdModulo;
                    foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                        foreach (XmlNode subNode in node.ChildNodes)
                            if (!(subNode.Attributes[RecursosInterfazMaster.tagId] == null) &&
                                subNode.Attributes[RecursosInterfazMaster.tagId].InnerText.Equals(IdModulo))
                            {
                                OpcionesDelMenu[node.Attributes[RecursosInterfazMaster.tagName].InnerText] =
                                    node.Attributes[RecursosInterfazMaster.tagLink].InnerText;
                                break;
                            }
                    asignarUsuario();
                    DropDownMenu();
                }
                else
                    Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);

            }
            catch (NullReferenceException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
        

        /// <summary>
        /// Se realizan la asignacion de los datos de usuario a la plantilla (nombre,apellido, roles etc)
        /// </summary>
        protected void asignarUsuario()
        {
            
            string Stringhttp = RecursosInterfazMaster.AliasHttp;
            char[] http = Stringhttp.ToCharArray();
            string imagen = Session[RecursosInterfazMaster.sessionImagen].ToString();

            if (imagen == "")
            {
                imagen = "../../dist/img/AvatarSKD.jpg";
            }
                imageUsuario.Src = imagen;
                imageTag.Src = imagen;

            userName.InnerText = (string)Session[RecursosInterfazMaster.sessionUsuarioNombre];

            //aqui va el nombre y apellido
            userTag.InnerText = (string)Session[RecursosInterfazMaster.sessionNombreCompleto] ;
            string[] roles = Session[RecursosInterfazMaster.sessionRoles].ToString().Split(char.Parse(RecursosInterfazMaster.splitRoles));
            int cont = 0;
            foreach (string perfil in roles)
            {
                rolesUsuario[cont] = perfil;
                cont++;
            }
            if (Request.QueryString[RecursosInterfazMaster.sessionRol] == RecursosInterfazMaster.sessionLogout)
                logout();

                string rol = cripto.DesencriptarCadenaDeCaracteres
                    (Request.QueryString[RecursosInterfazMaster.sessionRol], RecursosLogicaModulo2.claveDES);


                if (rol != null)
                    Session[RecursosInterfazMaster.sessionRol] = rol;

        }

        /// <summary>
        /// Metodo para validar si el rol esta contenido en los permisos de las opciones
        /// </summary>
        /// <param name="permisos">permisos de opciones</param>
        /// <param name="rolUsuario">rol de usuario</param>
        /// <returns>true:si tiene permiso;false:si no tiene permiso</returns>
        protected Boolean validaRol(string[] permisos, string rolUsuario)
        {
            foreach (string rol in permisos)
            {
                if (rol == rolUsuario)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// El metodo guarda en la variable DropDownM de tipo Dictionary las Subopciones de la Opcion en el menú
        /// </summary>
        protected void DropDownMenu()
        {
            string rol = (string)(Session[RecursosInterfazMaster.sessionRol]);
            XmlDocument doc = new XmlDocument();
            string[] permisos;//se guardaran los permisos asociados a cada opcion del menuSuperior.xml
            string[] opciones = new string[2];
            int i = 0; //iteracion de posicionOpciones
            doc.Load(Server.MapPath(RecursosInterfazMaster.direccionMaster_MenuSuperior));
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                i = 0;
                permisos = node.Attributes[RecursosInterfazMaster.sessionRol].InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));

                if (validaRol(permisos, rol))
                {
                    string[,] posicionOpcinones = new string[2, node.ChildNodes.Count];
                    foreach (XmlNode subNode in node.ChildNodes)
                    {

                        permisos = subNode.Attributes[RecursosInterfazMaster.sessionRol].
                            InnerText.Split(char.Parse(RecursosInterfazMaster.splitRoles));
                        if ((subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText != null) && (validaRol(permisos, rol)))
                        {

                            posicionOpcinones[0, i] = (string)subNode.Attributes[RecursosInterfazMaster.tagName].InnerText.ToString();
                            posicionOpcinones[1, i] = subNode.Attributes[RecursosInterfazMaster.tagLink].InnerText.ToString();
                            i++;
                        }
                    }

                    SubOpcionesDelMenu[node.Attributes[RecursosInterfazMaster.tagName].InnerText] = posicionOpcinones;

                }
            }
        }
        /// <summary>
        /// Metodo para el boto Sing Out de la tabla de usuario
        /// </summary>
        protected void logout()
        {
            Session.Remove(RecursosInterfazMaster.sessionRol);
            Session.Remove(RecursosInterfazMaster.sessionRoles);
            Session.Remove(RecursosInterfazMaster.sessionUsuarioID);
            Session.Remove(RecursosInterfazMaster.sessionUsuarioNombre);
            Session.Remove(RecursosInterfazMaster.sessionImagen);
            Response.Redirect(RecursosInterfazModulo1.direccionM1_Index);
        }
    }
}