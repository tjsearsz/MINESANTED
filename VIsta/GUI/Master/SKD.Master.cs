using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using templateApp.GUI.Master;
using templateApp.GUI.Modulo16;
using DominioSKD;


namespace Vista
{
    public partial class SKD : System.Web.UI.MasterPage
    {
        private string idModulo;
        /*public Cuenta userLogin = new Cuenta();
        public string DES=RecursosLogicaModulo2.claveDES;
        public AlgoritmoDeEncriptacion cripto=new AlgoritmoDeEncriptacion();
        private Dictionary<string, string> opcionesDelMenu = new Dictionary<string, string>();
        private Dictionary<string, string[,]> subOpcionesDelMenu = new Dictionary<string, string[,]>();*/ //Se guardaran las sub opciones del menú
        private string[] rolesUsuario = new string[10];//los roles que el usuario tiene registrado

       /* public string IdModulo
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
        }*/

        public string[] RolesUsuario
        {
            get { return rolesUsuario; }
            set { rolesUsuario = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        

        /// <summary>
        /// Se realizan la asignacion de los datos de usuario a la plantilla (nombre,apellido, roles etc)
        /// </summary>
        protected void asignarUsuario()
        {
           

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
            
        }
        /// <summary>
        /// Metodo para el boto Sing Out de la tabla de usuario
        /// </summary>
        protected void logout()
        {
            
        }
    }
}