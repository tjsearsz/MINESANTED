using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatosSKD.IntefazDAO
{
    public interface IDao<Parametro, Resultado>
    {
        Resultado Agregar(Parametro parametro);
        Resultado Modificar(Parametro parametro);
        Resultado ConsultarXId(Parametro parametro);
        List<Resultado> ConsultarTodos();
    }
}
