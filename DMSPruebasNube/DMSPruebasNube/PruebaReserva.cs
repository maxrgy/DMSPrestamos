using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMSPruebasNube
{
    [TestClass]
    public class PruebaReservaCola
    {
        [TestMethod]
        public void PruebaReservaEquipo()
        {
            reservaWS.ReservaEquipoClient proxy = new reservaWS.ReservaEquipoClient();
            string mensaje = proxy.RegistrarPrestamo("10074857880","iPAD","cflores","pruebas");
            Assert.AreEqual("Este modelo de equipo no esta disponible para prestamos",mensaje);
        }
    }
}
