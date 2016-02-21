using PrestamosServicios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PrestamosServicios
{
    [ServiceContract]
    public interface IPrestamos
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Prestamos", ResponseFormat = WebMessageFormat.Json)]
        Prestamo CrearPrestamo(Prestamo prestamoACrear);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Prestamos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Prestamo ObtenerPrestamo(string codigo);
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Prestamos", ResponseFormat = WebMessageFormat.Json)]
        Prestamo ModificarPrestamo(Prestamo prestamoAModificar);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Prestamos/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarPrestamo(string codigo);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Prestamos", ResponseFormat = WebMessageFormat.Json)]
        List<Prestamo> ListarPrestamo();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Prestamos/Usuario/{usuario}", ResponseFormat = WebMessageFormat.Json)]
        List<Prestamo> ListarPorUsuario(string usuario);
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Prestamos/Equipo/{equipo}", ResponseFormat = WebMessageFormat.Json)]
        Prestamo ObtenerPorEquipo(string equipo);

    }
}

