using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
    public class LibroData
    {
        public static bool Registrar(Libro oLibro)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar_libro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oLibro.Nombre);
                cmd.Parameters.AddWithValue("@autor", oLibro.Autor);
                cmd.Parameters.AddWithValue("@paginas", oLibro.Paginas);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Libro oLibro)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar_libro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idlibro", oLibro.IdLibro);
                cmd.Parameters.AddWithValue("@nombre", oLibro.Nombre);
                cmd.Parameters.AddWithValue("@autor", oLibro.Autor);
                cmd.Parameters.AddWithValue("@paginas", oLibro.Paginas);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Libro> Listar()
        {
            List<Libro> oListaLibro = new List<Libro>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar_libro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaLibro.Add(new Libro()
                            {
                                IdLibro = Convert.ToInt32(dr["IdLibro"]),
                                Nombre = dr["Nombre"].ToString(),
                                Autor = dr["Autor"].ToString(),
                                Paginas = dr["Paginas"].ToString(),
                            });
                        }

                    }



                    return oListaLibro;
                }
                catch (Exception ex)
                {
                    return oListaLibro;
                }
            }
        }

        public static Libro Obtener(int idlibro)
        {
            Libro oLibro = new Libro();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener_libro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idlibro", idlibro);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oLibro = new Libro()
                            {
                                IdLibro = Convert.ToInt32(dr["IdLibro"]),
                                Nombre = dr["Nombre"].ToString(),
                                Autor = dr["Autor"].ToString(),
                                Paginas = dr["Paginas"].ToString(),
                            };
                        }

                    }



                    return oLibro;
                }
                catch (Exception ex)
                {
                    return oLibro;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar_libro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idlibro", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}