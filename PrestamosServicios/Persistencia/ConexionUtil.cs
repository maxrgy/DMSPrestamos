using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrestamosServicios.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=5418a339-6f77-4284-ab30-a59c0105bc9d.sqlserver.sequelizer.com;Initial Catalog=db5418a3396f774284ab30a59c0105bc9d;User ID=ddqtunslwhztrstj;Password=jPU6UrDzgi2UBunmhSYJHsWyUjavcFVBjL7gdPnXLnNPM78FeSL73iWZZujJriwG;";
            //return "Data Source=LAPTOPTOSHIBA;Initial Catalog=BD_Prestamo;Integrated Security=SSPI;";
        }
    }
}