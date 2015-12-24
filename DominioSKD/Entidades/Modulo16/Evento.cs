using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD.Entidades.Modulo16
{
    public class Evento : Entidad
    {
        #region Atributos

        private int id;
        private String nombre;
        private String descripcion;
        private float costo;
        private Persona persona;
        private Ubicacion ubicacion;
        private Categoria categoria;
        private TipoEvento tipoEvento;
        private Horario horario;
        private Boolean estado;

        #endregion

        #region Constructores

        public Evento(int id, String nombre, String descripcion, float costo, Boolean estado, Ubicacion ubicacion, Categoria categoria, TipoEvento tipoEvento, Horario horario)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.costo = costo;
            this.ubicacion = ubicacion;
            this.categoria = categoria;
            this.tipoEvento = tipoEvento;
            this.horario = horario;
            this.estado = estado;
        }

        public Evento(int id, String nombre, String descripcion, float costo, Boolean estado, Persona persona, Ubicacion ubicacion, Categoria categoria, TipoEvento tipoEvento, Horario horario)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.persona = persona;
            this.costo = costo;
            this.ubicacion = ubicacion;
            this.categoria = categoria;
            this.tipoEvento = tipoEvento;
            this.horario = horario;
            this.estado = estado;
        }

        public Evento(int id, String nombre, String descripcion, float costo, Ubicacion ubicacion, TipoEvento tipoEvento, Horario horario)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.costo = costo;
            this.ubicacion = ubicacion;
            this.tipoEvento = tipoEvento;
            this.horario = horario;
        }


        #region Constructor Modulo16
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Evento()
        {

        }
        #endregion


        #endregion

        #region Propiedades

        public int Id_evento
        {
            get { return id; }
            set { id = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Horario Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public Ubicacion Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }


        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public float Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public TipoEvento TipoEvento
        {
            get { return tipoEvento; }
            set { tipoEvento = value; }
        }

        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        #endregion

    }
}
