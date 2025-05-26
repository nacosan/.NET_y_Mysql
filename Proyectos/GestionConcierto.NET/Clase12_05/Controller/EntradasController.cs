using Clase12_05.Modulos;
using Clase12_05;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Clase12_05.Modulos
{
    internal class EntradasController
    {
        public List<Compra> getListaEntradas(string nombre)
        {
            List<Compra> listadoEntradas = new List<Compra>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "select * from eventoid e join compras c " +
                        "on e.EventoID = c.EventoID " +
                        "join usuarios u on u.UsuarioID = c.UsuarioID " +
                        "WHERE u.NombreUsuario LIKE @nombre ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);

                    comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Compra compra = new Compra();
                        Evento evento = new Evento();
                        Usuarios usuario = new Usuarios();

                        evento.NombreEvento = (string)resultado["NombreEvento"];
                        evento.FechaEvento = (DateTime)resultado["FechaEvento"];
                        evento.precioEvento = resultado.GetFloat(resultado.GetOrdinal("Precio"));

                        usuario.Nombre = (string)resultado["NombreUsuario"];

                        compra.FechaCompra = (DateTime)resultado["FechaCompra"];
                        compra.obUsuario = usuario;
                        compra.obEvento = evento;

                        listadoEntradas.Add(compra);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } // Cierra el using de la conexión
            return listadoEntradas;
        } // Cierra el método getListaEntradas

        public int ComprarEntradas(string UsuarioString)
        {
            int usuarioId = -1;

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // 1. Obtener el ID del usuario
                    conn.Open();
                    string consultaId = "SELECT UsuarioID FROM usuarios WHERE NombreUsuario = @nombre";
                    MySqlCommand comando = new MySqlCommand(consultaId, conn);
                    comando.Parameters.AddWithValue("@nombre", UsuarioString);

                    object resultado = comando.ExecuteScalar();
                    if (resultado == null)
                    {
                        Console.WriteLine("Usuario no encontrado. Solo pueden comprar: juanperez, mariagomez, carlossanchez");
                        return -1;
                    }

                    usuarioId = Convert.ToInt32(resultado);

                    // 2. Solicitar EventoID al usuario (1-3)
                    int eventoId;
                    do
                    {
                        Console.Write("Ingrese el ID del evento (1-3): ");
                        if (!int.TryParse(Console.ReadLine(), out eventoId) || eventoId < 1 || eventoId > 3)
                        {
                            Console.WriteLine("Error: Debe ingresar un número entre 1 y 3.");
                        }
                    } while (eventoId < 1 || eventoId > 3);

                    // 3. Insertar la compra con la fecha actual
                    string insertarCompra = "INSERT INTO Compras (UsuarioID, EventoID, FechaCompra) " +
                                           "VALUES (@UsuarioID, @EventoID, NOW())";

                    MySqlCommand cmdInsertar = new MySqlCommand(insertarCompra, conn);
                    cmdInsertar.Parameters.AddWithValue("@UsuarioID", usuarioId);
                    cmdInsertar.Parameters.AddWithValue("@EventoID", eventoId);

                    int filasAfectadas = cmdInsertar.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        Console.WriteLine("¡Compra realizada con éxito!");
                        return 1; // Éxito
                    }
                    else
                    {
                        Console.WriteLine("Error al realizar la compra.");
                        return 0; // Error
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return -1; // Error
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
            }
        }
 


    }
}
