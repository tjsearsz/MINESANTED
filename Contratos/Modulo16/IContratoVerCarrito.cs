using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratos.Modulo16
{
    /// <summary>
    /// Interface para el manejo de la vista VerCarrito
    /// </summary>
    public interface IcontratoVerCarrito
    {
        /// <summary>
        /// Tabla donde se colocaran todos los implementos que hay en el carrito del usuario
        /// </summary>
        Literal tablaImplemento { get; }

        /// <summary>
        /// Tabla donde se colocaran todos los eventos que hay en el carrito del usuario
        /// </summary>
        Literal tablaEvento { get; }

        /// <summary>
        /// Tabla donde se colocaran todas las matriculas que hay en el carrito del usuario
        /// </summary>
        Literal tablaMatricula { get; }
    }
}
