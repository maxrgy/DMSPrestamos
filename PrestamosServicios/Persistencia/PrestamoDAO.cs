using PrestamosServicios.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrestamosServicios.Persistencia
{
    public class PrestamoDAO : BaseDAO<Prestamo, int>
    {
        public List<Prestamo> ListarPorUsuario(string usuario)
        {
            Prestamo prestamoEncontrado = null;
            string est = "P";
            List<Prestamo> lista = new List<Prestamo>();
            string sql = "SELECT * FROM t_prestamos WHERE usuario=@usu and estado =@est";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@usu", usuario));
                    com.Parameters.Add(new SqlParameter("@est", est));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            prestamoEncontrado = new Prestamo()
                            {
                                Id = (int)resultado["id"],
                                Cliente = (string)resultado["cliente"],
                                Equipo = (string)resultado["equipo"],
                                Usuario = (string)resultado["usuario"],
                                // F_devolucion = (DateTime)resultado["f_devolucion"],
                                //F_prestamo = (DateTime)resultado["f_prestamo"],
                                Motivo = (string)resultado["motivo"],
                                Estado = (string)resultado["estado"],
                            };
                            lista.Add(prestamoEncontrado);
                        }
                    }
                }
            }
            return lista;
        }

        public Prestamo ObtenerPorEquipo(string equipo)
        {
            string est = "P";
            Prestamo encontrado = new Prestamo();
            string sql = "SELECT * FROM t_prestamos WHERE equipo=@equip and estado =@est";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@equip", equipo));
                    com.Parameters.Add(new SqlParameter("@est", est));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            encontrado = new Prestamo()
                            {
                                Id = (int)resultado["id"],
                                Cliente = (string)resultado["cliente"],
                                Equipo = (string)resultado["equipo"],
                                Usuario = (string)resultado["usuario"],
                                //F_devolucion = (DateTime)resultado["f_devolucion"],
                                //F_prestamo = (DateTime)resultado["f_prestamo"],
                                Motivo = (string)resultado["motivo"],
                                Estado = (string)resultado["estado"],
                            };
                            //encontrado = (prestamoEncontrado);
                        }
                    }
                }
            }
            return encontrado;
        }

    }
}