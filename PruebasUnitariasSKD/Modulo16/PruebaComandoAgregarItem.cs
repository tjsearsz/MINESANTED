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
        private ComandoAgregarItem pruebaComando;
        private ComandoAgregarItem pruebaComandoImplemento1;
        private ComandoAgregarItem pruebaComandoImplemento2;
        private ComandoAgregarItem pruebaComandoImplemento3;
        private ComandoAgregarItem pruebaComandoImplemento4;
        private ComandoAgregarItem pruebaComandoEvento1;
        private ComandoAgregarItem pruebaComandoEvento2;
        private ComandoAgregarItem pruebaComandoEvento3;
        private ComandoAgregarItem pruebaComandoEvento4;
        private ComandoAgregarItem pruebaComandoMatricula1;
        private ComandoAgregarItem pruebaComandoMatricula2;
        private ComandoAgregarItem pruebaComandoMatricula3;
        private ComandoAgregarItem pruebaComandoMatricula4;
        private Comando<List<Entidad>> eventos;
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
            this.persona = new Persona();
            this.persona.Id = 11;
            this.persona2 = new Persona();
            this.persona2.Id = 12;
            this.persona3 = new Persona();
            this.persona3.Id = 13;

            //Dos implementos distintos
            this.implemento =  new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;
            this.implemento2 = new Implemento();
            this.implemento2.Id = 2;
            this.implemento2.Precio_Implemento = 3000;

            //Eventos
            this.eventos = FabricaComandos.CrearComandoConsultarTodosEventos();
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

            //Obtengo el comando
            this.pruebaComando = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();

            //Diferentes valores para Agregar un Implemento
            this.pruebaComandoImplemento1 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoImplemento1.Persona = this.persona;
            this.pruebaComandoImplemento1.Objeto = this.implemento;
            this.pruebaComandoImplemento1.TipoObjeto = 1;
            this.pruebaComandoImplemento1.Cantidad = 10;

            this.pruebaComandoImplemento2 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoImplemento2.Persona = this.persona;
            this.pruebaComandoImplemento2.Objeto = this.implemento;
            this.pruebaComandoImplemento2.TipoObjeto = 1;
            this.pruebaComandoImplemento2.Cantidad = 11;

            this.pruebaComandoImplemento3 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoImplemento3.Persona = this.persona;
            this.pruebaComandoImplemento3.Objeto = this.implemento2;
            this.pruebaComandoImplemento3.TipoObjeto = 1;
            this.pruebaComandoImplemento3.Cantidad = 30;

            this.pruebaComandoImplemento4 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoImplemento4.Persona = this.persona;
            this.pruebaComandoImplemento4.Objeto = this.evento;
            this.pruebaComandoImplemento4.TipoObjeto = 2;
            this.pruebaComandoImplemento4.Cantidad = 20;

            //Diferentes valores para Agregar un Evento
            this.pruebaComandoEvento1 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoEvento1.Persona = this.persona2;
            this.pruebaComandoEvento1.Objeto = this.evento;
            this.pruebaComandoEvento1.TipoObjeto = 2;
            this.pruebaComandoEvento1.Cantidad = 10;

            this.pruebaComandoEvento2 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoEvento2.Persona = this.persona2;
            this.pruebaComandoEvento2.Objeto = this.evento;
            this.pruebaComandoEvento2.TipoObjeto = 2;
            this.pruebaComandoEvento2.Cantidad = 11;

            this.pruebaComandoEvento3 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoEvento3.Persona = this.persona2;
            this.pruebaComandoEvento3.Objeto = this.evento2;
            this.pruebaComandoEvento3.TipoObjeto = 2;
            this.pruebaComandoEvento3.Cantidad = 30;

            this.pruebaComandoEvento4 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoEvento4.Persona = this.persona2;
            this.pruebaComandoEvento4.Objeto = this.matricula;
            this.pruebaComandoEvento4.TipoObjeto = 3;
            this.pruebaComandoEvento4.Cantidad = 20;

            //Diferentes valores para Agregar una Matricula
            this.pruebaComandoMatricula1 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoMatricula1.Persona = this.persona3;
            this.pruebaComandoMatricula1.Objeto = this.matricula;
            this.pruebaComandoMatricula1.TipoObjeto = 3;
            this.pruebaComandoMatricula1.Cantidad = 10;

            this.pruebaComandoMatricula2 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoMatricula2.Persona = this.persona3;
            this.pruebaComandoMatricula2.Objeto = this.matricula;
            this.pruebaComandoMatricula2.TipoObjeto = 3;
            this.pruebaComandoMatricula2.Cantidad = 11;

            this.pruebaComandoMatricula3 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoMatricula3.Persona = this.persona3;
            this.pruebaComandoMatricula3.Objeto = this.matricula2;
            this.pruebaComandoMatricula3.TipoObjeto = 3;
            this.pruebaComandoMatricula3.Cantidad = 30;

            this.pruebaComandoMatricula4 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoMatricula4.Persona = this.persona3;
            this.pruebaComandoMatricula4.Objeto = this.implemento;
            this.pruebaComandoMatricula4.TipoObjeto = 1;
            this.pruebaComandoMatricula4.Cantidad = 20;
            
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
            Assert.IsTrue(this.pruebaComandoImplemento1.Ejecutar());

            //Agrego el mismo implemento pero con cantidad diferente
            Assert.IsTrue(this.pruebaComandoImplemento2.Ejecutar());

            //Agrego un implemento diferente
            Assert.IsTrue(this.pruebaComandoImplemento3.Ejecutar());

            //Agrego un item diferente al carrito
            Assert.IsTrue(this.pruebaComandoImplemento4.Ejecutar());
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del ComandoAgregarItem para agregar eventos
        /// </summary>
        [Test]
        public void pruebaAgregarEvento()
        {
            //Agrego un Evento al carrito vacio de una persona
            Assert.IsTrue(this.pruebaComandoEvento1.Ejecutar());

            //Agrego el mismo evento pero con cantidad diferente
            Assert.IsTrue(this.pruebaComandoEvento2.Ejecutar());

            //Agrego un evento diferente
            Assert.IsTrue(this.pruebaComandoEvento3.Ejecutar());

            //Agrego un item diferente al carrito
            Assert.IsTrue(this.pruebaComandoEvento4.Ejecutar());

        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comando AgregarItem para agregar matriculas
        /// </summary>
        [Test]
        public void PruebaAgregarMatricula()
        {
            //Agrego una matricula al carrito vacio de una persona
            Assert.IsTrue(this.pruebaComandoMatricula1.Ejecutar());

            //Agrego la misma matricula pero con cantidad diferente
            Assert.IsTrue(this.pruebaComandoMatricula2.Ejecutar());

            //Agrego una matricula diferente
            Assert.IsTrue(this.pruebaComandoMatricula3.Ejecutar());

            //Agrego un item diferente al carrito
            Assert.IsTrue(this.pruebaComandoMatricula4.Ejecutar());
        }

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.pruebaComando = null;
            this.pruebaComandoImplemento1 = null;
            this.pruebaComandoImplemento2 = null;
            this.pruebaComandoImplemento3 = null;
            this.pruebaComandoImplemento4 = null;
            this.pruebaComandoEvento1 = null;
            this.pruebaComandoEvento2 = null;
            this.pruebaComandoEvento3 = null;
            this.pruebaComandoEvento4 = null;
            this.pruebaComandoMatricula1 = null;
            this.pruebaComandoMatricula2 = null;
            this.pruebaComandoMatricula3 = null;
            this.pruebaComandoMatricula4 = null;
            this.eventos = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.implemento = null;
            this.implemento2 = null;
            this.listaEventos = null;
            this.matricula = null;
            this.matricula2 = null;
            this.evento = null;
            this.evento2 = null;
        }
    }
}
