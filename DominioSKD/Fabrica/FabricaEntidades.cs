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
        /// <summary>
        /// Metodo de la fabrica que instancia un carrito vacio
        /// </summary>
        /// <returns>La entidad carrito vacia</returns>
        public static Entidad ObtenerCarrito()
        {
            return new Entidades.Modulo16.Carrito();
        }

        /// <summary>
        /// Metodo de la fabrica que instancia el carrito con todas sus listas llenas
        /// </summary>
        /// <param name="implementos">Lista con todos los implementos del carrito</param>
        /// <param name="eventos">Lista con todos los eventos del carrito</param>
        /// <param name="matriculas">Lisita con todas las matriculas del carrito</param>
        /// <returns>La entidad carrito con todos sus datos llenos</returns>
        public static Entidad ObtenerCarrito
            (List<Entidad> implementos, List<Entidad> eventos, List<Entidad> matriculas)
        {
            return new Entidades.Modulo16.Carrito(implementos, eventos, matriculas);
        }
        public static Entidad ObtenerMatricula()
        {
            return new Entidades.Modulo16.Matricula();
        }
        public Entidad ObtenerEvento()
        {
            return new Entidades.Modulo16.Evento();
        }
        public static Entidad ObtenerCompra()
        {
            return new Entidades.Modulo16.Compra();
        }

        public static Entidad ObtenerPersona()
        {
            return new Entidades.Modulo16.Persona();
        }

        public static Entidad ObtenerImplemento()
        {
            return new Entidades.Modulo16.Implemento();
        }

        #endregion

    }
}
