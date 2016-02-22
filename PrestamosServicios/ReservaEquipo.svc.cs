using PrestamosServicios.equipodisponibleWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PrestamosServicios.Dominio;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Messaging;

namespace PrestamosServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "RegistrarPrestamo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione RegistrarPrestamo.svc o RegistrarPrestamo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReservaEquipo : IReservaEquipo
    {
        public string RegistrarPrestamo(string cliente, string equipo, string usuario, string motivo)
        {

            equipodisponibleWS.EquipoDisponibleClient proxy = new equipodisponibleWS.EquipoDisponibleClient();
            
            string mensaje = "";
            try
            {
                equipodisponibleWS.Equipo equiporecibido = proxy.VerificarDisponibilidadEquipo(equipo);
                string estado = "R";
                string postdata = "{\"Cliente\":\"" + cliente + "\",\"Equipo\":\"" + equiporecibido.Serie + "\",\"Usuario\":\"" + usuario + "\",\"Motivo\":\"" + motivo + "\",\"Estado\":\"" + estado + "\"}"; //JSON
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest
                    .Create("http://dmsprestamosapphb.com/Prestamos.svc/Prestamos");
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
                if (prestamoCreado == null)
                {
                    mensaje = "Reserva no se realizó";

                    //envía
                    string rutaCola = @".\private$\prestamospendientes";
                    if (!MessageQueue.Exists(rutaCola))
                        MessageQueue.Create(rutaCola);
                    MessageQueue cola = new MessageQueue(rutaCola);
                    Message msg = new Message();
                    msg.Label = "Nueva nota";
                    msg.Body = new Prestamo() { Cliente = cliente, Equipo = equiporecibido.Serie, Usuario = usuario, Motivo = motivo };
                    cola.Send(mensaje);
                    

                } 
                  else
                {

                    mensaje = "Reserva realizada";
                }

            }
            catch {

                mensaje = "Que estas haciendo";

            }
            return mensaje;
        }
    }
}
