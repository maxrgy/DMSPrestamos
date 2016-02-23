using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

namespace DMSPruebasNube
{
    [TestClass]
    public class PruebaPrestamos
    {
        [TestMethod]
        public void PruebaCrearPrestamo()
        {
            // Prueba de creación de alumno vía HTTP POST
            string cliente = "20700001441";
            string equipo = "HP";
            string usuario = "mgonzales";
            //string fdevolucion= "18/2/2016";
            //string fprestamo="21/2/2016";
            string motivo = "otro";
            string estado = "P";
            string postdata = "{\"Cliente\":\"" + cliente + "\",\"Equipo\":\"" + equipo + "\",\"Usuario\":\"" + usuario + "\",\"Motivo\":\"" + motivo + "\",\"Estado\":\"" + estado + "\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://dmsprestamos.apphb.com/Prestamos.svc/Prestamos");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string prestamoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Prestamo prestamoCreado = js.Deserialize<Prestamo>(prestamoJson);
            Assert.AreEqual(8, prestamoCreado.Id);
            Assert.AreEqual("mgonzales", prestamoCreado.Usuario);
        }
    }
}

