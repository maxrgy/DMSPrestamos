using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMSPruebasNube
{
    [TestClass]
    public class PruebaReservaColas
    {
        [TestMethod]
        public void PruebaReservaEquipoCola()
        {
            reservacolaWS.ReservaEquipoClient proxy = new reservacolaWS.ReservaEquipoClient();
            string mensaje = proxy.RegistrarPrestamo("10074857880","iPAD","mgonzales","pruebas");
            Assert.AreEqual("Este modelo de equipo no esta disponible para prestamos",mensaje);
        }
    }
}
