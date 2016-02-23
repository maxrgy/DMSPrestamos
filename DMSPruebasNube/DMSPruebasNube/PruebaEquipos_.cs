using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMSPruebasNube.equiposWS;
using System.ServiceModel;

namespace DMSPruebasNube
{
    [TestClass]
    public class PruebaEquipos
    {
        [TestMethod]
        public void TestCrearEquipo()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            Equipo creado = proxy.CrearEquipo(2, "12345", 4);
            Assert.AreNotEqual(null, creado);
        }

        [TestMethod]
        public void TestCrearEquipoExcepcion()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            try
            {
                proxy.CrearEquipo(2, "12345", 4);
            }
            catch (FaultException<equiposWS.ExcepcionEquipo> fe)
            {
                Assert.AreEqual("01", fe.Detail.Cod);
            }
        }

        [TestMethod]
        public void TestEliminar()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            proxy.EliminarEquipo(1);
            Equipo eliminado = proxy.ObtenerEquipo(1);
            Assert.IsNull(eliminado);
        }

        [TestMethod]
        public void TestListar()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            Equipo[] Lista = proxy.ListarEquipos();
            Assert.AreEqual(0, Lista.Length);
        }

    }
}
