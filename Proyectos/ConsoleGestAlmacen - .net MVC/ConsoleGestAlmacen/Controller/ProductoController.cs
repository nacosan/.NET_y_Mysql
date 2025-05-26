using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ConsoleGestAlmacen.Modelos;
using MySql.Data.MySqlClient;

namespace ConsoleGestAlmacen.Controller
{
    internal class ProductoController
    {
        public void InsertarProducto(Producto p)
        {
            //Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "INSERT INTO productos(codigo, nombre, tipo)" +
                        "VALUES (@codigo, @nombre, @tipo)";

                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@codigo", p.Codigo);
                    comando.Parameters.AddWithValue("@nombre", p.Nombre);
                    comando.Parameters.AddWithValue("@tipo", p.Tipo);

                    int resultado = comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                }
            }
        }

        public void InsertarProducto(string codigo, string nombre, string tipo)
        {
            Producto producto = new Producto();
            producto.Codigo = codigo;
            producto.Nombre = nombre;
            producto.Tipo = tipo;
            InsertarProducto(producto);
        }

        public List<Producto> GetListaProductos()
        {
            List<Producto> listadoProductos = new List<Producto>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "select * from productos";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Producto p = new Producto();
                        p.Codigo = resultado["codigo"].ToString();
                        p.Nombre = resultado["nombre"].ToString();
                        p.Tipo = resultado["tipo"].ToString();
                        listadoProductos.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listadoProductos;
        }

        public List<(string Codigo, string Nombre, string Tipo, int StockActual)> GetStockActual()
        {
            var listaStock = new List<(string, string, string, int)>();
            using (var conn = new Conexion().GetConexion())
            {
                conn.Open();
                string consulta = @"
            SELECT 
                p.codigo, 
                p.nombre, 
                p.tipo, 
                COALESCE(SUM(m.cantidad), 0) AS stock_actual
            FROM productos p
            LEFT JOIN (
                SELECT codigo, cantidad FROM entradas
                UNION ALL
                SELECT codigo, -cantidad FROM salidas
            ) AS m ON p.codigo = m.codigo
            GROUP BY p.codigo, p.nombre, p.tipo";
                var comando = new MySqlCommand(consulta, conn);
                var resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    string codigo = resultado["codigo"].ToString();
                    string nombre = resultado["nombre"].ToString();
                    string tipo = resultado["tipo"].ToString();
                    int stockActual = Convert.ToInt32(resultado["stock_actual"]);
                    listaStock.Add((codigo, nombre, tipo, stockActual));
                }
            }
            return listaStock;
        }






    }
}
