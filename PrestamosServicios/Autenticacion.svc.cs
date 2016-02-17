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
using PrestamosServicios.usuariosWS;

namespace PrestamosServicios
{
    public class Autenticacion : IAutenticacion
    {
        public Usuario VerificarExistenciaUsuario(string usuario)
        {
            Usuario usuarioObtenido = new Usuario();
            usuariosWS.UsuariosClient proxy = new usuariosWS.UsuariosClient();
            usuarioObtenido = proxy.ObtenerUsuario(usuario);
            if (usuarioObtenido == null)
            {
                throw new FaultException<UsuarioNoEncontradoExcepcion>(
                    new UsuarioNoEncontradoExcepcion()
                    {
                        Codigo = "001",
                        Mensaje = "El usuario no existe"
                    },
                    new FaultReason("Validación de negocio"));
            }
            return usuarioObtenido;
        }

        public int VerificarPassword(Usuario usuarioConUsername, string password)
        {
            if (usuarioConUsername.Password != password)
            {
                throw new FaultException<PasswordIncorrectaExcepcion>(
                    new PasswordIncorrectaExcepcion()
                    {
                        Codigo = "002",
                        Mensaje = "Contraseña errada"
                    },
                    new FaultReason("Validación de negocio"));
            }
            return usuarioConUsername.Tipo;
                
        }
    }
}
