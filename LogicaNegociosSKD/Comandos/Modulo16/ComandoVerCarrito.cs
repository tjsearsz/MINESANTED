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
using DominioSKD.Fabrica;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando que ejecuta la accion de Ver los items en el carrito de una persona
    /// </summary>
    public class ComandoVerCarrito:Comando<Entidad>
    {
        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private Entidad persona;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo Persona
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
        /// Constructor vacio del Comando
        /// </summary>
        public ComandoVerCarrito()
        {

        }

        /// <summary>
        /// Constructor del comando con todos los datos requeridos para VerCarrito
        /// </summary>
        /// <param name="persona">La persona a la que se le mostrara los items de su carrito</param>
        public ComandoVerCarrito(Entidad persona)
        {
            this.persona = persona;
        }
        #endregion

        /// <summary>
        /// Metodo que ejecuta la accion de VerCarrito
        /// </summary>
        /// <returns>El carrito de una persona</returns>
        public override Entidad Ejecutar()
        {
            try
            {
               //Escribo en el logger la entrada a este metodo
               Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_ENTRADA_LOGGER,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

               //Respuesta a obtener en el DAO
               Entidad carrito;

               //Instancio el DAO de Carrito
               IdaoCarrito daocarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();

                //Obtengo todos los items del carrito de la persona
               carrito = FabricaEntidades.ObtenerCarrito
                   (daocarrito.getImplemento(this.persona), 
                   daocarrito.getEvento(this.persona), 
                   daocarrito.getMatricula(this.persona));

               //Escribo en el logger la salida a este metodo
               Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                   RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

               //retorno la entidad de donde sea llamada
               return carrito;
            }
            catch(PersonaNoValidaException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ArgumentNullException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (FormatException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (OverflowException e)
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
                throw e;
            }
            
        }
    }
}
