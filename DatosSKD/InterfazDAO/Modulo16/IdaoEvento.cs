using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;


namespace DAO.InterfazDAO.Modulo16
{
    public interface IdaoEvento : Idao<Entidad, bool, Entidad>
    {

        List<Entidad> ListarEvento();
        Entidad DetallarEvento(int Id_evento);

    }
}
