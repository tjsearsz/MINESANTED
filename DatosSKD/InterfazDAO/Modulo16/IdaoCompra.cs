using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.IntefazDAO;

namespace DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoCompra : IDao<Entidad, List<Entidad>>
    {
        List<Entidad> ListarCompra(int idPersona);
        List<Entidad> MatriculasPagadas(int idPersona);

    }
}


