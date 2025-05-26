using System;
using Clase12_05.Modulos;

namespace Clase12_05
{
    internal class Gestion
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
                        ConsultarEntradas();
                        break;
                    case "2":
                        ComprarEntrada();
                        break;
                    case "5":
                        salir = true;
                        Console.WriteLine("¡Hasta luego!");
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
            Console.WriteLine("--- Gestor de Compras de Entradas ---");
            Console.WriteLine("1. Consultar mis compras de entradas");
            Console.WriteLine("2. Comprar una nueva entrada");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }

        public void ConsultarEntradas()
        {
            Console.Write("\nIntroduce tu nombre de usuario (juanperez, mariagomez, carlossanchez): ");
            string nombreUsuario = Console.ReadLine();

            EntradasController entradasController = new EntradasController();
            var listado = entradasController.getListaEntradas(nombreUsuario);

            if (listado.Count == 0)
            {
                Console.WriteLine("\nNo se encontraron compras para este usuario.");
                return;
            }

            Console.WriteLine("\nTus compras:");
            foreach (Compra compra in listado)
            {
                Console.WriteLine(compra.ToString());
            }
        }

        public void ComprarEntrada()
        {
            Console.Write("\nIntroduce tu nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            EntradasController controller = new EntradasController();
            int resultado = controller.ComprarEntradas(nombreUsuario);

            switch (resultado)
            {
                case 1:
                    Console.WriteLine("Compra realizada exitosamente!");
                    break;
                case 0:
                    Console.WriteLine("Error al procesar la compra.");
                    break;
                case -1:
                    Console.WriteLine("Usuario no encontrado.");
                    break;
            }
        }
    }
}
