using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioSKD;
using DominioSKD.Entidades.Modulo16;
using LogicaNegociosSKD.Comandos.Modulo16;
using LogicaNegociosSKD.Comandos;
using LogicaNegociosSKD.Comandos.Fabrica;


namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba unitaria del Caso de Uso Agregar Item
    /// </summary>
    [TestFixture]
    public class PruebaComandoAgregarItem
    {
        #region Atributos
        //Atributos pertinentes a usar
        private Comando<bool> Comando;
        private ComandoAgregarItem pruebaComando;
       // public Comando<List<Entidad>> eventos;
        private ComandoConsultarTodosEventos eventos;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Implemento implemento;
        private Implemento implemento2;
        private List<Entidad> listaEventos;
        private Matricula matricula;
        private Matricula matricula2;
        private Evento evento;
        private Evento evento2;
        #endregion

        /// <summary>
        /// Prepara todos los atributos que utilizaremos para probar
        /// </summary>
        [SetUp]
        public void Iniciar()
        {
            //La persona
            this.persona = new Persona(11);
            this.persona2 = new Persona(12);
            this.persona3 = new Persona(13);

            //Dos implementos distintos
            this.implemento =  new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;
            this.implemento2 = new Implemento();
            this.implemento2.Id = 2;
            this.implemento2.Precio_Implemento = 3000;

            //Eventos
           // this.eventos = FabricaComandos.CrearComandoConsultarTodosEventos();
            this.eventos = new ComandoConsultarTodosEventos();
            this.listaEventos = this.eventos.Ejecutar();
            this.evento = new Evento();
            this.evento.Id = 1;
            this.evento.Costo = 0;
            this.evento2 = new Evento();
            this.evento2.Id = 2;
            this.evento2.Costo = 2000;


            //Dos matriculas distintas
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;
            this.matricula2 = new Matricula();
            this.matricula2.Id = 2;
            this.matricula2.Costo = 4500;

            //Obtengo el comando y lo casteo
            this.Comando = FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComando = (ComandoAgregarItem)this.Comando;
                     
        }

        /// <summary>
        /// Prueba unitaria para asegurar que el comando no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.pruebaComando);
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoAgregarItem para agregar implementos
        /// </summary>
        [Test]
        public void pruebaAgregarImplemento()
        {
            //Agrego un implemento al carrito vacio de una persona
            this.pruebaComando.Persona = this.persona;
            this.pruebaComando.Objeto = this.implemento;
            this.pruebaComando.TipoObjeto = 1;
            this.pruebaComando.Cantidad = 10;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego el mismo implemento pero con cantidad diferente
            this.pruebaComando.Persona = this.persona;
            this.pruebaComando.Objeto = this.implemento;
            this.pruebaComando.TipoObjeto = 1;
            this.pruebaComando.Cantidad = 11;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego un implemento diferente
            this.pruebaComando.Persona = this.persona;
            this.pruebaComando.Objeto = this.implemento2;
            this.pruebaComando.TipoObjeto = 1;
            this.pruebaComando.Cantidad = 30;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego un item diferente al carrito
            this.pruebaComando.Persona = this.persona;
            this.pruebaComando.Objeto = this.evento;
            this.pruebaComando.TipoObjeto = 2;
            this.pruebaComando.Cantidad = 20;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoAgregarItem para agregar eventos
        /// </summary>
        [Test]
        public void pruebaAgregarEvento()
        {
            //Agrego un Evento al carrito vacio de una persona
            this.pruebaComando.Persona = this.persona2;
            this.pruebaComando.Objeto = this.evento;
            this.pruebaComando.TipoObjeto = 2;
            this.pruebaComando.Cantidad = 10;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego el mismo evento pero con cantidad diferente
            this.pruebaComando.Persona = this.persona2;
            this.pruebaComando.Objeto = this.evento;
            this.pruebaComando.TipoObjeto = 2;
            this.pruebaComando.Cantidad = 11;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego un evento diferente
            this.pruebaComando.Persona = this.persona2;
            this.pruebaComando.Objeto = this.evento2;
            this.pruebaComando.TipoObjeto = 2;
            this.pruebaComando.Cantidad = 30;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego un item diferente al carrito
            this.pruebaComando.Persona = this.persona2;
            this.pruebaComando.Objeto = this.matricula;
            this.pruebaComando.TipoObjeto = 3;
            this.pruebaComando.Cantidad = 20;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comando AgregarItem para agregar matriculas
        /// </summary>
        [Test]
        public void PruebaAgregarMatricula()
        {
            //Agrego una matricula al carrito vacio de una persona
            this.pruebaComando.Persona = this.persona3;
            this.pruebaComando.Objeto = this.matricula;
            this.pruebaComando.TipoObjeto = 3;
            this.pruebaComando.Cantidad = 10;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego la misma matricula pero con cantidad diferente
            this.pruebaComando.Persona = this.persona3;
            this.pruebaComando.Objeto = this.matricula;
            this.pruebaComando.TipoObjeto = 3;
            this.pruebaComando.Cantidad = 11;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego una matricula diferente
            this.pruebaComando.Persona = this.persona3;
            this.pruebaComando.Objeto = this.matricula2;
            this.pruebaComando.TipoObjeto = 3;
            this.pruebaComando.Cantidad = 30;
            Assert.IsTrue(this.pruebaComando.Ejecutar());

            //Agrego un item diferente al carrito
            this.pruebaComando.Persona = this.persona3;
            this.pruebaComando.Objeto = this.implemento;
            this.pruebaComando.TipoObjeto = 1;
            this.pruebaComando.Cantidad = 20;
            Assert.IsTrue(this.pruebaComando.Ejecutar());
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.pruebaComando = null;
            this.eventos = null;
            this.persona = null;
            this.implemento = null;
            this.implemento2 = null;
            this.listaEventos = null;
            this.matricula = null;
            this.matricula2 = null;
        }
    }
}
