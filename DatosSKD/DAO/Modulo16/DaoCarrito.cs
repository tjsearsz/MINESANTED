using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;
using DominioSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using ExcepcionesSKD;
using ExcepcionesSKD.Modulo16;
using System.Data;

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
        #region AgregarItem
        /// <summary>
        /// Metodo que agrega un item al carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se le agregara el item al carrito</param>
        /// <param name="objeto">El item que se agregara como tal</param>
        /// <param name="tipoObjeto">El tipo de objeto al que nos estamos refiriendo como tal</param>
        /// <param name="cantidad">La cantidad del item que estamos agregando</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool agregarItem(Entidad persona, Entidad objeto, int tipoObjeto, int cantidad)
        {
            //Nos aseguramos que realmente sea una persona valida
            if (persona is Persona)
            {
                try
                {
                    //Escribo en el logger la entrada a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER,
                        System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
                    int respuesta = 0;
                    bool exito = false;
                    List<Resultado> result;

                    //Creo la lista de los parametros para el stored procedure y los anexo
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                        SqlDbType.Int, persona.Id.ToString(), false);
                    parametros.Add(parametro);

                    switch (tipoObjeto)
                    {
                        case 1:
                            //Si es un implemento
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2,
                            SqlDbType.Int, objeto.Id.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                                SqlDbType.Int, cantidad.ToString(), false);
                            parametros.Add(parametro);
                            Implemento elImplemento = objeto as Implemento;

                            //Lanzamos una excepcion si no es un implemento o si esta en vacio
                            if (elImplemento == null)
                                //De Igual Forma Aca
                                throw new ItemInvalidoException(RecursosBDModulo16.MENSAJE_EXCEPCION_ITEM_INVALIDO);

                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                                    SqlDbType.Int, elImplemento.Precio_Implemento.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                            SqlDbType.Int, respuesta.ToString(), true);
                            parametros.Add(parametro);

                            //Ejecuto la operacion a Base de Datos
                            result = EjecutarStoredProcedure
                                (RecursosBDModulo16.StoreProcedureAgregarinventarioaCarrito, parametros);
                            break;

                        case 2:
                            //Si es un Evento casteamos el objeto y lo tratamos como tal
                            Evento elEvento = objeto as Evento;

                            //Lanzamos una excepcion si no es un implemento o si esta en vacio
                            if (elEvento == null)
                                //De Igual Forma Aca
                                throw new ItemInvalidoException(RecursosBDModulo16.MENSAJE_EXCEPCION_ITEM_INVALIDO);

                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDEVENTO2,
                                SqlDbType.Int, elEvento.Id_evento.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                                SqlDbType.Int, cantidad.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                                    SqlDbType.Int, elEvento.Costo.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                            SqlDbType.Int, respuesta.ToString(), true);
                            parametros.Add(parametro);

                            //Ejecuto la operacion a Base de Datos
                            result = EjecutarStoredProcedure
                                (RecursosBDModulo16.PROCEDIMIENTO_AGREGAR_EVENTO_CARRITO, parametros);
                            break;

                        case 3:
                            //Si es una Matricula
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDMATRICULA2,
                                SqlDbType.Int, objeto.Id.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                                SqlDbType.Int, cantidad.ToString(), false);
                            parametros.Add(parametro);
                            Matricula laMatricula = objeto as Matricula;

                            //Lanzamos una excepcion si no es un implemento o si esta en vacio
                            if (laMatricula == null)
                                //De Igual Forma Aca
                                throw new ItemInvalidoException(RecursosBDModulo16.MENSAJE_EXCEPCION_ITEM_INVALIDO);

                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_PRECIO2,
                                    SqlDbType.Int, laMatricula.Costo.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                            SqlDbType.Int, respuesta.ToString(), true);
                            parametros.Add(parametro);

                            //Ejecuto la operacion a Base de Datos
                            result = EjecutarStoredProcedure
                                (RecursosBDModulo16.PROCEDIMIENTO_AGREGAR_MATRICULA_CARRITO, parametros);
                            break;

                        default:
                            //MEJORAR ESTA EXCEPTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            //Sino es ninguna de las opciones posibles lanzamos un error
                            throw new OpcionItemErroneoException(RecursosBDModulo16.MENSAJE_EXCEPTION_ITEM_ERRONEO);
                    }

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
            else
                //Arreglar tambien aqui
                throw new PersonaNoValidaException(RecursosBDModulo16.MENSAJE_EXCEPCION_PERSONA_INVALIDA);
         }
        #endregion

        #region VerCarrito
        /// <summary>
        /// Metodo que obtiene todos los items de implementos en el carrito del usuario de la Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la cual se desea ver su carrito</param>
        /// <returns>Lista de Implementos encontrados en el carrito de la persona</returns>
        public List<Entidad> getImplemento(Entidad persona)
        {
            if (persona is Persona)
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
                        SqlDbType.Int, persona.Id.ToString(), false);
                    parametros.Add(parametro);

                    //Ejecuto el Stored Procedure                    
                    DataTable dt = EjecutarStoredProcedureTuplas
                        (RecursosBDModulo16.PROCEDIMIENTO_SELECCIONAR_ID_INVENTARIO, parametros);

                    //Obtengo todos los ids que estan en carrito de los Inventario
                    foreach (DataRow row in dt.Rows)
                    {
                        //Me creo el Implemento
                        Implemento elImplemento = (Implemento)FabricaEntidades.ObtenerImplemento();

                        //Preparo para obtener los datos de ese Inventario
                        parametros = new List<Parametro>();
                        parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int,
                            row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString(), false);
                        parametros.Add(parametro);

                        //Seteamos el id del implemento
                        elImplemento.Id_Implemento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO].ToString());

                        //Obtengo la informacion de los implementos                        
                        DataTable dt2 = EjecutarStoredProcedureTuplas
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
            else throw new PersonaNoValidaException(RecursosBDModulo16.MENSAJE_EXCEPCION_PERSONA_INVALIDA);        
        }

        /// <summary>
        /// Metodo que obtiene todos los items de Eventos en el carrito del usuario de la Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la cual se desea ver su carrito</param>
        /// <returns>Lista de Eventos encontrados en el carrito de la persona</returns>
        public List<Entidad> getEvento(Entidad persona)
        {
            if (persona is Persona)
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
                        SqlDbType.Int, persona.Id.ToString(), false);
                    parametros.Add(parametro);

                    //Ejecuto el Stored Procedure
                    DataTable dt = EjecutarStoredProcedureTuplas
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
                        DataTable dt2 = EjecutarStoredProcedureTuplas
                            (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_EVENTO_ID, parametros);

                        //Por cada ID obtengo su informacion correspondiente
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            //Me creo el evento
                            FabricaEntidades fabrica = new FabricaEntidades();
                            Evento elEvento = (Evento)fabrica.ObtenerEvento();
                            elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                            elEvento.Nombre = row2[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                            elEvento.Costo = int.Parse(row2[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());

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
            else throw new PersonaNoValidaException(RecursosBDModulo16.MENSAJE_EXCEPCION_PERSONA_INVALIDA);       
        }

        /// <summary>
        /// Metodo que obtiene todos los items de Matriculas en el carrito del usuario de la Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la cual se desea ver su carrito</param>
        /// <returns>Lista de Matriculas encontradas en el carrito de la persona</returns>
        public List<Entidad> getMatricula(Entidad persona)
        {
            if (persona is Persona)
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
                        SqlDbType.Int, persona.Id.ToString(), false);
                    parametros.Add(parametro);

                    //Ejecuto el Stored Procedure                    
                    DataTable dt = EjecutarStoredProcedureTuplas
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
                        DataTable dt2 = EjecutarStoredProcedureTuplas
                            (RecursosBDModulo16.PROCEDIMIENTO_CONSULTAR_MATRICULA_ID, parametros);

                        //Por cada ID obtengo su informacion correspondiente
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            //Me creo la matricula
                            Matricula laMatricula = (Matricula)FabricaEntidades.ObtenerMatricula();
                            laMatricula.Id = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDMATRICULA].ToString());
                            laMatricula.Identificador = (row2[RecursosBDModulo16.aliasIdentificadorMatricula].ToString());
                            laMatricula.FechaCreacion = DateTime.Parse(row2[RecursosBDModulo16.aliasFechainicio].ToString());
                            laMatricula.UltimaFechaPago = DateTime.Parse(row2[RecursosBDModulo16.aliasFechatope].ToString());
                            
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
            else throw new PersonaNoValidaException(RecursosBDModulo16.MENSAJE_EXCEPCION_PERSONA_INVALIDA);            
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
                throw new ExceptionSKD(RecursosBDModulo16.CODIGO_EXCEPCION_GENERICO,
                    RecursosBDModulo16.MENSAJE_EXCEPCION_GENERICO, e);
            }
        }
        #endregion

        #region RegistrarPago
        /// <summary>
        /// Metodo que registra el pago de los productos de una persona en la Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se le adjudicara el pago</param>
        /// <param name="tipoPago">El tipo de pago con el que se realizo la transaccion</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool RegistrarPago(Entidad persona, String tipoPago)
        {
            //Nos aseguramos que realmente sea una persona valida
            if (persona is Persona)
            {
                //Procedo a intentar registrar el pago en Base de Datos
                try
                {
                    //Escribo en el logger la entrada a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

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
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                       RecursosBDModulo16.MENSAJE_SALIDA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Retorno la Respuesta
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
            else
                throw new PersonaNoValidaException(RecursosBDModulo16.MENSAJE_EXCEPCION_PERSONA_INVALIDA);
        }
        #endregion

        #region ModificarCarrito
        /// <summary>
        /// Metodo que modifica un item al carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se le modificara el item del carrito</param>
        /// <param name="objeto">El item que se modificara como tal</param>
        /// <param name="tipoObjeto">El tipo de objeto al que nos estamos refiriendo como tal</param>
        /// <param name="cantidad">La cantidad modificada del item</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool ModificarCarrito(Entidad persona, Entidad objeto, int tipoObjeto, int cantidad)
        {
            //Nos aseguramos que realmente sea una persona valida
            if (persona is Persona)
            {
                try
                {
                    //Escribo en el logger la entrada a este metodo
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        RecursosBDModulo16.MENSAJE_ENTRADA_LOGGER, System.Reflection.MethodBase.GetCurrentMethod().Name);

                    //Preparamos la respuesta del Stored procedure y el exito o fallo del proceso
                    int respuesta = 0;
                    bool exito = false;
                    List<Resultado> result;

                    //Creo la lista de los parametros para el stored procedure y los anexo
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_PERSONA,
                        SqlDbType.Int, persona.Id.ToString(), false);
                    parametros.Add(parametro);

                    //Determinamos que tipo de objeto es
                    switch (tipoObjeto)
                    {
                        case 1:
                            //Casteo el objeto a implemento
                            Implemento elImplemento = objeto as Implemento;

                            //Lanzamos una excepcion si no es un implemento o si esta en vacio
                            if (elImplemento == null)
                                //De Igual Forma Aca
                                throw new ItemInvalidoException(RecursosBDModulo16.MENSAJE_EXCEPCION_ITEM_INVALIDO);

                            //Si es un implemento
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDIMPLEMENTO2,
                                SqlDbType.Int, objeto.Id.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                                SqlDbType.Int, cantidad.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                                SqlDbType.Int, respuesta.ToString(), true);
                            parametros.Add(parametro);

                            //Ejecuto la operacion a Base de Datos
                            result = EjecutarStoredProcedure
                                (RecursosBDModulo16.PROCEDIMIENTO_MODIFICAR_CANTIDAD_IMPLEMENTO, parametros);
                            break;

                        case 2:
                            //Si es un Evento casteamos el objeto y lo tratamos como tal
                            Evento elEvento = objeto as Evento;

                            //Lanzamos una excepcion si no es un Evento o si esta en vacio
                            if (elEvento == null)
                                //De Igual Forma Aca
                                throw new ItemInvalidoException(RecursosBDModulo16.MENSAJE_EXCEPCION_ITEM_INVALIDO);

                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_IDEVENTO2,
                                SqlDbType.Int, elEvento.Id_evento.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_CANTIDAD,
                                SqlDbType.Int, cantidad.ToString(), false);
                            parametros.Add(parametro);
                            parametro = new Parametro(RecursosBDModulo16.PARAMETRO_EXITO,
                                SqlDbType.Int, respuesta.ToString(), true);
                            parametros.Add(parametro);

                            //Ejecuto la operacion a Base de Datos
                            result = EjecutarStoredProcedure
                                (RecursosBDModulo16.PROCEDIMIENTO_MODIFICAR_CANTIDAD_EVENTO, parametros);
                            break;

                        default:
                            //MEJORAR ESTA EXCEPTION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            //Sino es ninguna de las opciones posibles lanzamos un error
                            throw new OpcionItemErroneoException(RecursosBDModulo16.MENSAJE_EXCEPTION_ITEM_ERRONEO);
                    }

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
            else
                throw new PersonaNoValidaException(RecursosBDModulo16.MENSAJE_EXCEPCION_PERSONA_INVALIDA);
        }
        #endregion

        public List<Entidad> ConsultarTodos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Evento elEvento;

          //  try
         //   {
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
        
           // }
            #region catches
         /*   catch (Exception ex)
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
        #endregion       
    }
}