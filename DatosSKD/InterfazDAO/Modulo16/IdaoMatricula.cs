using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;
using DatosSKD.InterfazDAO;
 

namespace DatosSKD.InterfazDAO.Modulo16
{
    public interface IdaoMatricula : IDao<Entidad>
    {
        List<Entidad> mostrarMensualidadesmorosas();

    }
}
