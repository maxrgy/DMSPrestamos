using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PrestamosServicios.equipoWS;
using PrestamosServicios.Dominio;

namespace PrestamosServicios
{
    public class EquipoDisponible : IEquipoDisponible
    {

        public equipoWS.Equipo VerificarDisponibilidadEquipo(string modelo)
        {
            equipoWS.Equipo nuevo = new equipoWS.Equipo();
            equipoWS.EquiposClient proxy = new equipoWS.EquiposClient();
            equipoWS.Equipo[] Lista = proxy.ListarDisponiblesModelo(modelo);
            if (Lista.Length > 2)
            {
                nuevo = Lista[0];
            }
            else
            {

                throw new FaultException<EquipoDisponibilidadExcepcion>(
                     new EquipoDisponibilidadExcepcion()
                     {
                         Codigo = "005",
                         Mensaje = "Este modelo de equipo no esta disponible para prestamos"
                     },
                     new FaultReason("Validacion de negocio"));

            }


            return nuevo;
        }
    }
}
