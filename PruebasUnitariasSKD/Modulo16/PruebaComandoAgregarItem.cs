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
        private Comando<bool> PruebaComandoVacio;
        private Comando<bool> PruebaComandoVacio2;
        private ComandoAgregarItem pruebaComandoVacio3;
        private ComandoAgregarItem pruebaComandoVacio4;
        private Comando<bool> pruebaComandoImplemento1;
        private Comando<bool> pruebaComandoImplemento2;
        private Comando<bool> pruebaComandoImplemento3;
        private Comando<bool> pruebaComandoImplemento4;
        private Comando<bool> pruebaComandoEvento1;
        private Comando<bool> pruebaComandoEvento2;
        private Comando<bool> pruebaComandoEvento3;
        private Comando<bool> pruebaComandoEvento4;
        private Comando<bool> pruebaComandoMatricula1;
        private Comando<bool> pruebaComandoMatricula2;
        private Comando<bool> pruebaComandoMatricula3;
        private Comando<bool> pruebaComandoMatricula4;
        private Comando<List<Entidad>> eventos;
        private Entidad persona;
        private Entidad persona2;
        private Entidad persona3;
        private Implemento implemento;
        private Implemento implemento2;
        private List<Entidad> listaEventos;
        private Matricula matricula;
        private Matricula matricula2;
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
            
            //Dos matriculas distintas
            this.matricula = new Matricula();
            this.matricula.Id = 1;
            this.matricula.Costo = 5000;
            this.matricula2 = new Matricula();
            this.matricula2.Id = 2;
            this.matricula2.Costo = 4500;

            //Iniciamos los atributos para la prueba de vacio
            this.PruebaComandoVacio = FabricaComandos.CrearComandoAgregarItem();
            this.PruebaComandoVacio2 = FabricaComandos.CrearComandoAgregarItem(this.persona, this.implemento, 1, 10);
            this.pruebaComandoVacio3 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem();
            this.pruebaComandoVacio4 = (ComandoAgregarItem)FabricaComandos.CrearComandoAgregarItem
                (this.persona, this.implemento, 1, 10);

            //Diferentes valores para Agregar un Implemento
            this.pruebaComandoImplemento1 = FabricaComandos.CrearComandoAgregarItem
                (this.persona, this.implemento, 1, 10);
            
            this.pruebaComandoImplemento2 = FabricaComandos.CrearComandoAgregarItem
                (this.persona, this.implemento, 1, 11);
            
            this.pruebaComandoImplemento3 = FabricaComandos.CrearComandoAgregarItem
                (this.persona, this.implemento2, 1, 30);
            
            this.pruebaComandoImplemento4 = FabricaComandos.CrearComandoAgregarItem
                (this.persona, this.listaEventos[0], 2, 20);
            
            //Diferentes valores para Agregar un Evento
            this.pruebaComandoEvento1 = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.listaEventos[0], 2, 10);
            
            this.pruebaComandoEvento2 = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.listaEventos[0], 2, 11);
            
            this.pruebaComandoEvento3 = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.listaEventos[1], 2, 30);
           
            this.pruebaComandoEvento4 = FabricaComandos.CrearComandoAgregarItem
                (this.persona2, this.matricula, 3, 20);
            
            //Diferentes valores para Agregar una Matricula
            this.pruebaComandoMatricula1 = FabricaComandos.CrearComandoAgregarItem
                (this.persona3, this.matricula, 3, 10);
            
            this.pruebaComandoMatricula2 = FabricaComandos.CrearComandoAgregarItem
                (this.persona3, this.matricula, 3 , 11);
            
            this.pruebaComandoMatricula3 = FabricaComandos.CrearComandoAgregarItem
                (this.persona3, this.matricula, 3, 30);
            
            this.pruebaComandoMatricula4 = FabricaComandos.CrearComandoAgregarItem
                (this.persona3, this.implemento, 1, 20);
                       
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
            Assert.IsNotNull(this.pruebaComandoVacio4.Objeto);
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
            this.PruebaComandoVacio = null;
            this.PruebaComandoVacio2 = null;
            this.pruebaComandoVacio3 = null;
            this.pruebaComandoVacio4 = null;
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
        }
    }
}
