using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo16
{
    public class Implemento : Entidad
    {

        #region atributos
        private int id_implemento;
        private String nombre_implemento;
        private String tipo_implemento;
        private String marca_implemento;
        private String color_implemento;
        private String talla_implemento;
        private String imagen_implemento;
        private int cantidad_implemento;
        private int stock_minimo_implemento;
        private String estatus_implemento;
        private String descripcion_implemento;
        private double precio_implemento;
        private Dojo dojo;
        #endregion

        #region set_get_id_implemento
        public int Id_Implemento
        {
            get { return id_implemento; }

            set { id_implemento = value; }

        }
        #endregion

        #region set_get_nombre_implemento
        public String Nombre_Implemento
        {
            get { return nombre_implemento; }

            set { nombre_implemento = value; }

        }
        #endregion

        #region set_get_tipo_implemento
        public String Tipo_Implemento
        {
            get { return this.tipo_implemento; }

            set { this.tipo_implemento = value; }

        }
        #endregion

        #region set_get_marca_implemento
        public String Marca_Implemento
        {
            get { return this.marca_implemento; }

            set { this.marca_implemento = value; }

        }
        #endregion

        #region set_get_color_implemento
        public String Color_Implemento
        {
            get { return this.color_implemento; }

            set { this.color_implemento = value; }

        }
        #endregion

        #region set_get_talla_implemento
        public String Talla_Implemento
        {
            get { return this.talla_implemento; }

            set { this.talla_implemento = value; }

        }
        #endregion


        #region set_get_imagen_implemento
        public String Imagen_implemento
        {
            get { return imagen_implemento; }

            set { imagen_implemento = value; }

        }
        #endregion

        #region set_get_cantidad_implemento
        public int Cantida_implemento
        {
            get { return cantidad_implemento; }

            set { cantidad_implemento = value; }

        }
        #endregion

        #region set_get_stock_minimo_implemento
        public int Stock_Minimo_Implemento
        {
            get { return stock_minimo_implemento; }

            set { stock_minimo_implemento = value; }

        }
        #endregion

        #region set_get_dojo_implemento
        public Dojo Dojo_Implemento
        {
            get { return this.dojo; }

            set { dojo = value; }

        }
        #endregion

        #region set_get_Estatus_implemento
        public String Estatus_Implemento
        {
            get { return this.estatus_implemento; }

            set { estatus_implemento = value; }

        }
        #endregion

        #region set_get_Descripcion_implemento
        public String Descripcion_Implemento
        {
            get { return this.descripcion_implemento; }

            set { descripcion_implemento = value; }

        }
        #endregion


        #region set_get_Precio_implemento
        public double Precio_Implemento
        {
            get { return this.precio_implemento; }

            set { precio_implemento = value; }

        }
        #endregion

        #region Constructores de Implementos
        #region Constructor
        public Implemento(int id_implemento, String nombre_implemento, String tipo_implemento, String marca_implemento, String color_implemento, String talla_implemento, String imagen_implemento, int cantidad_implemento, int stock_minimo_implemento, String estatus_implemento, double precio_implemento, String descripcion_implemento, Dojo dojo)
        {
            this.id_implemento = id_implemento;
            this.nombre_implemento = nombre_implemento;
            this.tipo_implemento = tipo_implemento;
            this.marca_implemento = marca_implemento;
            this.color_implemento = color_implemento;
            this.talla_implemento = talla_implemento;
            this.imagen_implemento = imagen_implemento;
            this.stock_minimo_implemento = stock_minimo_implemento;
            this.estatus_implemento = estatus_implemento;
            this.cantidad_implemento = cantidad_implemento;
            this.descripcion_implemento = descripcion_implemento;
            this.precio_implemento = precio_implemento;
            this.dojo = dojo;
        }
        #endregion

        #region Constructor vacio
        public Implemento() { }

        #endregion

        #endregion


    }
}

