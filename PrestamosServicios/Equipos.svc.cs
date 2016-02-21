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
    public class Equipos : IEquipos
    {
        private EquipoDAO equipoDAO = null;
        private EquipoDAO EquipoDAO
        {
            get
            {
                if (equipoDAO == null)
                    equipoDAO = new EquipoDAO();
                return equipoDAO;
            }
        }


        public Equipo CrearEquipo(string serie, string modelo, string estado)
        {
            if (EquipoDAO.ObtenerPorSerie(serie) != null)
            {
                throw new FaultException<EquipoRepetidoExcepcion>(
                     new EquipoRepetidoExcepcion()
                     {
                         Codigo = "002",
                         Mensaje = "El equipo ya existe"
                     },
                     new FaultReason("Validacion de negocio"));
            }
            Equipo equipoACrear = new Equipo()
            {
                Serie = serie,
                Modelo = modelo,
                Estado = estado

            };
            return EquipoDAO.Crear(equipoACrear);
        }

        public void EliminarEquipo(int id)
        {
            Equipo equipoEncontrado = EquipoDAO.Obtener(id);
            EquipoDAO.Eliminar(equipoEncontrado);
        }

        public List<Equipo> ListarDisponiblesModelo(string modelo)
        {
            return EquipoDAO.ListarPorModelo(modelo).ToList();
        }

        public List<Equipo> ListarEquipos()
        {
            return EquipoDAO.ListarTodos().ToList();
        }

        public Equipo ModificarEquipo(int id, string serie, string modelo, string estado)
        {

            Equipo equipoAModificar = new Equipo()
            {
                Id = id,
                Serie = serie,
                Modelo = modelo,
                Estado = estado

            };
            return EquipoDAO.Modificar(equipoAModificar);

        }

        public Equipo ObtenerEquipo(int id)
        {
            return EquipoDAO.Obtener(id);
        }

        public Equipo ObtenerSerie(string serie)
        {
            return EquipoDAO.ObtenerPorSerie(serie);
        }
    }
}

