using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LogicaNegociosSKD.Comandos.Modulo16;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD.Comandos.Fabrica;
using DominioSKD.Fabrica;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba unitaria del Caso de Uso de Ver Carrito
    /// </summary>
    [TestFixture]
    public class PruebaComandoVerCarrito
    {
        #region Atributos
        private Comando<Entidad> PruebaComandoVacio;
        private Comando<Entidad> PruebaComandoVacio2;
        private Comando<Entidad> PruebaVerSoloImplemento;
        private Comando<Entidad> PruebaVerSoloEvento;
        private Comando<Entidad> PruebaVerSoloMatricula;
        private Comando<Entidad> PruebaVerTodo;
        private ComandoVerCarrito pruebaComandoVacio3;
        private ComandoVerCarrito pruebaComandoVacio4;
        private Comando<bool> ComandoAgregarItem;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Entidad persona4;
        private Implemento implemento;
        private List<Entidad> listaEventos;
        private Comando<List<Entidad>> eventos;
        private Matricula matricula;
        private Carrito Carrito;
        private Evento evento;
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //Las Personas
            this.persona = FabricaEntidades.ObtenerPersona();
            this.persona.Id = 20;
            this.persona2 = FabricaEntidades.ObtenerPersona();
            this.persona2.Id = 21;
            this.persona3 = FabricaEntidades.ObtenerPersona();
            this.persona3.Id = 22;
            this.persona4 = FabricaEntidades.ObtenerPersona();
            this.persona4.Id = 23;

            //Implemento
            this.implemento =  new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;

            //Eventos
            this.eventos = FabricaComandos.CrearComandoConsultarTodosEventos();
            this.listaEventos = this.eventos.Ejecutar();

            //Matricula
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;

            //Iniciamos los atributos para la prueba de vacio
            this.PruebaComandoVacio = FabricaComandos.CrearComandoVerCarrito();
            this.PruebaComandoVacio2 = FabricaComandos.CrearComandoVerCarrito(this.persona);
            this.pruebaComandoVacio3 = (ComandoVerCarrito)FabricaComandos.CrearComandoVerCarrito();
            this.pruebaComandoVacio4 = (ComandoVerCarrito)FabricaComandos.CrearComandoVerCarrito(this.persona);

            //Carrito Cuando hay solo Implementos
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona, this.implemento, 1, 5);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerSoloImplemento = FabricaComandos.CrearComandoVerCarrito(this.persona);

            //Carrito Cuando hay solo Eventos
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona2, this.listaEventos[0], 2, 6);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerSoloEvento = FabricaComandos.CrearComandoVerCarrito(this.persona2);

            //Carrito Cuando hay solo Matriculas
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona3, this.matricula, 3, 1);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerSoloMatricula = FabricaComandos.CrearComandoVerCarrito(this.persona3);

            //Carrito Cuando hay Implementos, Eventos y Matriculas
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.implemento, 1, 5);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.listaEventos[0], 2, 6);
            this.ComandoAgregarItem.Ejecutar();
            this.ComandoAgregarItem = FabricaComandos.CrearComandoAgregarItem(this.persona4, this.matricula, 3, 1);
            this.ComandoAgregarItem.Ejecutar();
            this.PruebaVerTodo = FabricaComandos.CrearComandoVerCarrito(this.persona4);
        }

        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.PruebaComandoVacio);
            Assert.IsNotNull(this.PruebaComandoVacio2);
            Assert.IsNotNull(this.pruebaComandoVacio3);
            Assert.IsNotNull(this.pruebaComandoVacio4.Persona);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene implementos
        /// </summary>
        [Test]
        public void PruebaCarritoSoloImplementos()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerSoloImplemento.Ejecutar();

            //Revisamos que solo hayan Implementos y efectivamente haya solo uno agregado
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 1);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 0);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 0);

            //Obtenemos el implemento y verificamos sus valores
            this.implemento = this.Carrito.ListaImplemento[0] as Implemento;
            Assert.AreEqual(this.implemento.Id_Implemento, 1);
            Assert.AreEqual(this.implemento.Precio_Implemento, 4500);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene Eventos
        /// </summary>
        [Test]
        public void PruebaCarritoSoloEventos()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerSoloEvento.Ejecutar();            

            //Revisamos que solo hayan Eventos y efectivamente haya solo uno agregado
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 0);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 1);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 0);

            //Obtenemos el Evento y verificamos sus valores
            this.evento = this.Carrito.Listaevento[0] as Evento;
            Assert.AreEqual(this.evento.Id_evento, 1);
            Assert.AreEqual(this.evento.Costo, 0);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene Matriculas
        /// </summary>
        [Test]
        public void PruebaCarritoSoloMatriculas()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerSoloMatricula.Ejecutar();

            //Revisamos que solo hayan Matriculas y efectivamente haya solo una agregada
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 0);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 0);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 1);

            //Obtenemos la Matricula y verificamos sus valores
            this.matricula = this.Carrito.Listamatricula[0] as Matricula;
            Assert.AreEqual(this.matricula.Id, 1);
            //Assert.AreEqual(this.matricula.Costo, 5000);
            //PILAS CON EL COSTO ARREGLAR
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que tiene
        /// implementos, eventos y matriculas
        /// </summary>
        [Test]
        public void PruebaCarritoVariosItems()
        {
            //Ejecutamos el comando y casteamos
            this.Carrito = (Carrito)this.PruebaVerTodo.Ejecutar();

            /*Revisamos que hayan Implementos, Eventos y matriculas, ademas,
              que efectivamente haya solo uno agregado de cada uno de ellos*/
            Assert.IsTrue(this.Carrito.ListaImplemento.Count == 1);
            Assert.IsTrue(this.Carrito.Listaevento.Count == 1);
            Assert.IsTrue(this.Carrito.Listamatricula.Count == 1);

            //Obtenemos los items y verificamos sus valores            
            this.implemento = this.Carrito.ListaImplemento[0] as Implemento;
            Assert.AreEqual(this.implemento.Id_Implemento, 1);
            Assert.AreEqual(this.implemento.Precio_Implemento, 4500);

            this.evento = this.Carrito.Listaevento[0] as Evento;
            Assert.AreEqual(this.evento.Id_evento, 1);
            Assert.AreEqual(this.evento.Costo, 0);

            this.matricula = this.Carrito.Listamatricula[0] as Matricula;
            Assert.AreEqual(this.matricula.Id, 1);
            //Assert.AreEqual(this.matricula.Costo, 5000);
            //PILAS CON EL COSTO ARREGLAR
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.PruebaVerSoloImplemento = null;
            this.PruebaVerSoloEvento = null;
            this.PruebaVerSoloMatricula = null;
            this.PruebaVerTodo = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
            this.ComandoAgregarItem = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.persona4 = null;
            this.implemento = null;
            this.listaEventos = null;
            this.eventos = null;
            this.matricula = null;
            this.Carrito = null;
            this.evento = null;
        }
    }
}
