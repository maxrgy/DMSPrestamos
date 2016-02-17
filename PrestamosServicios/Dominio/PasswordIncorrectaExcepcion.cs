using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PrestamosServicios.Dominio
{
    [DataContract]
    public class PasswordIncorrectaExcepcion
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}