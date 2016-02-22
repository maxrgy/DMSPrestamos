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
        [FaultContract(typeof(EquipoRepetidoExcepcion))]
        [OperationContract]
        Equipo CrearEquipo(string serie, string modelo, string estado);
        [OperationContract]
        Equipo ObtenerEquipo(int id);
        [OperationContract]
        Equipo ModificarEquipo(int id, string serie, string modelo, string estado);
        [FaultContract(typeof(EquipoEliminarExcepcion))]
        [OperationContract]
        void EliminarEquipo(int id);
        [OperationContract]
        List<Equipo> ListarEquipos();
        [OperationContract]
        List<Equipo> ListarDisponiblesModelo(string modelo);
        [OperationContract]
        Equipo ObtenerSerie(string serie);
        [OperationContract]
        List<string> ListarModelosEquipos();
    }
}
