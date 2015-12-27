using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.FabricaDAO;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando que ejecuta la accion de Registrar el pago del Usuario
    /// </summary>
    public class ComandoRegistrarPago: Comando<bool>
    {
        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private String tipoPago;
        private Entidad persona;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo TipoPago
        /// </summary>
        public string TipoPago
        {
            get
            {
                return this.tipoPago;
            }

            set
            {
                this.tipoPago = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo persona
        /// </summary>
        public Entidad Persona
        {
            get
            {
                return this.persona;
            }

            set
            {
                this.persona = value;
            }
        }
        #endregion

        /// <summary>
        /// Metodo que ejecuta la accion de RegistrarPago
        /// </summary>
        /// <returns>el exito o fallo del proceso</returns>
        public override bool Ejecutar()
        {
            //Instancio el DAO del Carrito
            IdaoCarrito daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();

            //Ejecuto el registrar pago y obtengo el exito o fallo del proceso
            return daoCarrito.RegistrarPago(this.persona, this.tipoPago);            
        }
    }
}
