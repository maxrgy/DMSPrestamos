using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMSPruebasNube.autenticacionWS;
using System.ServiceModel;

namespace DMSPruebasNube
{
    [TestClass]
    public class PruebaAutenticación
    {
        [TestMethod]
        public void VerificarUsuario()
        {
            string usuario = "mgonzales";
            autenticacionWS.AutenticacionClient proxy = new autenticacionWS.AutenticacionClient();
            Usuario user = proxy.VerificarExistenciaUsuario(usuario);
            Assert.AreEqual("maxrgy@gmail.com", user.Correo);
        }

        [TestMethod]
        public void VerificarUsuarioExcepcion()
        {
            string usuario = "mgonzalesy";
            autenticacionWS.AutenticacionClient proxy = new autenticacionWS.AutenticacionClient();
            try
            {
                proxy.VerificarExistenciaUsuario(usuario);
            }
            catch (FaultException<autenticacionWS.UsuarioNoEncontradoExcepcion> fe)
            {
                Assert.AreEqual("El usuario no existe", fe.Detail.Mensaje);
            }
        }

        [TestMethod]
        public void VerificarPassword()
        {
            string usuario = "maparcana";
            string password = "12345678";
            autenticacionWS.AutenticacionClient proxy = new autenticacionWS.AutenticacionClient();
            Usuario user = proxy.VerificarExistenciaUsuario(usuario);

            int tipo = proxy.VerificarPassword(user, password);
            Assert.AreEqual(1, tipo);
        }

        [TestMethod]
        public void VerificarPasswordExcepcion()
        {
            Usuario usuarioAutenticando = new Usuario()
            {
                Codigo = "cflores",
                Password = "12222222"
            };
            string password = "12345678";
            autenticacionWS.AutenticacionClient proxy = new autenticacionWS.AutenticacionClient();
            try
            {
                proxy.VerificarPassword(usuarioAutenticando, password);
            }
            catch (FaultException<autenticacionWS.PasswordIncorrectaExcepcion> fe)
            {
                Assert.AreEqual("Contraseña errada", fe.Detail.Mensaje);
            }

        }
    }
}
