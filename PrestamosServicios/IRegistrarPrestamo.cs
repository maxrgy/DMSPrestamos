using PrestamosServicios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PrestamosServicios
{

    [ServiceContract]
    public interface IReservaEquipo
    {
        [OperationContract]
         void RegistrarPrestamo(string cliente, string equipo, string usuario, string motivo);
    }
}
