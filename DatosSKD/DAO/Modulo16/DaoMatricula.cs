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
using ExcepcionesSKD.Modulo16.ExcepcionesDeDatos;
using DatosSKD;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;



namespace DatosSKD.Modulo16
{
    public class DaoMatricula : DAOGeneral//, IdaoMatricula
    {


        public static List<DominioSKD.Entidades.Modulo16.Matricula> mostrarMensualidadesmorosas()
        {
            BDConexion laConexion;
            List<DominioSKD.Entidades.Modulo16.Matricula> laListaDeMatriculas = new List<DominioSKD.Entidades.Modulo16.Matricula>();
            List<Parametro> parametros;


            try
            {
                laConexion = new BDConexion();
                parametros = new List<Parametro>();

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(
                               RecursosBDModulo16.StoreProcedureConsultarMatriculas, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    DominioSKD.Entidades.Modulo16.Matricula laMatricula = new DominioSKD.Entidades.Modulo16.Matricula();

                    laMatricula.Id = int.Parse(row[RecursosBDModulo16.PARAMETRO_IDMATRICULA].ToString());
                    laMatricula.Identificador = (row[RecursosBDModulo16.aliasIdentificadorMatricula].ToString());
                    laMatricula.FechaCreacion = DateTime.Parse(row[RecursosBDModulo16.aliasFechainicio].ToString());
                    laMatricula.UltimaFechaPago = DateTime.Parse(row[RecursosBDModulo16.aliasFechatope].ToString());
                    laListaDeMatriculas.Add(laMatricula);

                }
                return laListaDeMatriculas;
            }

            catch (NullReferenceException ex)
            {

                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionNullReference,
                    RecursosBDModulo16.Mensaje_ExcepcionNullReference, ex);

            }

            catch (SqlException ex)
            {
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionSql,
                    RecursosBDModulo16.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                throw new ParametroIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionParametro,
                    RecursosBDModulo16.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                throw new AtributoIncorrectoException(RecursosBDModulo16.Codigo_ExcepcionAtributo,
                    RecursosBDModulo16.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                throw new BDMatriculaException(RecursosBDModulo16.Codigo_ExcepcionGeneral,
                   RecursosBDModulo16.Mensaje_ExcepcionGeneral, ex);

            }


        }




    }
}
