using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PrestamosServicios.Dominio
{
    public class ExcepcionEquipo
    {
        [DataMember]
        public string Cod { get; set; }
        [DataMember]
        public string mensaje { get; set; }
    }
}

