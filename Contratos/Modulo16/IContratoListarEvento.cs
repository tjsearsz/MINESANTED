using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace InterfazSKD.Contratos.Modulo16
{
    public interface IContratoListarEvento
    {
        //void agregarTabla(string laTabla);

        Literal tablaEventos { get; }    
        
    }
}
