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
    /// <summary>
    /// Clase que gestiona las operaciones CRUD sobre la entidad Proyectos en la base de datos.
    /// </summary>
    internal class GestionProyectos
    {
        /// <summary>
        /// Obtiene la lista de todos los proyectos registrados en la base de datos,
        /// incluyendo información de la empresa y del consultor asociados.
        /// </summary>
        /// <returns>Lista de objetos Proyectos.</returns>
        public List<Proyectos> GetListaProyectos()
        {
            List<Proyectos> listadoProyectos = new List<Proyectos>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    // Consulta SQL para obtener proyectos junto con empresa y consultor asociados
                    string consulta = "SELECT  p.id, p.descripcion, " +
                        "p.coste, p.precio_venta, e.id_empresa, e.nombre AS nombreE,  c.id AS id_consultor, " +
                        "c.nombre AS nombreC FROM Gestion_proyectos p " +
                        "LEFT JOIN Gestion_empresas e ON e.id_empresa = p.id_cliente " +
                        "JOIN consultor c ON c.id = p.id_consultor";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    SqlDataReader resultado = comando.ExecuteReader();
                    while (resultado.Read())
                    {
                        Proyectos p = new Proyectos();

                        // Asignación segura de propiedades, comprobando posibles valores nulos
                        p.Id = resultado["id"] != DBNull.Value ? (int)resultado["id"] : 0;
                        p.Descripcion = resultado["descripcion"] != DBNull.Value ? resultado["descripcion"].ToString() : "";
                        p.Coste = resultado["coste"] != DBNull.Value ? Convert.ToDouble(resultado["coste"]) : 0.0;
                        p.Precio = resultado["precio_venta"] != DBNull.Value ? Convert.ToDouble(resultado["precio_venta"]) : 0.0;

                        Empresas em = new Empresas();
                        em.Id = resultado["id_empresa"] != DBNull.Value ? (int)resultado["id_empresa"] : 0;
                        em.Nombre = resultado["nombreE"] != DBNull.Value ? resultado["nombreE"].ToString() : "";
                        p.Id_empresa = em;

                        Consultor c = new Consultor();
                        c.Id = resultado["id_consultor"] != DBNull.Value ? (int)resultado["id_consultor"] : 0;
                        c.Nombre = resultado["nombreC"] != DBNull.Value ? resultado["nombreC"].ToString() : "";
                        p.Id_consultor = c;

                        listadoProyectos.Add(p);
                    }
                }
                catch (Exception ex)
                {
                    // Captura y muestra cualquier error de conexión o consulta
                    Console.WriteLine(ex.Message);
                }
            }
            return listadoProyectos;
        }

        /// <summary>
        /// Inserta un nuevo proyecto en la base de datos utilizando un objeto Proyectos.
        /// </summary>
        /// <param name="p">Objeto Proyectos con los datos a insertar.</param>
        public void InsertarProyecto(Proyectos p)
        {
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    // Consulta SQL para insertar un nuevo proyecto
                    string consulta = "INSERT INTO Gestion_proyectos (descripcion, coste, precio_venta, id_consultor, id_cliente) " +
                                      "VALUES (@descripcion, @coste, @precio_venta, @id_consultor, @id_cliente)";

                    SqlCommand comando = new SqlCommand(consulta, conn);
                    // Asigna los parámetros de la consulta con los valores del objeto
                    comando.Parameters.AddWithValue("@descripcion", p.Descripcion);
                    comando.Parameters.AddWithValue("@coste", p.Coste);
                    comando.Parameters.AddWithValue("@precio_venta", p.Precio);
                    comando.Parameters.AddWithValue("@id_consultor", p.Id_consultor != null ? p.Id_consultor.Id : (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@id_cliente", p.Id_empresa != null ? p.Id_empresa.Id : (object)DBNull.Value);

                    // Ejecuta el comando
                    comando.ExecuteNonQuery();
                    Console.WriteLine("Proyecto insertado correctamente.");
                }
                catch (Exception ex)
                {
                    // Captura y muestra cualquier error durante la inserción
                    Console.WriteLine("Error al insertar proyecto: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Inserta un nuevo proyecto en la base de datos utilizando parámetros individuales.
        /// </summary>
        /// <param name="descripcion">Descripción del proyecto.</param>
        /// <param name="coste">Coste del proyecto.</param>
        /// <param name="precio">Precio de venta del proyecto.</param>
        /// <param name="idConsultor">ID del consultor asignado.</param>
        /// <param name="idEmpresa">ID de la empresa cliente.</param>
        public void InsertarProyecto(string descripcion, double coste, double precio, int idConsultor, int idEmpresa)
        {
            Proyectos proyecto = new Proyectos();
            proyecto.Descripcion = descripcion;
            proyecto.Coste = coste;
            proyecto.Precio = precio;
            proyecto.Id_consultor = new Consultor { Id = idConsultor };
            proyecto.Id_empresa = new Empresas { Id = idEmpresa };

            InsertarProyecto(proyecto);
        }
    }
}
