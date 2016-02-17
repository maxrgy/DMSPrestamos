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
    public interface IEquipos
    {
        [FaultContract(typeof(ExcepcionEquipo))]
        [OperationContract]
        Equipo CrearEquipo(int modelo, string estado, string serie);
        [OperationContract]
        Equipo ObtenerEquipo(string serie);
        [OperationContract]
        Equipo ModificarEquipo(int modelo, string estado, string serie);
        [OperationContract]
        void EliminarEquipo(string serie);
        [OperationContract]
        List<Equipo> ListarEquipos();
    }
}
