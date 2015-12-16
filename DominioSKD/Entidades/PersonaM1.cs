using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class PersonaM1
    {
        #region atributos
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

        private String _documentoID;

        #endregion

        #region Propiedades
        public int _Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string _Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string _Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string _DocumentoID
        {
            get { return _documentoID; }
            set { _documentoID = value; }
        }
        #endregion

        #region Constructores
        public PersonaM1()
        {
            _Id = 0;
            _Nombre = "";
            _Apellido = "";
            _DocumentoID = "";

        }
        public PersonaM1(int id, string nombre, string apellido)
        {
            _Id = id;
            _Nombre = nombre;
            _Apellido = apellido;

        }
        public PersonaM1(int id)
        {
            _Id = id;
            _Nombre = "";
            _Apellido = "";


        }
        #endregion


    }
}
