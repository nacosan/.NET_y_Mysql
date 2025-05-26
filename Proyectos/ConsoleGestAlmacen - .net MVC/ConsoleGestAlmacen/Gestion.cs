using System;
using System.Collections.Generic;
using ConsoleGestAlmacen.Controller;
using ConsoleGestAlmacen.Modelos;

namespace ConsoleGestAlmacen
{
    internal class Gestion
    {
        private readonly ProductoController _productoController = new ProductoController();
        private readonly EntradasController _entradasController = new EntradasController();
        private readonly SalidasController _salidasController = new SalidasController();

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
                        ConsultarProductos();
                        break;
                    case "2":
                        GestionarEntradas();
                        break;
                    case "3":
                        MostrarStock();
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
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE ALMACÉN ===");
            Console.WriteLine("1. Consultar productos");
            Console.WriteLine("2. Gestionar entradas");
            Console.WriteLine("3. Ver stock actual");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private void ConsultarProductos()
        {
            List<Producto> productos = _productoController.GetListaProductos();

            Console.WriteLine("\nLISTADO DE PRODUCTOS:");
            foreach (Producto p in productos)
            {
                Console.WriteLine($"Código: {p.Codigo} | Nombre: {p.Nombre} | Tipo: {p.Tipo}");
            }
        }

        private void GestionarEntradas()
        {
            Console.WriteLine("\nGESTIÓN DE ENTRADAS");

            string codigo;
            do
            {
                Console.Write("Ingrese código de producto: ");
                codigo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(codigo))
                {
                    Console.WriteLine("El código no puede estar vacío. Inténtelo de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(codigo));

            int cantidad;
            while (true)
            {
                Console.Write("Ingrese cantidad: ");
                string cantidadInput = Console.ReadLine();
                if (!int.TryParse(cantidadInput, out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Debe ingresar un número entero positivo. Inténtelo de nuevo.");
                }
                else
                {
                    break;
                }
            }

            Producto producto = new Producto { Codigo = codigo };
            bool resultado = _entradasController.InsertarEntradas(producto, cantidad);

            Console.WriteLine(resultado
                ? "Entrada registrada correctamente"
                : "Error al registrar la entrada");
        }



        private void MostrarStock()
        {
            var listaStock = _productoController.GetStockActual();

            Console.WriteLine("\nSTOCK ACTUAL DE PRODUCTOS:");
            foreach (var item in listaStock)
            {
                Console.WriteLine($"Código: {item.Codigo} | Nombre: {item.Nombre} | Tipo: {item.Tipo} | Stock: {item.StockActual}");
            }
        }

    }
}
