using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGestAlmacen;
using GestionEmpresaTecnologica.Controlador;
using GestionEmpresaTecnologica.Modelos;
using Microsoft.Data.SqlClient;

namespace GestionEmpresaTecnologica
{
    public class Gestion
    {
        public void Menu()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConsultarConsultores();
                        break;
                    case "2":
                        GestionarEmpresas();
                        break;
                    case "3":
                        GestionarProyectos();
                        break;
                    case "5":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE EMPRESA TECNOLÓGICA ===");
            Console.WriteLine("1. Consultar consultores");
            Console.WriteLine("2. Gestionar empresas");
            Console.WriteLine("3. Gestionar proyectos");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private void ConsultarConsultores() {
            GestionConsultores gc = new GestionConsultores();
       List<Consultor> consultor = gc.GetListaConsultores();

        Console.WriteLine("\nLISTADO DE CONSULTORES:");
            foreach (Consultor c in consultor)
            {
                Console.WriteLine($"Nombre: {c.Nombre} | Categoria: {c.Categoria} | Sueldo actual: {c.Sueldo_actual} | Salario recomendado: {c.Salario_recomendado} | Número de proyectos: {c.NumeroProyectos}");
            }
        }

        private void GestionarEmpresas()
        {
            bool volver = false;
            GestionEmpresas ge = new GestionEmpresas();

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE EMPRESAS ===");
                Console.WriteLine("1. Listar empresas");
                Console.WriteLine("2. Añadir empresa");
                Console.WriteLine("3. Modificar telefono");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        List<Empresas> empresas = ge.GetListaEmpresas();
                        Console.WriteLine("\nLISTADO DE EMPRESAS:");
                        foreach (Empresas e in empresas)
                        {
                            Console.WriteLine($"Id: {e.Id} | Nombre: {e.Nombre} | Dirección: {e.Direccion} | CIF: {e.Cif} | Teléfono: {e.Telefono}");
                        }
                        break;
                    case "2":
                       
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Dirección: ");
                        string direccion = Console.ReadLine();
                        Console.Write("CIF: ");
                        string cif = Console.ReadLine();
                        Console.Write("Teléfono: ");
                        string telefono = Console.ReadLine();

                        Empresas nuevaEmpresa = new Empresas
                        {
                            Nombre = nombre,
                            Direccion = direccion,
                            Cif = cif,
                            Telefono = telefono
                        };
                        ge.InsertarEmpresas(nuevaEmpresa);
                        break;
                    case "3":
                        break;

                    case "4":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
                if (!volver)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        private void GestionarProyectos()
        {
            bool volver = false;
            GestionProyectos gp = new GestionProyectos();
            GestionEmpresas ge = new GestionEmpresas();
            GestionConsultores gc = new GestionConsultores();

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PROYECTOS ===");
                Console.WriteLine("1. Listar proyectos");
                Console.WriteLine("2. Añadir proyecto");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        List<Proyectos> proyectos = gp.GetListaProyectos();
                        Console.WriteLine("\nLISTADO DE PROYECTOS:");
                        foreach (Proyectos p in proyectos)
                        {
                            Console.WriteLine($"Id: {p.Id} | Descripción: {p.Descripcion} | Coste: {p.Coste} | Precio: {p.Precio} | Consultor: {p.Id_consultor.Nombre} | Empresa: {p.Id_empresa.Nombre}");
                        }
                        break;
                    case "2":
                        List<Empresas> empresas = ge.GetListaEmpresas();
                        Console.WriteLine("\nEMPRESAS DISPONIBLES:");
                        foreach (Empresas e in empresas)
                        {
                            Console.WriteLine($"Id: {e.Id} | Nombre: {e.Nombre}");
                        }
                        Console.Write("Seleccione el Id de la empresa cliente: ");
                        int idEmpresa;
                        while (!int.TryParse(Console.ReadLine(), out idEmpresa) || !empresas.Any(e => e.Id == idEmpresa))
                        {
                            Console.Write("Id no válido. Introduzca un Id de empresa existente: ");
                        }

                        List<Consultor> consultores = gc.GetListaConsultores();
                        Console.WriteLine("\nCONSULTORES DISPONIBLES:");
                        foreach (Consultor c in consultores)
                        {
                            Console.WriteLine($"Id: {c.Id} | Nombre: {c.Nombre}");
                        }
                        Console.Write("Seleccione el Id del consultor: ");
                        int idConsultor;
                        while (!int.TryParse(Console.ReadLine(), out idConsultor) || !consultores.Any(c => c.Id == idConsultor))
                        {
                            Console.Write("Id no válido. Introduzca un Id de consultor existente: ");
                        }

                        Console.Write("Descripción del proyecto: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Coste: ");
                        double coste;
                        while (!double.TryParse(Console.ReadLine(), out coste))
                        {
                            Console.Write("Coste no válido. Introduzca un número: ");
                        }
                        Console.Write("Precio de venta: ");
                        double precio;
                        while (!double.TryParse(Console.ReadLine(), out precio))
                        {
                            Console.Write("Precio no válido. Introduzca un número: ");
                        }

                        Proyectos nuevoProyecto = new Proyectos
                        {
                            Descripcion = descripcion,
                            Coste = coste,
                            Precio = precio,
                            Id_consultor = new Consultor { Id = idConsultor },
                            Id_empresa = new Empresas { Id = idEmpresa }
                        };
                        gp.InsertarProyecto(nuevoProyecto);
                        break;
                    case "3":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (!volver)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }




    }
}
