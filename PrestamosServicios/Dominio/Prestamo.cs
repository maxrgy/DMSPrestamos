using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PrestamosServicios.Dominio
{
    [DataContract]
    public class Prestamo
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Cliente { get; set; }
        [DataMember]
        public string Equipo { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        // [DataMember]
        //public DateTime F_devolucion { get; set; }
        //[DataMember]
        //public DateTime F_prestamo { get; set; }
        [DataMember]
        public string Motivo { get; set; }
        [DataMember]
        public string Estado { get; set; }


    }
}