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

       /// <summary>
       /// Metodo de la fabrica que instancia el comando ComandoAgregarItem Vacio
       /// </summary>
       /// <returns>El ComandoAgregarItem vacio</returns>
       public static Comando<bool> CrearComandoAgregarItem()
       {
           return new ComandoAgregarItem();
       }

       /// <summary>
       /// Metodo de la fabrica que instancia el ComandoAgregarItem con sus datos llenos
       /// </summary>
       /// <param name="persona">La persona a la que se le agregara al carrito</param>
       /// <param name="objeto">el item que se agregara al carrit ode la persona</param>
       /// <param name="tipoObjeto">Indica a que tipo de item nos estamos refiriendo para Agregar</param>
       /// <param name="cantidad">la cantidad que se esta agregando del objeto</param>
       /// <returns>El ComandoAgregarItem con sus datos llenos</returns>
       public static Comando<bool> CrearComandoAgregarItem(Entidad persona, Entidad objeto, int tipoObjeto
           , int cantidad)
       {
           return new ComandoAgregarItem(persona, objeto, tipoObjeto, cantidad);
       }

       /// <summary>
       /// Metodo de la fabrica que instancia el comando ComandoRegistrarPago Vacio
       /// </summary>
       /// <returns>El ComandoRegistrarPago vacio</returns>
       public static Comando<bool> CrearComandoRegistrarPago()
       {
           return new ComandoRegistrarPago();
       }

       /// <summary>
       /// Metodo de la fabrica que instancia el ComandoRegistraPago con sus datos llenos
       /// </summary>
       /// <param name="persona">La persona a la cual se le adjudicara la transaccion</param>
       /// <param name="tipoPago">el tipo de pago que la persona realizo</param>
       /// <returns>El ComandoRegistrarPago con sus datos llenos</returns>
       public static Comando<bool> CrearComandoRegistrarPago(Entidad persona, String tipoPago)
       {
           return new ComandoRegistrarPago(persona, tipoPago);
       }

       public static Comando<bool> CrearComandoeliminarItem()
       {
           return new ComandoeliminarItem();
       }
       #endregion
   }
}
