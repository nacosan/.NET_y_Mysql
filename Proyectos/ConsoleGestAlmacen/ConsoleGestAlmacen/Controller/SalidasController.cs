using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGestAlmacen.Modelos;
using MySql.Data.MySqlClient;

namespace ConsoleGestAlmacen.Controller
{
    internal class SalidasController
    {
        public List<Salidas> GetListaSalidas()
        {
            List<Salidas> listadoSalidas = new List<Salidas>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "select p.codigo as codigo1, p.nombre, p.tipo, s.cantidad, s.fecha from productos p join salidas s on s.codigo=p.codigo";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {

                        Salidas s = new Salidas();
                        Producto p = new Producto();
                        p.Codigo = (string)resultado["codigo1"];
                        p.Nombre = (string)resultado["nombre"];
                        s.MiProducto = p;
                        s.Cantidad = (int)resultado["cantidad"];
                        s.Fecha = (DateTime)resultado["fecha"];

                        listadoSalidas.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return listadoSalidas;
        }
    }
}