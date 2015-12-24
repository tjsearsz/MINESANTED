using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.FabricaDAO;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.InterfazDAO;

namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando para consultar la lista de todos los eventos
    /// </summary>
    public class ComandoConsultarTodosEventos : Comando<List<Entidad>>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">true</param>
        /// <returns>lista de Eventos</returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IdaoEvento daoEventos = laFabrica.ObtenerDaoEventos();

                return daoEventos.ConsultarTodos();
            }
            #region catches
            catch (Exception ex)
            {
                throw ex;
            }
            
            #endregion
        }
    }
}
