using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos
{
    public abstract class Comando<Parametro>
    {
        public abstract Parametro Ejecutar();
    }
}
