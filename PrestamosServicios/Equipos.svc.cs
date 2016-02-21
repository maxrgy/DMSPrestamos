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
            Equipo prueba = new Equipo();
            Equipo equipoBuscado = EquipoDAO.ObtenerPorSerie(serie);
            if (equipoBuscado.Serie != null)
            {
                throw new FaultException<EquipoRepetidoExcepcion>(
                     new EquipoRepetidoExcepcion()
                     {
                         Codigo = "002",
                         Mensaje = "El equipo ya existe"
                     },
                     new FaultReason("Validacion de negocio"));
            }
            else {
                Equipo equipoACrear = new Equipo()
                {
                    Serie = serie,
                    Modelo = modelo,
                    Estado = estado

                };
                return EquipoDAO.Crear(equipoACrear);
            }
        }

        public void EliminarEquipo(int id)
        {
            Equipo equipoEncontrado = EquipoDAO.Obtener(id);
            if (equipoEncontrado.Estado == "P")
            {
                throw new FaultException<EquipoEliminarExcepcion>(
                     new EquipoEliminarExcepcion()
                     {
                         Codigo = "003",
                         Mensaje = "El equipo no se puede eliminar ya que está prestado"
                     },
                     new FaultReason("Validacion de negocio"));
            }
            else
            {

                if (equipoEncontrado.Estado == null)
                {
                    throw new FaultException<EquipoEliminarExcepcion>(
                     new EquipoEliminarExcepcion()
                     {
                         Codigo = "004",
                         Mensaje = "El equipo no se puede borrar ya que no existe"
                     },
                      new FaultReason("Validacion de negocio"));
                }
                else
                {



                    EquipoDAO.Eliminar(equipoEncontrado);
                }
            }

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

