using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegociosSKD.Comandos.Modulo16;
using LogicaNegociosSKD.Comandos;
using DominioSKD.Entidades.Modulo16;
using DominioSKD;

namespace LogicaNegociosSKD.Comandos.Fabrica
{
   public class FabricaComandos
   {
       #region Modulo 16
       public static Comando<List<Entidad>> CrearComandoConsultarTodosEventos()
       {
           return new ComandoConsultarTodosEventos();
       }

       public static Comando<bool> CrearComandoeliminarItem()
       {
           return new ComandoeliminarItem();
       }



       #endregion
   }
}
