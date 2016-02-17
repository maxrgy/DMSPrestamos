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
    public interface IPrestamos
    {
        [OperationContract]
        Prestamo CrearPrestamo(int codigo, string cliente, string equipo, int usuario, DateTime fePrestamo, DateTime feDevolucion, string motivo, string estado);
        [OperationContract]
        Prestamo ObtenerPrestamo(int codigo);
        [OperationContract]
        Prestamo ModificarPrestamo(int codigo, string cliente, string equipo, int usuario, DateTime fePrestamo, DateTime feDevolucion, string motivo, string estado);
        [OperationContract]
        void EliminarPrestamo(int codigo);
        [OperationContract]
        List<Prestamo> ListarPrestamos();
    }
}

