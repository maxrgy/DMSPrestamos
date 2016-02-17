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
        private ModeloDAO modeloDAO = null;
        private ModeloDAO ModeloDAO
        {
            get
            {
                if (modeloDAO == null)
                    modeloDAO = new ModeloDAO();
                return modeloDAO;
            }
        }


        public Equipo CrearEquipo(int modelo, string estado, string serie)
        {
            if ("12345".Equals(estado))
            {
                throw new FaultException<ExcepcionEquipo>(
                    new ExcepcionEquipo()
                    {
                        Cod = "01",
                        mensaje = "Has fallado"
                    },
                    new FaultReason("Validación de Negocio")
                    );
            }
            Modelo modeloExistente = ModeloDAO.Obtener(modelo);
            Equipo equipoACrear = new Equipo()
            {

                Modelo = modeloExistente.Codigo,
                Estado = estado,
                Serie = serie

            };
            return EquipoDAO.Crear(equipoACrear);
        }

        public void EliminarEquipo(string serie)
        {
            Equipo equipoExistente = EquipoDAO.Obtener(serie);
            EquipoDAO.Eliminar(equipoExistente);
        }

        public List<Equipo> ListarEquipos()
        {
            return EquipoDAO.ListarTodos().ToList();
        }

        public Equipo ModificarEquipo(int modelo, string estado, string serie)
        {
            Equipo equipoAModificar = new Equipo()
            {
                Modelo = modelo,
                Estado = estado,
                Serie = serie

            };
            return EquipoDAO.Modificar(equipoAModificar);
        }

        public Equipo ObtenerEquipo(string serie)
        {
            return EquipoDAO.Obtener(serie);
        }
    }
}
