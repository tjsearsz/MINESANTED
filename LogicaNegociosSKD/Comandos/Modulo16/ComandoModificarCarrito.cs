using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.FabricaDAO;
using DatosSKD.InterfazDAO.Modulo16;
using DominioSKD;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;

namespace LogicaNegociosSKD.Comandos.Modulo16
{

    public class ComandoModificarCarrito: Comando<bool>
    {
        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private Entidad persona;
        private Entidad objeto;
        private int tipoObjeto;
        private int cantidad;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del comando
        /// </summary>
        public ComandoModificarCarrito()
        {

        }

        /// <summary>
        /// Constructor del comando con todos los datos requeridos para modificar
        /// </summary>
        /// <param name="persona">La persona a la que se le modificara el carrito</param>
        /// <param name="objeto">El item que se modificara del carrito de la persona</param>
        /// <param name="tipoObjeto">Indica a que tipo de item nos estamos refiriendo para Modificar</param>
        /// <param name="cantidad">la cantidad nueva que se quiere del objeto</param>
        public ComandoModificarCarrito(Entidad persona, Entidad objeto, int tipoObjeto, int cantidad)
        {
            this.persona = persona;
            this.objeto = objeto;
            this.tipoObjeto = tipoObjeto;
            this.cantidad = cantidad;            
        } 
        #endregion

        /// <summary>
        /// Metodo que ejecuta la accion de ModificarCarrito
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

                //Instancio el DAO de Carrito
                IdaoCarrito daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();

                //Ejecuto ModificarCarrito y retorno el resultado
                Respuesta = daoCarrito.ModificarCarrito(this.persona, this.objeto, this.tipoObjeto, this.cantidad);

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosLogicaModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //retorno la respuesta de donde sea llamado
                return Respuesta;
                
            }
            catch(OpcionItemErroneoException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
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
