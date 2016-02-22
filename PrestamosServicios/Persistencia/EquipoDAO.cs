using PrestamosServicios.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PrestamosServicios.Persistencia
{
    public class EquipoDAO : BaseDAO<Equipo, int>
    {
        public List<Equipo> ListarPorModelo(string modelo)
        {
            Equipo equipoEncontrado = null;
            string est = "D";
            List<Equipo> lista = new List<Equipo>();
            string sql = "SELECT * FROM t_equipos WHERE modelo=@mod and estado = @est";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@mod", modelo));
                    com.Parameters.Add(new SqlParameter("@est", est));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            equipoEncontrado = new Equipo()
                            {
                                Id = (int)resultado["id"],
                                Serie = (string)resultado["serie"],
                                Modelo = (string)resultado["modelo"],
                                Estado = (string)resultado["estado"],
                            };
                            lista.Add(equipoEncontrado);
                        }
                    }
                }
            }
            return lista;
        }

        public Equipo ObtenerPorSerie(string serie)
        {
            Equipo equipoEncontrado = new Equipo();
            string sql = "SELECT * FROM t_equipos WHERE serie=@seri ";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@seri", serie));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            equipoEncontrado = new Equipo()
                            {
                                Id = (int)resultado["id"],
                                Serie = (string)resultado["serie"],
                                Modelo = (string)resultado["modelo"],
                                Estado = (string)resultado["estado"],
                            };

                        }
                    }
                }
            }
            return equipoEncontrado;

        }

        public List<string> ListarModelos()
        {
            string agregar;
            List<string> lista = new List<string>();
            string sql = "SELECT modelo FROM t_equipos group by modelo ";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            agregar = (string)resultado["modelo"];
                            lista.Add(agregar);
                        }
                    }
                }
            }
            return lista;
        }
    }
}