using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo16;
using DominioSKD;
using System.Data;
using DominioSKD.Entidades.Modulo16;


namespace DatosSKD.DAO.Modulo16
{
    /// <summary>
    /// Dao para el manejo del carrito en Base de Datos
    /// </summary>
    public class DaoCarrito: DAOGeneral, IdaoCarrito
    {
        #region Constructor
        /// <summary>
        /// Constructor vacio del DAO
        /// </summary>
        public DaoCarrito()
        {

        }
        #endregion

        #region Metodos
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que agrega un item al carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se le agregara el item al carrito</param>
        /// <param name="objeto">El item que se agregara como tal</param>
        /// <param name="tipoObjeto">El tipo de objeto que nos estamos refiriendo como tal</param>
        /// <param name="cantidad">La cantidad del item que estamos agregando</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool agregarItem(Entidad persona, Entidad objeto, int tipoObjeto, int cantidad)
        {
           // try
          //  {
                //Escribo en el logger la entrada a este metodo
              //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 //   RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
                int respuesta = 0;
                bool exito = false;
                List<Resultado> result;

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                    SqlDbType.Int, persona.Id.ToString(), false);
                parametros.Add(parametro);
                
                //Determinamos que tipo de objeto es, casteamos para obtener su precio y lo agregamos al parametro
                if (tipoObjeto == 1)
                {
                    //Si es un implemento
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2,
                    SqlDbType.Int, objeto.Id.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                        SqlDbType.Int, cantidad.ToString(), false);
                    parametros.Add(parametro);
                    Implemento aux = objeto as Implemento;
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                            SqlDbType.Int, aux.Precio_Implemento.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                    parametros.Add(parametro);

                    //Ejecuto la operacion a Base de Datos
                    result = EjecutarStoredProcedure
                        (RecursosBDModulo16.StoreProcedureAgregarinventarioaCarrito, parametros);
                }
                else if (tipoObjeto == 2)
                {
                    //Si es un Evento
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDEVENTO2,
                        SqlDbType.Int, objeto.Id.ToString(), false);
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                        SqlDbType.Int, cantidad.ToString(), false);
                    parametros.Add(parametro);
                    Evento aux = objeto as Evento;
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                            SqlDbType.Int, aux.Costo.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                    parametros.Add(parametro);

                    //Ejecuto la operacion a Base de Datos
                    result = EjecutarStoredProcedure
                        (RecursosBDModulo16.StoreProcedureAgregareventoaCarrito, parametros);
                }
                else
                {
                    //Si es una Matricula
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDMATRICULA2,
                        SqlDbType.Int, objeto.Id.ToString(), false);
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                        SqlDbType.Int, cantidad.ToString(), false);
                    parametros.Add(parametro);
                    Matricula aux = objeto as Matricula;
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                            SqlDbType.Int, aux.Costo.ToString(), false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                    parametros.Add(parametro);

                    //Ejecuto la operacion a Base de Datos
                    result = EjecutarStoredProcedure
                        (RecursosBDModulo16.StoreProcedureAgregarmatriculaaCarrito, parametros);
                }
                                
                 //Recorro cada una de las respuestas en la lista
                 foreach (Resultado aux in result)
                 {
                     //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                     if (aux.valor == "1")
                         exito = true;
                 }

                 //Escribo en el logger la salida a este metodo
                // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    // RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                 //Retorno la respuesta
                 return exito;
           // }
           /* catch (LoggerException e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw e;
            }
            catch (ArgumentNullException e)
            {
              //  Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
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
                throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
            catch(Exception e)
            {
                throw e;
            }*/
        }

        /// <summary>
        /// Metodo que registra el pago de los productos de una persona en la Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se le adjudicara el pago</param>
        /// <param name="tipoPago">El tipo de pago con el que se realizo la transaccion</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool RegistrarPago(Entidad persona, String tipoPago)
        {
            //Procedo a intentar registrar el pago en Base de Datos
           // try
           // {
                //Escribo en el logger la entrada a este metodo
              //  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
               //     RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);
                //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
                int respuesta = 0;
                bool exito = false;
                List<Resultado> result;

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro();
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, persona.Id.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PAGO,
                    SqlDbType.VarChar, tipoPago, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                parametros.Add(parametro);

                //Ejecuto el Stored Procedure
                result = EjecutarStoredProcedure(RecursosBDModulo16.PROCEDIMIENTO_REGISTRAR_PAGO, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Escribo en el logger la salida a este metodo
               // Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                 //   RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la Respuesta
                return exito;
          //  }
           /* catch (LoggerException e)
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
                throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }*/
        }
        #endregion
    }
}
