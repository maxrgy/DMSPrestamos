using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PrestamosServicios.Dominio
{
    [DataContract]
    public class Equipo
    {
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public int Modelo { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}