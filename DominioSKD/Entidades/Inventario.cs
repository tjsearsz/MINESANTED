using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo16;

namespace DominioSKD
{
    public class Inventario: Entidad
    {
        #region Atributos

        private int id_inventario;
        private int cantidad_total;
        private int id_implemento;
        private int id_dojo;
        private Implemento implemento;
        private List<Implemento> listaImplemento;

        #endregion

        #region Get y Set

        public int Id_inventario
        {
            get { return id_inventario; }
            set { id_inventario = value; }
        }

        public int Cantidad_total
        {
            get { return cantidad_total; }
            set { cantidad_total = value; }
        }

        public int Id_implemento
        {
            get { return id_implemento; }
            set { id_implemento = value; }
        }

        public int Id_dojo
        {
            get { return id_dojo; }
            set { id_dojo = value; }
        }

        public Implemento Implemento
        {
            get { return implemento; }
            set { implemento = value; }
        }

        public List<Implemento> ListaImplemento
        {
            get { return listaImplemento; }
            set { listaImplemento = value; }
        }

        #endregion

        #region Constructores

        public Inventario()
        {
            id_inventario = 0;
            cantidad_total = 0;
            id_implemento = 0;
            id_dojo = 0;
        }

        public Inventario(int inv_id, int inv_cantidad_total, int IMPLEMENTO_imp_id)
        {
            id_inventario = inv_id;
            cantidad_total = inv_cantidad_total;
            id_implemento = IMPLEMENTO_imp_id;

        }

        #endregion
    }
}
