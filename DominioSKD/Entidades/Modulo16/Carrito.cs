﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DominioSKD.Entidades.Modulo16
{
    /// <summary>
    /// Clase Carrito con sus constructores y atributos
    /// </summary>
    public class Carrito : Entidad
    {
        #region Atributos
        /// <summary>
        /// Atributos de la clase Carrito
        /// </summary>
        List<Entidad> listaImplemento;
        List<Entidad> listaEvento;
        List<Entidad> listaMatricula;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo listaInventario
        /// </summary>
        public List<Entidad> ListaImplemento
        {
            get
            {
                return this.listaImplemento;
            }
            set
            {
                this.listaImplemento = value;
            }

        }

        /// <summary>
        /// Propiedad del atributo listaEvento
        /// </summary>
        public List<Entidad> Listaevento
        {
            get
            {
                return this.listaEvento;
            }
            set
            {
                this.listaEvento = value;
            }
        }

        /// <summary>
        /// Propiedad del atributo listaMatricula
        /// </summary>
        public List<Entidad> Listamatricula
        {
            get
            {
                return this.listaMatricula;
            }
            set
            {
                this.listaMatricula = value;
            }
        }


        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public Carrito()
        {

            listaImplemento = null;
            listaEvento = null;
            listaMatricula = null;

        }

        /// <summary>
        /// Constructor con todos los datos requeridos de la clase
        /// </summary>
        /// <param name="implementos">Lista con todos los implementos del carrito</param>
        /// <param name="eventos">Lista con todos los eventos del carrito</param>
        /// <param name="matriculas">Lista con todas las matriculas del carrito</param>
        public Carrito(List<Entidad> implementos, List<Entidad> eventos, List<Entidad> matriculas)
        {
            this.listaImplemento = implementos;
            this.listaEvento = eventos;
            this.listaMatricula = matriculas;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que elimina un item especifico del carrito del usuario
        /// </summary>
        /// <param name="tipoObjeto">Especifica si se trata de un inventario, matricula o evento</param>
        /// <param name="objetoBorrar">Elimina el objeto en especifico del carrito</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool eliminarItem(int tipoObjeto, int objetoBorrar)
        {
            //Preparamos la respuesta del proceso
            bool respuesta = false;

            //Si queremos borrar un implemento 
            if (tipoObjeto == 1)
            {
                //Buscamos en la lista ese implemento que tenga ese id y borramos
                foreach (Implemento aux in this.ListaImplemento.Reverse<Entidad>())
                    if (aux.Id_Implemento == objetoBorrar)
                        this.ListaImplemento.Remove(aux);
                respuesta = true;
            }
            //Si queremos borrar una matricula
            else if (tipoObjeto == 2)
            {
                //Buscamos en la lista esa matricula que tenga ese id y borramos
                foreach (Matricula aux2 in this.listaMatricula.Reverse<Entidad>())
                    if (aux2.ID == objetoBorrar)
                        this.listaMatricula.Remove(aux2);
                respuesta = true;
            }
            //Si queremos borrar un evento
            else
            {
                //Buscamos en la lista ese evento que tenga ese id y borramos
                foreach (Evento aux3 in this.listaEvento.Reverse<Entidad>())
                    if (aux3.Id_evento == objetoBorrar)
                        this.listaEvento.Remove(aux3);
                respuesta = true;
            }

            //Retornamos la respuesta
            return respuesta;
        }

        /// <summary>
        /// Borra todos los items que existan en el carrito
        /// </summary>
        /// <returns>El exito o fallo del proceso</returns>
        public bool limpiar()
        {
            this.listaImplemento.Clear();
            this.listaEvento.Clear();
            this.listaMatricula.Clear();
            return true;
        }
        #endregion
    }
}
