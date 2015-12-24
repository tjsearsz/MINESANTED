using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.DAO.Modulo16;

namespace DatosSKD.FabricaDAO
{
   public class FabricaDAOSqlServer
   {
       #region Modulo 16
       public InterfazDAO.Modulo16.IdaoEvento ObtenerDaoEventos()
       {
           return new DatosSKD.DAO.Modulo16.DaoEvento();
       }

       #endregion
   }
}
