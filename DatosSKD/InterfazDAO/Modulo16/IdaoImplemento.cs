using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DAO;

namespace DAO.InterfazDAO.Modulo16
{
    public interface IdaoImplemento : Idao<Entidad, bool, Entidad>
    {

        Entidad detallarImplemento(Entidad idImplemento);
        List<Entidad> ListarInventario();



    }
}
