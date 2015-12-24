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
using DatosSKD.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD;
using DatosSKD.DAO.Modulo16;



namespace DatosSKD.Modulo16
{
    /// <summary>
    /// Clase que gestiona todo el proceso del carrito del usuario contra la Base de Datos
    /// </summary>
    public class DaoCarrito : DAOGeneral//, IdaoCarrito
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
        /// <summary>
        /// Metodo que obtiene todos los items de implementos en el carrito del usuario de la Base de Datos
        /// </summary>
        /// <param name="idUsuario">Usuario del que se desea ver los items del iventario agregados en carrito</param>
        /// <returns>Lista con todos los items del inventario que se encuentran en el carrito</returns>

        public List<Entidad> getImplemento(int idUsuario)
        {

            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista que sera la respuesta de la consulta
                List<Entidad> laLista = new List<Entidad>();

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_SELECCIONAR_ID_INVENTARIO, parametros);

                //Obtengo todos los ids que estan en carrito de los Inventario
                foreach (DataRow row in dt.Rows)
                {
                    //Me creo el Implemento
                    DominioSKD.Entidades.Modulo16.Implemento elImplemento = new DominioSKD.Entidades.Modulo16.Implemento();

                    //Preparo para obtener los datos de ese Inventario
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int,
                        row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString(), false);
                    parametros.Add(parametro);

                    //Seteamos el id del implemento
                    elImplemento.Id_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString());

                    //Obtengo la informacion de los implementos
                    conexion = new BDConexion();
                    DataTable dt2 = conexion.EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_INVENTARIO_ID, parametros);

                    //Por cada ID obtengo su informacion correspondiente
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        elImplemento.Imagen_implemento = row2[RecursosBDModulo16.PARAMETRO_IMAGEN].ToString();
                        elImplemento.Nombre_Implemento = row2[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                        elImplemento.Tipo_Implemento = row2[RecursosBDModulo16.PARAMETRO_TIPO].ToString();
                        elImplemento.Marca_Implemento = row2[RecursosBDModulo16.PARAMETRO_MARCA].ToString();
                        elImplemento.Precio_Implemento = int.Parse(
                            row2[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());

                        //Agrego a la lista
                        laLista.Add(elImplemento);
                    }


                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la lista
                return laLista;
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

        /// <summary>
        /// Metodo que obtiene tos los eventos en el carrito el usuario en la Base de Datos
        /// </summary>
        /// <param name="idUsuario">Usuario del que se desea ver los eventos agregados en carrito</param>
        /// <returns>Lista con todos los eventos que se encuentran en el carrito</returns>

        public List<Entidad> getEvento(int idUsuario)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista que sera la respuesta
                List<Entidad> laLista = new List<Entidad>();

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_SELECCIONAR_ID_EVENTO, parametros);

                //Obtengo todos los ids que estan en carrito de los eventos
                foreach (DataRow row in dt.Rows)
                {

                    //Preparo para obtener los datos de ese evento
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int,
                        row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString(), false);
                    parametros.Add(parametro);

                    //Obtengo la informacion de los eventos
                    conexion = new BDConexion();
                    DataTable dt2 = conexion.EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_EVENTO_ID, parametros);

                    //Por cada ID obtengo su informacion correspondiente
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        //Me creo el evento
                        Evento elEvento = new Evento(int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString()),
                            row2[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString(), null,
                            int.Parse(row2[RecursosBDModulo16.PARAMETRO_PRECIO].ToString()), null, null, null);

                        //Agrego a la lista
                        laLista.Add(elEvento);
                    }


                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la lista
                return laLista;
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
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ExceptionSKDConexionBD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
        }


        /// <summary>
        /// Metodo que obtiene todas las matriculas en el carrito del usuario de la Base de Datos
        /// </summary>
        /// <param name="idUsuario">Usuario del que se desea ver las matriculas agregadas en el carrito</param>
        /// <returns>Lista con todas las matriculas que se encuentran en el carrito</returns>

        public List<Entidad> getMatricula(int idUsuario)
        {

            try
            {
                //Escribo en el logger la entrada de este metodo
                List<Entidad> laLista = new List<Entidad>();

                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_SELECCIONAR_ID_MATRICULA, parametros);

                //Obtengo todos los ids que estan en carrito de los eventos
                foreach (DataRow row in dt.Rows)
                {

                    //Preparo para obtener los datos de ese evento
                    parametros = new List<Parametro>();
                    parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int,
                        row[RecursosBDModulo16.PARAMETRO_IDMATRICULA].ToString(), false);
                    parametros.Add(parametro);

                    //Obtengo la informacion de los eventos
                    conexion = new BDConexion();
                    DataTable dt2 = conexion.EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_MATRICULA_ID, parametros);

                    //Por cada ID obtengo su informacion correspondiente
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        //Me creo la matricula
                        Matricula laMatricula = new Matricula();
                        laMatricula.Id = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDMATRICULA].ToString());
                        laMatricula.Identificador = (row2[RecursosBDModulo16.aliasIdentificadorMatricula].ToString());
                        laMatricula.FechaCreacion = DateTime.Parse(row2[RecursosBDModulo16.aliasFechainicio].ToString());
                        laMatricula.UltimaFechaPago = DateTime.Parse(row2[RecursosBDModulo16.aliasFechatope].ToString());

                        laLista.Add(laMatricula);

                        //Agrego a la lista
                        laLista.Add(laMatricula);
                    }


                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la lista
                return laLista;
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
            catch (Exception e)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, e);
                throw new ExceptionSKDConexionBD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
        }
        #endregion
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
            FabricaEntidades laFabrica = new FabricaEntidades();

            try
            {

                laPersona = (Persona)laFabrica.ObtenerPersona();
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
        #endregion
        #region RegistrarPago
        /// <summary>
        /// Metodo que registra el pago de los productos existentes en el carrito de la base de datos
        /// La lista de datos actualmente no se usa, se deja asi para posibles futuros usos
        /// </summary>
        /// <param name="tipoPago">Indica cual de las formas se eligio para los pagos</param>
        /// <param name="datos">Todos los datos pertenecientes de ese tipo de pago</param>
        /// <param name="idUsuario">El usuario al que se alterara su carrito</param>
        /// <returns>Si la operacion fue exitosa o fallida</returns>
        public bool registrarPago(String tipoPago, List<int> datos, int idUsuario)
        {
            //Procedo a intentar registrar el pago en Base de Datos
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro();
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PAGO,
                    SqlDbType.VarChar, tipoPago, false);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure
                BDConexion conexion = new BDConexion();
                conexion.EjecutarStoredProcedure(RecursosBDModulo16.PROCEDIMIENTO_REGISTRAR_PAGO, parametros);

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
                throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
        }
        #endregion
        #region AgregarItem
        /// <summary>
        /// Metodo que agrega los implementos al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idPersona">el ID del usuario a modificar el carrito</param>
        /// <param name="idInventario">Todos los datos pertinentes de ese tipo de pago</param>
        /// <param name="cantidad">La cantidad que se agregaran de ese implemento</param>
        /// <param name="precio">El precio del implemento</param>
        /// <returns>True o False si la operacion fue exitosa o fallida</returns>
        public bool agregarInventarioaCarrito(int idPersona, int idInventario, int cantidad, int precio)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
                int respuesta = 0;
                bool exito = false;

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                    SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2,
                    SqlDbType.Int, idInventario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                    SqlDbType.Int, cantidad.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                        SqlDbType.Int, precio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                parametros.Add(parametro);


                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.StoreProcedureAgregarinventarioaCarrito, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la respuesta
                return exito;
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
                throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
        }

        /// <summary>
        /// Metodo que modifica la cantidad de implementos en el carrito de un Usuario en BD
        /// </summary>
        /// <param name="idUsuario">el ID del usuario a modificarle el carrito</param>
        /// <param name="idImplemento">el ID del Implemento a modificar en el carrito</param>
        /// <param name="cantidad">La cantidad a la cual se actualizara en el carrito</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool modificarCarritoImplemento(int idUsuario, int idImplemento, int cantidad)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
                int respuesta = 0;
                bool exito = false;

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                    SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2,
                    SqlDbType.Int, idImplemento.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                    SqlDbType.Int, cantidad.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.PROCEDIMIENTO_MODIFICAR_CANTIDAD_IMPLEMENTO, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la respuesta
                return exito;
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

        /// <summary>
        /// Metodo que agrega los eventos al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idPersona">Indica el Indentificador del usuario que esta asociado al evento</param>
        /// <param name="idEvento">Indica el Identificador del Evento</param>
        /// <param name="cantidad">Indica la cantidad que se estan agregando del evento</param>
        /// <param name="precio">Indica el precio del evento para este momento</param>
        /// <returns> True o False si la operacion fue exitosa o fallida</returns>
        /// <summary>
        public bool agregarEventoaCarrito(int idPersona, int idEvento, int cantidad, int precio)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Respuestas del metodo y del stored procedure
                bool exito = false;
                int respuesta = 0;

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro();
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                        SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDEVENTO,
                        SqlDbType.Int, idEvento.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                SqlDbType.Int, cantidad.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                        SqlDbType.Int, precio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.PROCEDIMIENTO_AGREGAR_EVENTO_CARRITO, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la respuesta
                return exito;
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

        /// <summary>
        /// Metodo que modifica la cantidad de eventos en el carrito de un Usuario en BD
        /// </summary>
        /// <param name="idUsuario">el ID del usuario a modificarle el carrito</param>
        /// <param name="idEvento">el ID del evento a modificar en el carrito</param>
        /// <param name="cantidad">La cantidad a la cual se actualizara en el carrito</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool modificarCarritoEvento(int idUsuario, int idEvento, int cantidad)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Respuestas del metodo y del stored procedure
                bool exito = false;
                int respuesta = 0;

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro();
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                        SqlDbType.Int, idUsuario.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDEVENTO,
                        SqlDbType.Int, idEvento.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                SqlDbType.Int, cantidad.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.PROCEDIMIENTO_MODIFICAR_CANTIDAD_IMPLEMENTO, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la respuesta
                return exito;
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

        /// <summary>
        /// Metodo que agrega las matriculas al carrito, en el ambiente de base de datos
        /// </summary>
        /// <param name="idUsuario">Indica el identificador del Usuario</param>
        /// <param name="idMatricula">Indica el Identificador de la Matricula</param>
        /// <returns>True o False si la operacion fue exitosa o fallida</returns>
        public bool agregarMatriculaaCarrito(int idPersona, int idMatricula, int cantidad, int precio)
        {
            try
            {
                //Escribo en el logger la entrada a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Respuestas del metodo y del stored procedure
                bool exito = false;
                int respuesta = 0;

                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro();
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                        SqlDbType.Int, idPersona.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDMATRICULA2,
                        SqlDbType.Int, idMatricula.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                SqlDbType.Int, cantidad.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                        SqlDbType.Int, precio.ToString(), false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                    SqlDbType.Int, respuesta.ToString(), true);
                parametros.Add(parametro);

                //Creo la conexion a Base de Datos y ejecuto el Stored Procedure esperando un resultado de una variable
                BDConexion conexion = new BDConexion();
                List<Resultado> result = conexion.EjecutarStoredProcedure
                    (RecursosBDModulo16.PROCEDIMIENTO_AGREGAR_MATRICULA_CARRITO, parametros);

                //Recorro cada una de las respuestas en la lista
                foreach (Resultado aux in result)
                {
                    //Si el valor retornado del Stored Procedure es 1 la operacion se realizo con exito
                    if (aux.valor == "1")
                        exito = true;
                }

                //Escribo en el logger la salida a este metodo
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                //Retorno la respuesta
                return exito;
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
        #endregion
        #endregion
    }
}
