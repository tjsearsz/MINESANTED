﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD;

namespace ComandosSKD
{
    public abstract class Comando<Parametro>
    {

        public abstract void Ejecutar(Parametro parametro);
    }
}
