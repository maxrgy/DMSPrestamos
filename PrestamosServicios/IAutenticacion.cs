using PrestamosServicios.Dominio;
using PrestamosServicios.usuariosWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PrestamosServicios
{
    [ServiceContract]
    public interface IAutenticacion
    {
        [FaultContract(typeof(UsuarioNoEncontradoExcepcion))]
        [OperationContract]
        Usuario VerificarExistenciaUsuario(string usuario);

        [FaultContract(typeof(PasswordIncorrectaExcepcion))]
        [OperationContract]
        int VerificarPassword(Usuario usuarioConUsername, string password);
        
    }
}
