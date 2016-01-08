using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Contratos.Modulo16
{
    /// <summary>
    /// Interface para el manejo de la vista VerCarrito
    /// </summary>
    public interface IcontratoVerCarrito
    {
        /// <summary>
        /// Tabla donde se mostrara todos los implementos del carrito
        /// </summary>
        Table tablaImplemento { get; }
    }
}
