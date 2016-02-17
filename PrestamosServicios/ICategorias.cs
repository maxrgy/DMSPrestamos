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
    public interface ICategorias
    {
        [OperationContract]
        Categoria CrearCategoria(string categoria);
        [OperationContract]
        Categoria ObtenerCategoria(int codigo);
        [OperationContract]
        Categoria ModificarCategoria(int codigo, string categoria);
        [OperationContract]
        void EliminarCategoria(int codigo);
        [OperationContract]
        List<Categoria> ListarCategoria();
    }
}
