using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PrestamosServicios.Dominio;
using PrestamosServicios.Persistencia;

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

        public Prestamo CrearPrestamo(int codigo, string cliente, string equipo, int usuario, DateTime fePrestamo, DateTime feDevolucion, string motivo, string estado)
        {
            Prestamo prestamoACrear = new Prestamo()
            {

                Codigo = codigo,
                Cliente = cliente,
                Equipo = equipo,
                Usuario = usuario,
                FePrestamo = fePrestamo,
                FeDevolucion = feDevolucion,
                Motivo = motivo,
                Estado = estado
            };
            return PrestamoDAO.Crear(prestamoACrear);
        }

        public void EliminarPrestamo(int codigo)
        {
            Prestamo prestamoExistente = PrestamoDAO.Obtener(codigo);
            PrestamoDAO.Eliminar(prestamoExistente);
        }

        public List<Prestamo> ListarPrestamos()
        {
            return PrestamoDAO.ListarTodos().ToList();
        }

        public Prestamo ModificarPrestamo(int codigo, string cliente, string equipo, int usuario, DateTime fePrestamo, DateTime feDevolucion, string motivo, string estado)
        {
            Prestamo prestamoAModificar = new Prestamo()
            {
                Codigo = codigo,
                Cliente = cliente,
                Equipo = equipo,
                Usuario = usuario,
                FePrestamo = fePrestamo,
                FeDevolucion = feDevolucion,
                Motivo = motivo,
                Estado = estado
            };
            return PrestamoDAO.Modificar(prestamoAModificar);
        }

        public Prestamo ObtenerPrestamo(int codigo)
        {   
            return PrestamoDAO.Obtener(codigo);
        }
    }
}
