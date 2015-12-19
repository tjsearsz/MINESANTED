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
        public static Comando<Entidad, bool> crearComandoagregarEventoaCarrito()
        {
            return new ComanadoagregarEventoaCarrito();
        }

        public static Comando<Entidad, bool> CrearComandoagregarImplementoaCarrito()
        {
            return new ComandoagregarImplementoaCarrito();
        }

        public static Comando<Entidad, bool> CrearComandoagregarMatriculaaCarrito()
        {
            return new ComandoagregarMatriculaaCarrito();
        }

        public static Comando<Entidad, bool> CrearComandoeliminarItem()
        {
            return new ComandoeliminarItem();
        }
        public static Comando<Entidad, Entidad> CrearComandogetEvento()
        {
            return new ComandogetEvento();
        }

        public static Comando<Entidad, Entidad> CrearComandoGetImplemento()
        {
            return new ComandoGetImplemento();
        }

        public static Comando<Entidad, Entidad> CrearComandoGetMatricula()
        {
            return new ComandoGetMatricula();
        }

        public static Comando<Entidad, bool> CrearComandomodificarCarritoevento()
        {
            return new ComandomodificarCarritoevento();
        }

        public static Comando<Entidad, bool> CrearComandomodificarCarritoimplemento()
        {
            return new ComandomodificarCarritoimplemento();
        }


        public static Comando<Entidad, bool> CrearComandomodificarCarritomatricula()
        {
            return new ComandomodificarCarritomatricula();
        }


        public static Comando<Entidad, bool> CrearComandoregistrarpago()
        {
            return new Comandoregistrarpago();
        }



        #endregion


    }
}
