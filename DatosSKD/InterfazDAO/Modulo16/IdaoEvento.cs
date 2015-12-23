using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD;
using DatosSKD.IntefazDAO;


namespace DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoEvento : IDao<Entidad, bool>
    {

         bool ListarEvento();
    //    Entidad DetallarEvento(int Id_evento);

    }
}
