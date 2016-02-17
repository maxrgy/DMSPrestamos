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
        public int Codigo { get; set; }
        [DataMember]
        public string Cliente { get; set; }
        [DataMember]
        public string Equipo { get; set; }
        [DataMember]
        public int Usuario { get; set; }
        [DataMember]
        public DateTime FeDevolucion { get; set; }
        [DataMember]
        public DateTime FePrestamo { get; set; }
        [DataMember]
        public string Motivo { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}