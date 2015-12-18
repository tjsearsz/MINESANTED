using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DAO;

namespace DAO.InterfazDAO.Modulo16
{
    public interface IdaoCompra : Idao<Entidad, bool>
    {
        List<Entidad> ListarCompra(int idPersona);
        List<Entidad> MatriculasPagadas(int idPersona);

    }
}


