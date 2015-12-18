using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioSKD.Entidades.Modulo16;
namespace DominioSKD
{
    /// <summary>
    /// Persona que Un Atleta
    /// </summary>
    class Atleta : Persona
    {
        /// <summary>
        /// Matricula que tiene una persona en un dojo.
        /// </summary>
        private Matricula _matricula;
        /* TODO: Cintas y demas atributos del atleta
        private
         */

        #region Constructores
        public Atleta(Matricula matricula) : base()
        {
            this._matricula = matricula;
        }
        public Atleta(int id,Matricula matricula) : base(id)
        {
            this._matricula = matricula;
        }
        #endregion
    }
}
