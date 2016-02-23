using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PrestamosServicios.Dominio;
using PrestamosServicios.Persistencia;
using System.Messaging;

namespace PrestamosServicios
{
    public class Prestamos : IPrestamos
    {
        private PrestamoDAO prestamoDAO = null;
        private PrestamoDAO PrestamoDAO
        {
            get
            {
                if (prestamoDAO == null)
                    prestamoDAO = new PrestamoDAO();
                return prestamoDAO;
            }
        }

        public Prestamo CrearPrestamo(Prestamo prestamoACrear)
        {
            /*string rutaCola = @".\private$\prestamospendientes";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Prestamo) });
            int cuenta = cola.GetAllMessages().Count();
            if (cuenta != 0)
            {
                for (int i = 1; i <= cuenta; i++)
                {
                    Message mensaje = cola.Receive();
                    Prestamo nota = (Prestamo)mensaje.Body;

                }

            }*/
            return PrestamoDAO.Crear(prestamoACrear);
        }

        public void EliminarPrestamo(string codigo)
        {
            int id = Int32.Parse(codigo);
            Prestamo prestamoEncontrado = PrestamoDAO.Obtener(id);
            PrestamoDAO.Eliminar(prestamoEncontrado);
        }

        public List<Prestamo> ListarPorUsuario(string usuario)
        {
            return PrestamoDAO.ListarPorUsuario(usuario).ToList();
        }

        public List<Prestamo> ListarPrestamo()
        {
            return PrestamoDAO.ListarTodos().ToList();
        }

        public Prestamo ModificarPrestamo(Prestamo prestamoAModificar)
        {

            return PrestamoDAO.Modificar(prestamoAModificar);
        }

        public Prestamo ObtenerPorEquipo(string equipo)
        {
            return PrestamoDAO.ObtenerPorEquipo(equipo);
        }

        public Prestamo ObtenerPrestamo(string codigo)
        {
            int id = Int32.Parse(codigo);
            return PrestamoDAO.Obtener(id);
        }
    }
}
