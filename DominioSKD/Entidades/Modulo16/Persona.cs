using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DominioSKD.Entidades.Modulo16
{

    /// <summary>
    /// Enumeración para el sexo de una persona
    /// </summary>
    public enum Sexo { Femenino, Masculino }

    /// <summary>
    /// Enumeración para el tipo de sangre de una persona
    /// </summary>
    public enum Sangre { AP, AN, BP, BN, OP, ON, ABP, ABN }

    /// <summary>
    /// Clase que representa la información personal de una persona.
    /// </summary>
    public class Persona : Entidad
    {

        #region Atributos
        /// <summary>
        /// Identificador en base de datos
        /// </summary>
        private int _id;

        /// <summary>
        /// Nombre de la persona
        /// </summary>
        private String _nombre;

        /// <summary>
        /// Apellido de la persona
        /// </summary>
        private String _apellido;

        /// <summary>
        /// Nacionalidad de la persona
        /// </summary>
        private String _nacionalidad;

        /// <summary>
        /// Peso de la persona
        /// </summary>
        private Double _peso = 0;

        /// <summary>
        /// Estatura de la persona
        /// </summary>
        private Double _estatura = 0;

        /// <summary>
        /// Descripción de las alergias que padece
        /// la persona
        /// </summary>
        private String _alergias;

        /// <summary>
        /// Fecha de nacimiento de la persona
        /// </summary>
        private DateTime _fechaNacimiento;

        /// <summary>
        /// Lista de Correos para contactar a la persona
        /// </summary>
   //     private List<Correo> _correos = null;

        /// <summary>
        /// Lista de telefonos para contactar a la persona 
        /// </summary>
        private List<Telefono> _telefonos = null;

        /// <summary>
        /// Tipo de sangre de la persona
        /// </summary>
        public Sangre TipoSangre;

        /// <summary>
        /// Sexo de la persona
        /// </summary>
        public Sexo Sexo;

        /// <summary>
        /// Documento de identidad de la persona
        /// </summary>
        private DocumentoIdentidad _documentoID;

        /// <summary>
        /// Dirección de habiración de la persona
        /// </summary>
        private String _direccion;

        /// <summary>
        /// Persona que tiene asignado como contacto de emergencia.
        /// </summary>
        private Persona _contatoEmergencia;

        /// <summary>
        /// Persona que tiene asignado como contacto de emergencia.
        /// </summary>
        private List<Persona> _representados;

        /// <summary>
        /// Estado de la persona en el sistema.
        /// </summary>
        public Boolean Estado = false;

        /// <summary>
        /// id del Dojo de la persona
        /// </summary>
        private int _dojoPersona;

        /// <summary>
        /// Objeto Inscripcion
        /// </summary>
        private int _idInscripcion;


        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador en BD</param>
        public Persona(int id)
        {
            this._id = id;
        }

        public Persona()
        {
            this._id = -1;

        }

        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        #endregion

        #region Métodos
        public String Nombre
        {
            set { this._nombre = value; }
            get { return this._nombre; }
        }

        public String Apellido
        {
            set { this._apellido = value; }
            get { return this._apellido; }
        }

        public String Nacionalidad
        {
            set { this._nacionalidad = value; }
            get { return this._nacionalidad; }
        }

        public Double Peso
        {
            set { this._peso = value; }
            get { return this._peso; }
        }

        public Double Estatura
        {
            set { this._estatura = value; }
            get { return this._estatura; }
        }

        public String Alergias
        {
            set { this._alergias = value; }
            get { return this._alergias; }
        }

        public DateTime FechaNacimiento
        {
            set { this._fechaNacimiento = value; }
            get { return this._fechaNacimiento; }
        }

        public String Direccion
        {
            set { this._direccion = value; }
            get { return this._direccion; }
        }

        public Persona ContactoEmergencia
        {
            set { this._contatoEmergencia = value; }
            get { return this._contatoEmergencia; }
        }

        public int IdInscripcion
        {
            get { return _idInscripcion; }
            set { _idInscripcion = value; }
        }


        /// <summary>
        /// Agrega un teléfono a la lista, si no existe la
        /// lista genere una nueva
        /// </summary>
        /// <param name="tel">Objeto teléfono</param>
        public void agregarTelefono(Telefono tel)
        {
            if (this._telefonos == null)
                this._telefonos = new List<Telefono>();

            this._telefonos.Add(tel);
        }

        /// <summary>
        /// Agrega un correo a la lista, si no existe la
        /// lista genere una nueva
        /// </summary>
        /// <param name="main">Objeto Correo</param>
        /// <param name="primario"> True si es el correo principal</param>
      //  public void agregarEmail(Correo mail)
      //  {
         //   if (this._correos == null)
              //  this._correos = new List<Correo>();
          //  this._correos.Add(mail);
       // }

        public List<Telefono> Telefonos
        {
            get
            {
                return this._telefonos;
            }
            set
            {
                this._telefonos = value;
            }
        }

    //    public List<Correo> Correos
      //  {
        //    get
          //  {
            //    return this._correos;
            //}
            //set
           // {
             //   this._correos = value;
            //}
        //}

     /*   public Correo Correo
        {
            get
            {
                foreach (Correo ret in this._correos)
                {
                    if (ret.Primario)
                        return ret;
                }
                return null;
            }
        }*/

        /// <summary>
        /// Cálculo de edad de la persona. (Años)
        /// </summary>
        public float Edad
        {
            get
            {
                if (this.FechaNacimiento == null)
                    return 0;

                TimeSpan tiempo = DateTime.Now - this.FechaNacimiento;
                return tiempo.Days / 365;
            }
        }

        public void addRepresentado(Persona per)
        {
            if (this._representados == null)
                this._representados = new List<Persona>();

            this._representados.Add(per);
        }

        public List<Persona> Representados
        {
            set
            {
                this._representados = value;
            }
            get
            {
                return this._representados;
            }
        }

        public DocumentoIdentidad DocumentoID
        {
            set
            {
                this._documentoID = value;
            }
            get
            {
                return this._documentoID;
            }
        }
        public int DojoPersona
        {
            set
            {
                _dojoPersona = value;
            }
            get
            {
                return this._dojoPersona;
            }

        }
        #endregion
    }
}
