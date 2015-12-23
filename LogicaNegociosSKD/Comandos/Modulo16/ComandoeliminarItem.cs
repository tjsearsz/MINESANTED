using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.FabricaDAO;
using ComandosSKD;
using DominioSKD;
using DatosSKD.Modulo16;
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using ExcepcionesSKD.Modulo16;
using ExcepcionesSKD;
using DatosSKD.DAO.Modulo16;
using ComandosSKD.Modulo16;

namespace ComandosSKD.Modulo16
{
    class ComandoeliminarItem : Comando<Entidad>
    {


        #region Atributos
        int _tipobj;
        int _objbor;
        bool _e;
        Entidad _param;
        #endregion


        /// <summary>
        /// Comando que ejecuta la logica para eliminar un item del carrito
        /// </summary>
        /// <param name="parametro">tipo de objeto, objeto a borrar, persona</param>
        /// <returns>retorna true si se elimino el item a seleccionar de forma satisfactoriamente,
        /// de lo contrario devueleve false</returns>
        public override bool Ejecutar()
        {

            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IdaoCarrito daoCarrito = laFabrica.ObtenerDAOCarrito();


                //Retornamos la respuesta  
                return daoCarrito.eliminarItem(1, 1, _param);


            }



            #region Catches
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

            #endregion



        }

        public ComandoeliminarItem(bool e)
        {
            _e = e;

        }

    }
}
