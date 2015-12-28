using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosSKD.DAO.Modulo16;
using DominioSKD.Entidades.Modulo16;
using DominioSKD;
using DatosSKD.FabricaDAO;
using DatosSKD.InterfazDAO.Modulo16;
using DatosSKD.DAO.Modulo16;

namespace PruebasUnitariasSKD.Modulo16
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre el DAO de Carrito
    /// </summary>
    [TestFixture]
    public class PruebaDAOCarrito
    {
        #region Atributos
        //Atributos pertinentes a usar
        private IdaoCarrito daoPrueba;
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
            //Obtengo el DAO
            this.daoPrueba = FabricaDAOSqlServer.ObtenerdaoCarrito();

            //La persona
            this.persona = new Persona();
            this.persona.Id = 11;
            this.persona2 = new Persona();
            this.persona2.Id = 12;
            this.persona3 = new Persona();
            this.persona3.Id = 13;

            //Dos implementos distintos
            this.implemento = new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;
            this.implemento2 = new Implemento();
            this.implemento2.Id = 2;
            this.implemento2.Precio_Implemento = 3000;

            //Eventos
           // this.listaEventos = this.eventos.Ejecutar();
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
            
        }

        /// <summary>
        /// Prueba unitaria para asegurar que el DAO no sea vacio
        /// </summary>
        [Test]
        public void PruebaVacio()
        {
            Assert.IsNotNull(this.daoPrueba);
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el metodo de AgregarItem para agregar implementos
        /// </summary>
        [Test]
        public void pruebaAgregarImplemento()
        {
            //Agrego un implemento al carrito vacio de una persona
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona, this.implemento, 1, 10));
            
            //Agrego el mismo implemento pero con cantidad diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona, this.implemento, 1, 11));
           
            //Agrego un implemento diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona, this.implemento2, 1, 30));
            
            //Agrego un item diferente al carrito
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona, this.evento, 2, 20));
            
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el metodo de AgregarItem para agregar eventos
        /// </summary>
        [Test]
        public void pruebaAgregarEvento()
        {
            //Agrego un Evento al carrito vacio de una persona
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.evento , 2, 10));
            
            //Agrego el mismo evento pero con cantidad diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.evento, 2, 11));
            
            //Agrego un evento diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.evento2, 2, 30));
            
            //Agrego un item diferente al carrito
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.matricula, 3, 20));
            
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el Ejecutar del comando AgregarItem para agregar matriculas
        /// </summary>
        [Test]
        public void PruebaAgregarMatricula()
        {
            //Agrego una matricula al carrito vacio de una persona
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona3, this.matricula, 3, 10));
            
            //Agrego la misma matricula pero con cantidad diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona3, this.matricula, 3, 11));
            
            //Agrego una matricula diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona3, this.matricula2, 3, 30));
          
            //Agrego un item diferente al carrito
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona3, this.implemento, 1, 20));
            
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
