using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.FabricaDAO;
using DominioSKD;


namespace LogicaNegociosSKD.Comandos.Modulo16
{
    /// <summary>
    /// Comando que ejecuta la accion de agregar un item al carrito
    /// </summary>
    public class ComandoAgregarItem : Comando<bool>
    {
        #region Atributos
        /// <summary>
        /// Atributos del Comando
        /// </summary>
        private Entidad persona;
        private Entidad objeto;
        private int tipoObjeto;
        private int cantidad;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio del comando
        /// </summary>
        public ComandoAgregarItem()
        {

        }

        /// <summary>
        /// Constructor del comando con todos los datos requeridos para agregar
        /// </summary>
        /// <param name="idUsuario">el ID del usuario al que se le agregaran items</param>
        /// <param name="tipoObjeto">el tipo de objeto que se esta agregando</param>
        /// <param name="objetoBorrar">el ID del objeto como tal</param>
        /// <param name="cantidad">la cantidad que se esta agregando del objeto</param>
        /// <param name="precio">el precio del objeto</param>
        public ComandoAgregarItem(Entidad persona, Entidad objeto, int tipoObjeto, int cantidad)
        {
            this.persona = persona;
            this.objeto = objeto;
            this.tipoObjeto = tipoObjeto;
            this.cantidad = cantidad;            
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo Persona
        /// </summary>
        public Entidad Persona
        {
            get
            {
                return this.persona;
            }

            set
            {
                this.persona = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo Objeto
        /// </summary>
        public Entidad Objeto
        {
            get
            {
                return this.objeto;
            }

            set
            {
                this.objeto = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo tipoObjeto
        /// </summary>
        public int TipoObjeto
        {
            get
            {
                return this.tipoObjeto;
            }

            set
            {
                this.tipoObjeto = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo Cantidad
        /// </summary>
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }        
        #endregion

        /// <summary>
        /// Metodo que ejecuta la accion de agregarItem
        /// </summary>
        /// <returns>el exito o fallo del proceso</returns>
        public override bool Ejecutar()
        {
            try
            {
                //Instancio el DAO de Carrito
                IdaoCarrito daoCarrito = FabricaDAOSqlServer.ObtenerdaoCarrito();

                //Ejecuto Agregar item y retorno el resultado
                return daoCarrito.agregarItem(persona,objeto,this.tipoObjeto,this.cantidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
