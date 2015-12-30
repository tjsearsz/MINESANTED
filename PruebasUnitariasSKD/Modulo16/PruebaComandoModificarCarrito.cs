using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba unitaria del Caso de Uso ModificarCarrito
    /// </summary>
    [TestFixture]
    public class PruebaComandoModificarCarrito
    {
        #region Atributos
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {

        }

        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {

        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comandOModificarCarrito para la cantidad de
        /// unidades de un item ya sea sin implementos o con estos y verificar el modificar de un implemento
        /// colocandole una cantidad que existe en stock
        /// </summary>
        [Test]
        public void PruebaModificarCarritosNormales()
        {

        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoModificarCarrito para verificar que no se
        /// pueda colocar una cantidad de implemento que no exista en ningun inventariop
        /// </summary>
        [Test]
        public void PruebaModificarCarritoImplementoExceso() 
        { 
        
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {

        }
    }
}
