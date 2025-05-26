using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clase12_05
{
    public class Conexion
    {

        String cadena = "server=localhost;user=root;password=;database=gesteventos";

        public MySqlConnection GetConexion()
        {
            MySqlConnection conn = new MySqlConnection(cadena);
            return conn;
        }



    }



}
