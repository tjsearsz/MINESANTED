using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace templateApp
{
    public partial class SKD : System.Web.UI.MasterPage
    {
        private string idModulo;
        private Dictionary<string, string> opcionesDelMenu = new Dictionary<string, string>();

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

        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/GUI/Master/menuLateral.xml"));
            idModulo = IdModulo;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                foreach (XmlNode subNode in node.ChildNodes)
                    if (!(subNode.Attributes["id"] == null) && subNode.Attributes["id"].InnerText.Equals(IdModulo))
                    {
                        OpcionesDelMenu[node.Attributes["nombre"].InnerText] = node.Attributes["link"].InnerText;
                        break;
                    }

        }
    }
}