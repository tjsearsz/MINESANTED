using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.FabricaDAO;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;

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
        public String TipoPago
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

        #region Constructores
        /// <summary>
        /// Constructor vacio del comando
        /// </summary>
        public ComandoRegistrarPago()
        {

        }

        /// <summary>
        /// Constructor con los datos a insertar del comando
        /// </summary>
        public ComandoRegistrarPago(Entidad persona, String TipoPago)
        {
            this.persona = persona;
            this.tipoPago = TipoPago;
        }
        #endregion

        /// <summary>
        /// Metodo que ejecuta la accion de RegistrarPago
        /// </summary>
        /// <returns>el exito o fallo del proceso</returns>
        public override bool Ejecutar()
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Respuesta a obtener en el DAO
                bool Respuesta = false;

                //Instancio el DAO del Carrito
                IdaoCarrito daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();

                //Ejecuto el registrar pago y obtengo el exito o fallo del proceso
                Respuesta = daoCarrito.RegistrarPago(this.persona, this.tipoPago);

                //retorno la respuesta de donde sea llamado
                return Respuesta;
            }
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoVacioException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoFormatoInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParseoEnSobrecargaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ParametroInvalidoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKDConexionBD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ExceptionSKD e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ExceptionSKDConexionBD(RecursosLogicaModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosLogicaModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }        
        }
    }
}
