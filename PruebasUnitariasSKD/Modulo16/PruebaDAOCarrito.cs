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
using LogicaNegociosSKD.Comandos.Fabrica;

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
        private Entidad persona4;
        private Entidad persona5;
        private Entidad persona6;
        private Implemento implemento;
        private Implemento implemento2;
        private List<Entidad> listaEventos;
        private Matricula matricula;
        private Matricula matricula2;
        private Dictionary<Entidad, int> ImplementosCarrito;
        private Dictionary<Entidad, int> EventosCarrito;
        private Dictionary<Entidad, int> MatriculasCarrito;
        private Evento evento;
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
            this.persona4 = new Persona();
            this.persona4.Id = 14;
            this.persona5 = new Persona();
            this.persona5.Id = 15;
            this.persona6 = new Persona();
            this.persona6.Id = 16;

            //Dos implementos distintos
            this.implemento = new Implemento();
            this.implemento.Id = 1;
            this.implemento.Precio_Implemento = 4500;
            this.implemento2 = new Implemento();
            this.implemento2.Id = 2;
            this.implemento2.Precio_Implemento = 3000;

            //Eventos
            this.listaEventos = FabricaComandos.CrearComandoConsultarTodosEventos().Ejecutar();
            
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

        #region AgregarItem
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
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona, this.listaEventos[0], 2, 20));
            
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el metodo de AgregarItem para agregar eventos
        /// </summary>
        [Test]
        public void pruebaAgregarEvento()
        {
            //Agrego un Evento al carrito vacio de una persona
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.listaEventos[0], 2, 10));
            
            //Agrego el mismo evento pero con cantidad diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.listaEventos[0], 2, 11));
            
            //Agrego un evento diferente
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.listaEventos[1], 2, 30));
            
            //Agrego un item diferente al carrito
            Assert.IsTrue(this.daoPrueba.agregarItem(this.persona2, this.matricula, 3, 20));
            
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el metodo de AgregarItem para agregar matriculas
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
        #endregion

        #region ModificarCarrito
        /// <summary>
        /// Prueba unitaria que trabaja sobre el metodo de ModificarCarrito para modificar cantidades
        /// de items en diferentes carritos que existan y que la cantidad deseada de implementos este en stock
        /// </summary>
        [Test]
        public void PruebaModificarCarritosNormales()
        {
            //Agrego y Modifico un carrito en el que solo hay implementos
            this.daoPrueba.agregarItem(this.persona, this.implemento, 1, 20);
            Assert.IsTrue(this.daoPrueba.ModificarCarrito(this.persona, this.implemento, 1, 7));
            
            //Agrego y Modifico un carrito en el que solo hay eventos
            this.daoPrueba.agregarItem(this.persona2, this.listaEventos[0], 2, 10);
            Assert.IsTrue(this.daoPrueba.ModificarCarrito(this.persona2, this.listaEventos[0], 2, 7));

            //Agrego y Modifico un carrito en el que hay Implementos, eventos y matriculas
            this.daoPrueba.agregarItem(this.persona3, this.implemento, 1, 20);
            this.daoPrueba.agregarItem(this.persona3, this.listaEventos[0], 2, 10);
            this.daoPrueba.agregarItem(this.persona3, this.matricula, 3, 20);
            Assert.IsTrue(this.daoPrueba.ModificarCarrito(this.persona3, this.implemento, 1, 7));
            Assert.IsTrue(this.daoPrueba.ModificarCarrito(this.persona3, this.listaEventos[0], 2, 7));
        }

        /// <summary>
        /// Prueba unitaria que trabaja sobre el metodo de ModificarCarrito para modificar cantidad deseada 
        /// de implementos y que esta cantidad nueva no se encuentre en stock
        /// </summary>
        [Test]
        public void PruebaModificarCarritosExceso()
        {
            /*Agrego Modifico un carrito en el que solo hay implementos poniendole una cantidad inexistente 
            en en el stock*/
            this.daoPrueba.agregarItem(this.persona, this.implemento, 1, 20);
            Assert.IsFalse(this.daoPrueba.ModificarCarrito(this.persona, this.implemento, 1, 8000));
            
            /*Modifico un carrito en hay implementos, eventos y matriculas, poniendole al implemento una cantidad
            inexistente en el stock */
            this.daoPrueba.agregarItem(this.persona3, this.implemento, 1, 20);
            this.daoPrueba.agregarItem(this.persona3, this.listaEventos[0], 2, 10);
            this.daoPrueba.agregarItem(this.persona3, this.matricula, 3, 20);
            Assert.IsFalse(this.daoPrueba.ModificarCarrito(this.persona3, this.implemento, 1, 8000));

        }
        #endregion

        #region RegistrarPago
        /// <summary>
        /// Prueba unitaria que trabaja sobre el metodo de RegistrarPago para registrar el pago de carritos sin
        /// implementos o con implementos en los que su su cantidad demandada puede ser llenada
        /// </summary>
        [Test]
        public void RegistrarPagosNormales()
        {
            /*Agregamos y Registramos el pago en un carrito 
            donde solo hay Implementos y su cantidad se puede satisfacer*/
            this.daoPrueba.agregarItem(this.persona, this.implemento, 1, 20);
            Assert.IsTrue(this.daoPrueba.RegistrarPago(this.persona,"Tarjeta"));

            //Agregamos y Registramos el pago en un carrito donde solo hay eventos
            this.daoPrueba.agregarItem(this.persona2, this.listaEventos[0], 2, 10);
            Assert.IsTrue(this.daoPrueba.RegistrarPago(this.persona2, "Deposito"));

            //Agregamos y Registramos el pago en un carrito donde solo hay matriculas
            this.daoPrueba.agregarItem(this.persona4, this.matricula, 3, 1);
            Assert.IsTrue(this.daoPrueba.RegistrarPago(this.persona4, "Transferencia"));

            //Agregamos y Registramos el pago de un carrito donde hay Implementos, eventos y matirculas
            this.daoPrueba.agregarItem(this.persona3, this.implemento, 1, 20);
            this.daoPrueba.agregarItem(this.persona3, this.listaEventos[0], 2, 10);
            this.daoPrueba.agregarItem(this.persona3, this.matricula, 3, 20);
            Assert.IsTrue(this.daoPrueba.RegistrarPago(this.persona3,"Tarjeta"));
        }


        /// <summary>
        /// Prueba Unitaria que trabaja sobre el metodo de RegistrarPago para intentar Registrar el pago 
        /// de un carrito donde la cantidad de implementos demandada no existe en el inventario
        /// </summary>
        [Test]
        public void RegistarPagosImplementosExcesos()
        {
            //Se agrega y se trata de registrar el pago de un carrito donde solo hay implementos
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona5, this.implemento, 1, 10);
            Assert.IsFalse(this.daoPrueba.RegistrarPago(this.persona5, "Deposito"));

            //Se agrega y se trata de registrar el pago de un carrito donde hay cualquier otro producto
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.implemento, 1, 10);
            this.daoPrueba.agregarItem(this.persona6, this.listaEventos[0], 2, 20);
            this.daoPrueba.agregarItem(this.persona6, this.matricula, 3, 1);
            Assert.IsFalse(this.daoPrueba.RegistrarPago(this.persona6, "Transferencia"));
        }
        #endregion

        #region VerCarritos
        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene implementos
        /// </summary>
        [Test]
        public void PruebaCarritoSoloImplementos()
        {
            //Agregamos implementos en el carrito de la persona
            this.daoPrueba.agregarItem(this.persona, this.implemento, 1, 5);

            //Ejecutamos los metodos correspondientes para ver los items
            this.ImplementosCarrito = this.daoPrueba.getImplemento(this.persona);
            this.EventosCarrito = this.daoPrueba.getEvento(this.persona);
            this.MatriculasCarrito = this.daoPrueba.getMatricula(this.persona);

            //Revisamos que solo hayan Implementos y efectivamente haya solo uno agregado
            Assert.IsTrue(this.ImplementosCarrito.Count == 1);
            Assert.IsTrue(this.EventosCarrito.Count == 0);
            Assert.IsTrue(this.MatriculasCarrito.Count == 0);

            //Obtenemos el implemento y verificamos sus valores
            this.implemento = this.ImplementosCarrito.ElementAt(0).Key as Implemento;
            Assert.AreEqual(this.implemento.Id_Implemento, 1);
            Assert.AreEqual(this.implemento.Precio_Implemento, 4500);
            Assert.AreEqual(this.ImplementosCarrito.ElementAt(0).Value, 5);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene Eventos
        /// </summary>
        [Test]
        public void PruebaCarritoSoloEventos()
        {
            //Agregamos Eventos en el carrito de la persona
            this.daoPrueba.agregarItem(this.persona2, this.listaEventos[0], 2, 6);

            //Ejecutamos los metodos correspondientes para ver los items
            this.ImplementosCarrito = this.daoPrueba.getImplemento(this.persona2);
            this.EventosCarrito = this.daoPrueba.getEvento(this.persona2);
            this.MatriculasCarrito = this.daoPrueba.getMatricula(this.persona2);

            //Revisamos que solo hayan Eventos y efectivamente haya solo uno agregado
            Assert.IsTrue(this.ImplementosCarrito.Count == 0);
            Assert.IsTrue(this.EventosCarrito.Count == 1);
            Assert.IsTrue(this.MatriculasCarrito.Count == 0);

            //Obtenemos el Evento y verificamos sus valores
            this.evento = this.EventosCarrito.ElementAt(0).Key as Evento;
            Assert.AreEqual(this.evento.Id_evento, 1);
            Assert.AreEqual(this.evento.Costo, 0);
            Assert.AreEqual(this.EventosCarrito.ElementAt(0).Value, 6);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que solo
        /// tiene Matriculas
        /// </summary>
        [Test]
        public void PruebaCarritoSoloMatriculas()
        {
            //Agregamos Matriculas en el carrito de la persona
            this.daoPrueba.agregarItem(this.persona3, this.matricula, 3, 1);

            //Ejecutamos los metodos correspondientes para ver los items
            this.ImplementosCarrito = this.daoPrueba.getImplemento(this.persona3);
            this.EventosCarrito = this.daoPrueba.getEvento(this.persona3);
            this.MatriculasCarrito = this.daoPrueba.getMatricula(this.persona3);

            //Revisamos que solo hayan Matriculas y efectivamente haya solo una agregada
            Assert.IsTrue(this.ImplementosCarrito.Count == 0);
            Assert.IsTrue(this.EventosCarrito.Count == 0);
            Assert.IsTrue(this.MatriculasCarrito.Count == 1);

            //Obtenemos la Matricula y verificamos sus valores
            this.matricula = this.MatriculasCarrito.ElementAt(0).Key as Matricula;
            Assert.AreEqual(this.matricula.Id, 1);
            //Assert.AreEqual(this.matricula.Costo, 5000);
            //PILAS CON EL COSTO ARREGLAR
            Assert.AreEqual(this.MatriculasCarrito.ElementAt(0).Value, 1);
        }

        /// <summary>
        /// Prueba unitaria del Ejecutar del ComandoVerCarrito que permite ver el carrito de una persona que tiene
        /// implementos, eventos y matriculas
        /// </summary>
        [Test]
        public void PruebaCarritoVariosItems()
        {
            //Agregamos todos los items en el carrito de una persona
            this.daoPrueba.agregarItem(this.persona4, this.implemento, 1, 5);
            this.daoPrueba.agregarItem(this.persona4, this.listaEventos[0], 2, 6);
            this.daoPrueba.agregarItem(this.persona4, this.matricula, 3, 1);

            //Ejecutamos los metodos correspondientes para ver los items
            this.ImplementosCarrito = this.daoPrueba.getImplemento(this.persona4);
            this.EventosCarrito = this.daoPrueba.getEvento(this.persona4);
            this.MatriculasCarrito = this.daoPrueba.getMatricula(this.persona4);

            /*Revisamos que hayan Implementos, Eventos y matriculas, ademas,
              que efectivamente haya solo uno agregado de cada uno de ellos*/
            Assert.IsTrue(this.ImplementosCarrito.Count == 1);
            Assert.IsTrue(this.EventosCarrito.Count == 1);
            Assert.IsTrue(this.MatriculasCarrito.Count == 1);

            //Obtenemos los items y verificamos sus valores            
            this.implemento = this.ImplementosCarrito.ElementAt(0).Key as Implemento;
            Assert.AreEqual(this.implemento.Id_Implemento, 1);
            Assert.AreEqual(this.implemento.Precio_Implemento, 4500);
            Assert.AreEqual(this.ImplementosCarrito.ElementAt(0).Value, 5);

            this.evento = this.EventosCarrito.ElementAt(0).Key as Evento;
            Assert.AreEqual(this.evento.Id_evento, 1);
            Assert.AreEqual(this.evento.Costo, 0);
            Assert.AreEqual(this.EventosCarrito.ElementAt(0).Value, 6);

            this.matricula = this.MatriculasCarrito.ElementAt(0).Key as Matricula;
            Assert.AreEqual(this.matricula.Id, 1);
            //Assert.AreEqual(this.matricula.Costo, 5000);
            //PILAS CON EL COSTO ARREGLAR
            Assert.AreEqual(this.MatriculasCarrito.ElementAt(0).Value, 1);
        }
        #endregion

        /// <summary>
        /// Elimina todos los atributos utilizados al probar
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            this.daoPrueba = null;
            this.persona = null;
            this.persona2 = null;
            this.persona3 = null;
            this.persona4 = null;
            this.persona5 = null;
            this.persona6 = null;
            this.implemento = null;
            this.implemento2 = null;
            this.listaEventos = null;
            this.matricula = null;
            this.matricula2 = null;
            this.ImplementosCarrito = null;
            this.EventosCarrito = null;
            this.MatriculasCarrito = null;
            this.evento = null;
        }
    }
}
