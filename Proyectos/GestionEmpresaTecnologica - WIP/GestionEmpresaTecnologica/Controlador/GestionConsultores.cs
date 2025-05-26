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
            List<Consultor> listadoConsultores = new List<Consultor>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT * FROM consultor";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    SqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Consultor c = new Consultor();
                        c.Nombre = (string)resultado["nombre"];
                        c.Categoria = (string)resultado["categoria"];
                        c.Sueldo_actual = (double)resultado["sueldo_actual"];
                        c.Salario_recomendado = (double)resultado["salario_recomendado"];




                        listadoConsultores.Add(c);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listadoConsultores;
        }
    }
}
