using System;
using Microsoft.Data.SqlClient;


namespace ConsoleGestAlmacen
{
    public class Conexion
    {
        // Cambia los valores según tu configuración de SQL Server
        string cadena = "Server=localhost;Database=EmpresaTecnologica(26/05);User=sa;Password=sa;TrustServerCertificate=True;Integrated Security=false;" ;

        public SqlConnection GetConexion()
        {
            SqlConnection conn = new SqlConnection(cadena);
            return conn;
        }
    }
}
