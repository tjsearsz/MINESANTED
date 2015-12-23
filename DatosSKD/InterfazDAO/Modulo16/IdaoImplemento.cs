using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.IntefazDAO;

namespace DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoImplemento : IDao<Entidad, bool>
    {

        Entidad detallarImplemento(Entidad idImplemento);
        List<Entidad> ListarInventario();



    }
}
