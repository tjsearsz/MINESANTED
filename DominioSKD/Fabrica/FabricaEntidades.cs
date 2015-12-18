using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DominioSKD.Entidades;
 

namespace DominioSKD.Fabrica
{
    public class FabricaEntidades
    {

        #region Modulo 16
        public Entidad ObtenerCarrito()
        {
            return new Entidades.Modulo16.Carrito();
        }
        public Entidad ObtenerMatricula()
        {
            return new Entidades.Modulo16.Matricula();
        }
        public Entidad ObtenerEvento()
        {
            return new Entidades.Modulo16.Evento();
        }
        public Entidad ObtenerCompra()
        {
            return new Entidades.Modulo16.Compra();
        }

        public Entidad ObtenerPersona()
        {
            return new Entidades.Modulo16.Persona();
        }

        public Entidad ObtenerImplemento()
        {
            return new Entidades.Modulo16.Implemento();
        }

        #endregion

    }
}
