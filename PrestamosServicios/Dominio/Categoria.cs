using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PrestamosServicios.Dominio
{
    [DataContract]
    public class Categoria
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Category { get; set; }
    }
}