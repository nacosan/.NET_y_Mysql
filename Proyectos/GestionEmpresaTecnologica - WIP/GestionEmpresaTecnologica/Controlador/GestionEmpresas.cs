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
    internal class GestionEmpresas
    {
        public List<Empresas> GetListaConsultores()
        {
            List<Empresas> listadoConsultores = new List<Empresas>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT * FROM Gestion_empresas";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    SqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Empresas e = new Empresas();
                        e.Nombre = (string)resultado["nombre"];
                        e.Direccion = (string)resultado["direccion"];
                        e.Telefono = (string)resultado["telefono"];
                        e.Cif = (string)resultado["cif"];




                        listadoConsultores.Add(e);

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
