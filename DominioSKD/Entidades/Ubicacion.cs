using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioSKD
{
    public class Ubicacion
    {
        #region atributos
        private int id_ubicacion;
        private String latitud;
        private String longitud;
        private String ciudad;
        private String estado;
        private String direccion;
        #endregion

        #region propiedades
        public int Id_ubicacion
        {
            get { return id_ubicacion; }
            set { id_ubicacion = value; }
        }

        public String Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }

        public String Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        public String Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        #endregion

        public Ubicacion()
        {
            id_ubicacion = 0;
            latitud = "";
            longitud = "";
            ciudad = "";
            estado = "";
            direccion = "";
        }

        public Ubicacion(String laLat, String laLon, String laCiudad, String elEstado, String LaDir)
        {
            latitud = laLat;
            longitud = laLon;
            ciudad = laCiudad;
            estado = elEstado;
            direccion = LaDir;
        }

        public Ubicacion(int elId, String laLat, String laLon, String laCiudad, String elEstado, String LaDir)
        {
            id_ubicacion = elId;
            latitud = laLat;
            longitud = laLon;
            ciudad = laCiudad;
            estado = elEstado;
            direccion = LaDir;
        }

        public Ubicacion(int elId, String laCiudad, String elEstado)
        {
            id_ubicacion = elId;
            ciudad = laCiudad;
            estado = elEstado;
        }


    }
}
