using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo16;

namespace DominioSKD
{
    /// <summary>
    /// Parte de la clase Compra que se encarga de las necesidades de Modulo de Inventario
    /// </summary>
    public partial class Compra
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Compra
        /// </summary>
        private List<Matricula> matriculasPagadas;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo inventarioActualizado
        /// </summary>
        public List<Matricula> MatriculasPagadas
        {
            get
            {
                return this.matriculasPagadas;
            }
            set
            {
                this.matriculasPagadas = value;
            }
        }
        #endregion

    }
}
