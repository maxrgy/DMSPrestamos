using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMSPruebasNube.equipoWS;
using System.ServiceModel;

namespace DMSPruebasNube
{
    [TestClass]
    public class PruebaEquipos
    {
        //prueba
        [TestMethod]
        public void TestCrearEquipo()
        {
            equipoWS.EquiposClient proxy = new equipoWS.EquiposClient();
            Equipo creado = proxy.CrearEquipo("a310", "iPAD", "D");
            Assert.AreNotEqual(null, creado);
        }

        [TestMethod]
        public void TestBuscarPorSerie()
        {
            equipoWS.EquiposClient proxy = new equipoWS.EquiposClient();
            Equipo encontrado = proxy.ObtenerSerie("a17");
            Assert.AreEqual("Acer", encontrado.Modelo);
        }

        [TestMethod]
        public void TestCrearEquipoExcepcion()
        {
            equipoWS.EquiposClient proxy = new equipoWS.EquiposClient();
            try
            {
                proxy.CrearEquipo("a20", "iPAD", "D");
            }
            catch (FaultException<equipoWS.EquipoRepetidoExcepcion> fe)
            {
                Assert.AreEqual("El equipo ya existe", fe.Detail.Mensaje);
            }

        }

        [TestMethod]
        public void TestListarPorModelo()
        {
            Equipo[] lista = null;
            equipoWS.EquiposClient proxy = new equipoWS.EquiposClient();
            lista = proxy.ListarDisponiblesModelo("Toshiba");
            Assert.AreEqual(3, lista.Length);
        }

        [TestMethod]
        public void TestEliminar()
        {
            equipoWS.EquiposClient proxy = new equipoWS.EquiposClient();
            proxy.EliminarEquipo(9);
            Assert.AreEqual(null, proxy.ObtenerEquipo(9));
        }

        [TestMethod]
        public void TestEliminarEquipoExcepcion()
        {
            equipoWS.EquiposClient proxy = new equipoWS.EquiposClient();
            try
            {
                proxy.EliminarEquipo(1000);
            }
            catch (FaultException<equipoWS.EquipoEliminarExcepcion> fe)
            {
                Assert.AreEqual("El equipo no se puede eliminar ya que está prestado", fe.Detail.Mensaje);
            }

        }
    }
}

