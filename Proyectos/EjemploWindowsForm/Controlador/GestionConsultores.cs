using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGestAlmacen;
using GestionEmpresaTecnologica.Modelos;
using Microsoft.Data.SqlClient;

namespace GestionEmpresaTecnologica.Controlador
{
    internal class GestionConsultores
    {
        public List<Consultor> GetListaConsultores()
        {
            List<Consultor> listaConsultores = new List<Consultor>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT id, nombre, categoria, sueldo_actual, salario_recomendado FROM consultor";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Consultor c = new Consultor();
                        c.Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0;
                        c.Nombre = reader["nombre"] != DBNull.Value ? reader["nombre"].ToString() : "";
                        c.Categoria = reader["categoria"] != DBNull.Value ? reader["categoria"].ToString() : "";
                        c.Sueldo_actual = reader["sueldo_actual"] != DBNull.Value ? Convert.ToDouble(reader["sueldo_actual"]) : 0;
                        c.Salario_recomendado = reader["salario_recomendado"] != DBNull.Value ? Convert.ToDouble(reader["salario_recomendado"]) : 0;
                        // Si tienes más campos, añádelos aquí

                        listaConsultores.Add(c);
                    }
                }
                catch (Exception ex)
                {
                    // Maneja el error como prefieras, por ejemplo:
                    // MessageBox.Show("Error al cargar consultores: " + ex.Message);
                }
            }
            return listaConsultores;
        }



    }
}
