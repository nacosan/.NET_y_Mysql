using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGestAlmacen.Modelos;
using MySql.Data.MySqlClient;

namespace ConsoleGestAlmacen.Controller
{
    internal class EntradasController
    {
        public bool InsertarEntradas(Producto producto, int cantidad)
        {
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "INSERT INTO entradas (codigo, cantidad, fecha) VALUES (@codigo, @cantidad, @fecha)";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@codigo", producto.Codigo);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("@fecha", DateTime.Now);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al insertar entrada: {ex.Message}");
                    return false;
                }
            }
        }

        public List<Entradas> GetListaEntradas()
        {
            List<Entradas> listadoEntradas = new List<Entradas>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "select p.codigo as codigo1, p.nombre, p.tipo, e.cantidad, e.fecha from productos p join entradas e on e.codigo=p.codigo";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                       
                            Entradas e = new Entradas();
                            Producto p = new Producto();
                            p.Codigo = (string)resultado["codigo1"];
                            p.Nombre = (string)resultado["nombre"];
                            e.MiProducto = p;
                            e.Cantidad = (int)resultado["cantidad"];
                            e.Fecha = (DateTime)resultado["fecha"];

                            listadoEntradas.Add(e);
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
                
                return listadoEntradas;
            }
        }
    }

