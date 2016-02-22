using PrestamosServicios.Dominio;
using PrestamosServicios.equipoWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PrestamosServicios
{
    [ServiceContract]
    public interface IEquipoDisponible
    {

         [FaultContract(typeof(EquipoDisponibilidadExcepcion))]
        [OperationContract]
        equipoWS.Equipo VerificarDisponibilidadEquipo(string modelo);

    }
}
