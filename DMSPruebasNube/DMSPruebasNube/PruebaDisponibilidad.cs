using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMSPruebasNube.disponibleWS;

namespace DMSPruebasNube
{
    [TestClass]
    public class PruebaDisponibilidad
    {
        [TestMethod]
        public void PruebaDisponible()
        {
            disponibleWS.EquipoDisponibleClient proxy = new disponibleWS.EquipoDisponibleClient();
            Equipo equipo = proxy.VerificarDisponibilidadEquipo("iPAD");
            Assert.AreNotEqual(null, equipo);
        }
    }
}
