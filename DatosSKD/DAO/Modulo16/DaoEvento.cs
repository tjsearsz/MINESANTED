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
using DAO.InterfazDAO.Modulo16;
using DAO;
using DominioSKD.Fabrica;

namespace DAO.Modulo16
{
    public class DaoEvento : DAOGeneral, IdaoEvento
    {

        #region Metodos
        /// <summary>
        /// Metodo que retorma una lista de eventos existentes
        /// </summary>
        /// <param name=NONE>Este metodo no posee paso de parametros</param>
        /// <returns>Todo lo que tiene actualmente el inventario de eventos</returns>
        public List<DominioSKD.Entidades.Modulo16.Evento> ListarEvento()
        {
            BDConexion laConexion;
            List<DominioSKD.Entidades.Modulo16.Evento> laListaDeEvento = new List<DominioSKD.Entidades.Modulo16.Evento>();
            List<Parametro> parametros;

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();


                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.CONSULTAR_EVENTOS, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Entidades.Modulo16.Evento elEvento = new DominioSKD.Entidades.Modulo16.Evento();

                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                    elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elEvento.Descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();
                    elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    laListaDeEvento.Add(elEvento);

                }

                return laListaDeEvento;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        /// Metodo que devueve un tipoevento dado su id
        /// </summary>
        /// <param name="Id_evento">Indica el objeto a detallar</param>
        /// <returns>Retorna un evento en especifico con todos sus detalles</returns>
        public static DominioSKD.Entidades.Modulo16.Evento DetallarEvento(int Id_evento)
        {
            BDConexion laConexion;
            List<Parametro> parametros;
            Parametro elParametro = new Parametro();

            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();
                DominioSKD.Entidades.Modulo16.Evento elEvento = new DominioSKD.Entidades.Modulo16.Evento();

                elParametro = new Parametro(RecursosBDModulo16.PARAMETRO_ITEM, SqlDbType.Int, Id_evento.ToString(),
                                            false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.DETALLAR_EVENTO, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    elEvento.Id_evento = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDEVENTO].ToString());
                    elEvento.Nombre = row[RecursosBDModulo16.PARAMETRO_NOMBRE].ToString();
                    elEvento.Costo = int.Parse(row[RecursosBDModulo16.PARAMETRO_PRECIO].ToString());
                    elEvento.Descripcion = row[RecursosBDModulo16.PARAMETRO_DESCRIPCION].ToString();

                }
                return elEvento;

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        #endregion
    }
}

