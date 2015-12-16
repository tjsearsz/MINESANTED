using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatosSKD.IntefazDAO
{
    public interface IDao<Parametro>
    {
        void Agregar(Parametro parametro);
        void Modificar(Parametro parametro);
        void ConsultarXId(Parametro parametro);
        void ConsultarTodos();
    }
}
