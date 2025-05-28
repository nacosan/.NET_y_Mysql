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
    /// Clase que gestiona las operaciones CRUD sobre la entidad Empresas en la base de datos.
    /// </summary>
    internal class GestionEmpresas
    {
        /// <summary>
        /// Obtiene la lista de todas las empresas registradas en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Empresas.</returns>
        public List<Empresas> GetListaEmpresas()
        {
            // Creo la lista donde se almacenarán las empresas recuperadas
            List<Empresas> listadoEmpresas = new List<Empresas>();
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    // Consulta SQL para seleccionar todas las empresas
                    string consulta = "SELECT * FROM Gestion_empresas";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    SqlDataReader resultado = comando.ExecuteReader();

                    // Recorro los resultados y creo objetos Empresas por cada fila
                    while (resultado.Read())
                    {
                        Empresas e = new Empresas();
                        e.Id = (int)resultado["id_empresa"];
                        e.Nombre = (string)resultado["nombre"];
                        e.Direccion = (string)resultado["direccion"];
                        e.Telefono = (string)resultado["telefono"];
                        e.Cif = (string)resultado["cif"];
                        listadoEmpresas.Add(e);
                    }
                }
                catch (Exception ex)
                {
                    // Captura y muestra cualquier error de conexión o consulta
                    Console.WriteLine(ex.Message);
                }
            }
            return listadoEmpresas;
        }

        /// <summary>
        /// Inserta una nueva empresa en la base de datos utilizando un objeto Empresas.
        /// </summary>
        /// <param name="e">Objeto Empresas con los datos a insertar.</param>
        public void InsertarEmpresas(Empresas e)
        {
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    // Consulta SQL para insertar una nueva empresa (id_empresa es autoincremental)
                    string consulta = "INSERT INTO Gestion_empresas (nombre, direccion, cif, telefono) " +
                                      "VALUES (@nombre, @direccion, @cif, @telefono)";

                    SqlCommand comando = new SqlCommand(consulta, conn);
                    // Asigno los parámetros de la consulta con los valores del objeto
                    comando.Parameters.AddWithValue("@nombre", e.Nombre);
                    comando.Parameters.AddWithValue("@direccion", e.Direccion);
                    comando.Parameters.AddWithValue("@cif", e.Cif);
                    comando.Parameters.AddWithValue("@telefono", e.Telefono);

                    // Ejecuto el comando
                    comando.ExecuteNonQuery();
                    Console.WriteLine("Empresa insertada correctamente.");
                }
                catch (Exception ex)
                {
                    // Captura y muestra cualquier error durante la inserción
                    Console.WriteLine("Error al insertar empresa: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Inserta una nueva empresa en la base de datos utilizando parámetros individuales.
        /// </summary>
        /// <param name="nombre">Nombre de la empresa.</param>
        /// <param name="direccion">Dirección de la empresa.</param>
        /// <param name="cif">CIF de la empresa.</param>
        /// <param name="telefono">Teléfono de la empresa.</param>
        public void InsertarEmpresas(string nombre, string direccion, string cif, string telefono)
        {
            // Crea un objeto Empresas y llama al método que inserta por objeto
            Empresas empresas = new Empresas();
            empresas.Nombre = nombre;
            empresas.Direccion = direccion;
            empresas.Cif = cif;
            empresas.Telefono = telefono;

            InsertarEmpresas(empresas);
        }

        /// <summary>
        /// Permite al usuario actualizar el número de teléfono de una empresa seleccionada.
        /// Muestra el listado de empresas, solicita el ID, muestra el teléfono actual y permite modificarlo.
        /// </summary>
        public void ActualizarTelefonoEmpresa(int idEmpresa, string nuevoTelefono)
        {
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "UPDATE Gestion_empresas SET telefono = @telefono WHERE id_empresa = @id_empresa";
                    SqlCommand comando = new SqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@telefono", nuevoTelefono);
                    comando.Parameters.AddWithValue("@id_empresa", idEmpresa);
                    int filas = comando.ExecuteNonQuery();
                    // Puedes mostrar un mensaje si lo necesitas, o devolver filas si quieres saber si se actualizó
                }
                catch (Exception ex)
                {
                    // Maneja el error como prefieras (MessageBox, log, etc.)
                    // Por ejemplo:
                    // MessageBox.Show("Error al actualizar el teléfono: " + ex.Message);
                }
            }
        }

    }
}
