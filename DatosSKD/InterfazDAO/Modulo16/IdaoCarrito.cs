﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosSKD;
using DominioSKD;

namespace DatosSKD.InterfazDAO.Modulo16
{
    /// <summary>
    /// Interface con la firma de metodos para el DAO de carrito
    /// </summary>
    public interface IdaoCarrito: IDao<Entidad,bool,Entidad>
    {
        /// <summary>
        /// Metodo para agregar un Item determinado en el carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La entidad que tendra el ID de la persona</param>
        /// <param name="objeto">La entidad que tendra el ID del objeto</param>
        /// <param name="tipoObjeto">indica el tipo de objeto en especifico que se esta manejando</param>
        /// <param name="cantidad">cantidad del item que se desea agregar</param>
        /// <returns>El exito o fallo del proceso</returns>
        bool agregarItem(Entidad persona, Entidad objeto, int tipoObjeto, int cantidad);

        /// <summary>
        /// Metodo para registrar el pago de los productos que hay en el carrito de una persona en la Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se adjudicara el pago</param>
        /// <param name="tipoPoago">El metodo de pago con el que se realizo la transaccion</param>
        /// <returns>El exito o fallo del proceso</returns>
        bool RegistrarPago(Entidad persona, string tipoPoago);

        // <summary>
        /// Metodo para modificar un Item determinado en el carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La entidad que tendra el ID de la persona</param>
        /// <param name="objeto">La entidad que tendra el ID del objeto</param>
        /// <param name="tipoObjeto">indica el tipo de objeto en especifico que se esta manejando</param>
        /// <param name="cantidad">cantidad del item que se desea en el carritor</param>
        /// <returns>El exito o fallo del proceso</returns>
        bool ModificarCarrito(Entidad persona, Entidad objeto, int tipoObjeto, int cantidad);

        /// <summary>
        /// Metodo que obtiene todos los implementos del carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se desea saber todos sus implementos</param>
        /// <returns>Lista cont todos los implementos de la persona</returns>
        Dictionary<Entidad, int> getImplemento(Entidad persona);

        /// <summary>
        /// Metodo que obtiene todos los eventos del carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se desea saber todos sus eventos</param>
        /// <returns>Lista cont todos los eventos de la persona</returns>
        Dictionary<Entidad, int> getEvento(Entidad persona);

        /// <summary>
        /// Metodo que obtiene todas las matriculas del carrito de una persona en Base de Datos
        /// </summary>
        /// <param name="persona">La persona a la que se desea saber todas sus matriculas</param>
        /// <returns>Lista cont todas las matriculas de la persona</returns>
        Dictionary<Entidad, int> getMatricula(Entidad persona);

        bool eliminarItem(int tipoObjeto, int objetoBorrar, Entidad parametro);        
  
    }
}
