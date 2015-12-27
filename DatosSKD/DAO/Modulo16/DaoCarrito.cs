using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DominioSKD.Entidades.Modulo16;
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using ExcepcionesSKD;
using System.Data.Sql;
using System.Configuration;
using ExcepcionesSKD.Modulo16;
using DatosSKD;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD;




namespace DatosSKD.DAO.Modulo16
{
    /// <summary>
    /// Clase que gestiona todo el proceso del carrito del usuario contra la Base de Datos
    /// </summary>
    public class DaoCarrito : DAOGeneral, InterfazDAO.Modulo16.IdaoCarrito
    {
        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase BDCarrito
        /// </summary>
        public DaoCarrito()
        {

        }
        #endregion

        #region Metodos
        #region VerCarrito
         
        #region EliminarItem
        /// <summary>
        /// Metodo que elimina un objeto que haya en el carrito del usuario en la Base de Datos
        /// </summary>
        /// <param name="tipoObjeto">Especifica si se borrara una matricula, un inventario o evento</param>
        /// <param name="objetoBorrar">El objeto en especifico a borrar</param>
        /// <param name="idUsuario">El usuario al que se alterara su carrito</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>
        public bool eliminarItem(int tipoObjeto, int objetoBorrar, Entidad parametro)
        {
            Persona laPersona;
            
            try
            {

                laPersona = (Persona)FabricaEntidades.ObtenerPersona();
                //Escribo en el logger la entrada a este metodo
               Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO, SqlDbType.Int,
                    laPersona.ID.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int,
                    objetoBorrar.ToString(), false);
                parametros.Add(elParametro);
                elParametro = new Parametro(RecursosBDModulo16.PARAMETRO_TIPO_ITEM, SqlDbType.Int,
                    tipoObjeto.ToString(), false);
                parametros.Add(elParametro);


                //Procedo a intentar eliminar el item en BD ejecutando el stored procedure
                BDConexion conexion = new BDConexion();
                conexion.EjecutarStoredProcedure(RecursosBDModulo16.PROCEDIMIENTO_ELIMINAR_ITEM, parametros);

                //Escribo en el logger la salida a este metodo
              Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;
            }

          
            catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ArgumentNullException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoVacioException(RecursosBDModulo16.CODIGO_EXCEPCION_ARGUMENTO_NULO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_ARGUMENTO_NULO, e);
            }
            catch (FormatException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoFormatoInvalidoException(RecursosBDModulo16.CODIGO_EXCEPCION_FORMATO_INVALIDO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_FORMATO_INVALIDO, e);
            }
            catch (OverflowException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ParseoEnSobrecargaException(RecursosBDModulo16.CODIGO_EXCEPCION_SOBRECARGA,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_SOBRECARGA, e);
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
                throw new ExceptionSKDConexionBD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            } 
        }



        public List<Entidad> ConsultarTodos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Evento elEvento;

            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo16.CONSULTAR_EVENTOS,
                    parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    elEvento = (Evento)laFabrica.ObtenerEvento();
                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                    elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elEvento.Descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();
                    elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    laLista.Add(elEvento);

                }

                return laLista;

            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }

        #endregion
         
        #endregion
        #endregion
    }
}
