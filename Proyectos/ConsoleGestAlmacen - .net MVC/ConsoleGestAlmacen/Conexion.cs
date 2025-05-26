using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleGestAlmacen
{
    public class Conexion
    {

        String cadena = "server=localhost;user=root;password=;database=gestempresa";

        public MySqlConnection GetConexion()
        {
            MySqlConnection conn = new MySqlConnection(cadena);
            return conn;
        }



    }



}
