using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioSKD;
using ComandosSKD.Modulo16;

namespace ComandosSKD.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 16
        public static Comando<Entidad> crearComandoagregarEventoaCarrito()
        {
            return new ComanadoagregarEventoaCarrito();
        }

        public static Comando<Entidad> CrearComandoagregarImplementoaCarrito()
        {
            return new ComandoagregarImplementoaCarrito();
        }

        public static Comando<Entidad> CrearComandoagregarMatriculaaCarrito()
        {
            return new ComandoagregarMatriculaaCarrito();
        }

        public static Comando<Entidad> CrearComandoeliminarItem()
        {
            return new ComandoeliminarItem();
        }
        public static Comando<Entidad> CrearComandogetEvento()
        {
            return new ComandogetEvento();
        }

        public static Comando<Entidad> CrearComandoGetImplemento()
        {
            return new ComandoGetImplemento();
        }

        public static Comando<Entidad> CrearComandoGetMatricula()
        {
            return new ComandoGetMatricula();
        }

        public static Comando<Entidad> CrearComandomodificarCarritoevento()
        {
            return new ComandomodificarCarritoevento();
        }

        public static Comando<Entidad> CrearComandomodificarCarritoimplemento()
        {
            return new ComandomodificarCarritoimplemento();
        }


        public static Comando<Entidad> CrearComandomodificarCarritomatricula()
        {
            return new ComandomodificarCarritomatricula();
        }


        public static Comando<Entidad> CrearComandoregistrarpago()
        {
            return new Comandoregistrarpago();
        }



        #endregion


    }
}
