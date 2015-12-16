using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class RestriccionEvento
    {
        #region Atributos
        private int idRestEvento;
        private String descripcion;
        private int edadMinima;
        private int edadMaxima;
        private String sexo;
        private int idEvento;
        private String nombreEvento;

        private List<CintaSimple> listaCintas;
        #endregion

        #region Propiedades
        public int IdRestEvento
        {
            get { return idRestEvento; }
            set { idRestEvento = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String NombreEvento
        {
            get { return nombreEvento; }
            set { nombreEvento = value; }
        }

        public int EdadMinima
        {
            get { return edadMinima; }
            set { edadMinima = value; }
        }

        public int EdadMaxima
        {
            get { return edadMaxima; }
            set { edadMaxima = value; }
        }

        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public int IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        public List<CintaSimple> ListaCintas
        {
            get { return listaCintas; }
            set { listaCintas = value; }
        }
        #endregion

        #region Constructores
        public RestriccionEvento()
        {
            idRestEvento = 0;
            descripcion = String.Empty;
            edadMinima = 0;
            edadMaxima = 0;
            sexo = String.Empty;
            idEvento = 0;
            nombreEvento = String.Empty;

            listaCintas = null;

        }

        public RestriccionEvento(int elId, String laDescripcion, int laEdadMinima, int laEdadMaxima, String elSexo, int elIdEvento, String elNombreEvento)
        {
            idRestEvento = elId;
            descripcion = laDescripcion;
            edadMinima = laEdadMinima;
            edadMaxima = laEdadMaxima;
            sexo = elSexo;
            idEvento = elIdEvento;
            nombreEvento = elNombreEvento;

            listaCintas = null;

            //DateTime nacimiento = new DateTime(2000, 1, 25);
            //int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
        }
        #endregion
    }

    public class EventoSimple
    {
        #region Atributos
        private int idEvento;
        private String nombreEvento;
        #endregion

        #region Propiedades
        public int IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }

        public String NombreEvento
        {
            get { return nombreEvento; }
            set { nombreEvento = value; }
        }
        #endregion

        #region Constructores
        public EventoSimple()
        {
            idEvento = 0;
            nombreEvento = String.Empty;

        }

        public EventoSimple(int elId, String elNombre)
        {
            idEvento = elId;
            nombreEvento = elNombre;
        }
        #endregion
    }

    public class CintaSimple
    {
        #region Atributos
        private int idCinta;
        private String colorCinta;
        #endregion

        #region Propiedades
        public int IdCinta
        {
            get { return idCinta; }
            set { idCinta = value; }
        }

        public String ColorCinta
        {
            get { return colorCinta; }
            set { colorCinta = value; }
        }
        #endregion

        #region Constructores
        public CintaSimple()
        {
            idCinta = 0;
            colorCinta = String.Empty;

        }

        public CintaSimple(int elId, String elColor)
        {
            idCinta = elId;
            colorCinta = elColor;
        }
        #endregion
    }

    public class PersonaSimple
    {
        #region Atributos
        private int idPersona;
        #endregion

        #region Propiedades
        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        #endregion

        #region Constructores
        public PersonaSimple()
        {
            idPersona = 0;
        }

        public PersonaSimple(int elId)
        {
            idPersona = elId;
        }
        #endregion
    }

}