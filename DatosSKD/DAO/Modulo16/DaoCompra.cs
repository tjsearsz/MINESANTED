using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using DominioSKD;
using ExcepcionesSKD;
using DAO.InterfazDAO;
using DatosSKD;

namespace DAO.Modulo16
{
    /// <summary>
    /// Clase que gestiona todo el proceso de las compras contra la Base de Datos
    /// </summary>
    public class DaoCompra : DAOGeneral, InterfazDAO.Modulo16.IdaoCompra
    {
        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase BDCompra
        /// </summary>
        public DaoCompra()
        {

        }
        #endregion

        #region Metodos


        /// <summary>
        /// Metodo que retorma una lista de compras por usuario
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lasfacturas que tiene el usuario logueado</returns>
        public List<Entidad> ListarCompra(int IdPersona)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            List<Compra> laListaDeCompra = new List<Compra>();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_ID_USUARIO, SqlDbType.Int, IdPersona.ToString(), false);
                parametros.Add(parametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.CONSULTAR_COMPRAS, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    Compra laCompra = new Compra();

                    laCompra.Com_id = int.Parse(row[RecursosBDModulo16.PARAMETRO_ID_COMPRA].ToString());
                    laCompra.Com_tipo_pago = row[RecursosBDModulo16.PARAMETRO_TIPO_PAGO].ToString();
                    laCompra.Com_fecha_compra = DateTime.Parse(row[RecursosBDModulo16.PARAMETRO_FECHA].ToString());
                    laCompra.Com_estado = row[RecursosBDModulo16.PARAMETRO_ESTADO_COMPRA].ToString();

                    laListaDeCompra.Add(laCompra);

                }

                return laListaDeCompra;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Metodo que obtiene la o las ultimas matriculas pagadas por una persona en Base de Datos
        /// </summary>
        /// /// <param name="idUsuario">El id del usuario el cual se desea saber las matriculas que pago</param>
        /// <returns>Una lista con los id de las matriculas</returns>
        public List<Entidad> MatriculasPagadas(int idUsuario)
        {
            //Variable que retorna la lista
            List<DominioSKD.Entidades.Modulo16.Matricula> listaMatriculas = new List<DominioSKD.Entidades.Modulo16.Matricula>();
            try
            {
                //Creo la lista de los parametros para el stored procedure y los anexo
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo16.PARAMETRO_USUARIO, System.Data.SqlDbType.Int,
                    idUsuario.ToString(), false);
                parametros.Add(parametro);

                //Creo la conexion y ejecuto el query
                BDConexion conexion = new BDConexion();
                DataTable dt = conexion.EjecutarStoredProcedureTuplas
                    (RecursosBDModulo16.PROCEDIMIENTO_MATRICULAS_PAGADAS, parametros);

                //asigno el ID a un objeto matricula
                foreach (DataRow row in dt.Rows)
                {
                    //Creo la matricula y le asigno el ID
                    DominioSKD.Entidades.Modulo16.Matricula matricula = new DominioSKD.Entidades.Modulo16.Matricula();
                    matricula.Identificador = row[RecursosBDModulo16.PARAMETRO_IDMATRICULA].ToString();

                    //Agrego a la lista
                    listaMatriculas.Add(matricula);
                }

                //Retorno la lista
                return listaMatriculas;
            }
            catch (SqlException e)
            {
                throw new ExceptionSKDConexionBD("", "", e);
            }
            catch (ParametroInvalidoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ExceptionSKDConexionBD("blabla", "blabla", e);
            }

        }
        #endregion

    }
}
