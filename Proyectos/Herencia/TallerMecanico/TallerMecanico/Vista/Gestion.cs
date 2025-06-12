using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Controlador;
using TallerMecanico.Modelo;

namespace TallerMecanico.Vista
{
    internal class Gestion
    {
        MiControlador c = new MiControlador();

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
                        MostrarTrabajos(c.ListarTrabajos());
                        break;
                    case "2":
                        AnadirServicios();
                        break;
                    case "3":
                        ActualizarTrabajo();
                        break;
                    case "4":
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
            Console.WriteLine("=== SISTEMA DE TALLER ===");
            Console.WriteLine("1. Consultar servicios");
            Console.WriteLine("2. Añadir servicios");
            Console.WriteLine("3. Actualizar servicios");
            Console.WriteLine("4. Buscar servicio");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
        }

        public void MostrarTrabajos(List<Trabajos> lista)
        {
            foreach (var trabajo in lista)
            {
                Console.WriteLine(trabajo); 
            }
        }

        public void AnadirServicios()
        {
            

            bool salir = false;
            while(!salir )
            {
                Console.WriteLine("=== ELIGE  UN SERVICIO===");
                Console.WriteLine("1. CHAPA Y PINTURA");
                Console.WriteLine("2. MECANICA");
                Console.WriteLine("3. REVISION");
                Console.WriteLine("5. SALIR");
                string opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        Console.WriteLine("Introduce la descripción");
                        string desc = Console.ReadLine();
                        Console.WriteLine("Introduce las horas para finalizarlo");
                        int hor = int.Parse(Console.ReadLine());
                        c.AltaChapa(desc, hor);

                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("Volviendo al menú principal");
                        break;
                }

            }
        }
        public void ActualizarTrabajo()
        {
            Console.WriteLine("Introduce la descripción para buscar el trabajo");
            var descr = Console.ReadLine();
            Console.WriteLine("Introduce las piezas");
            var pieza = Console.ReadLine();
            Console.WriteLine("Introduce el precio total");
            var prec = int.Parse(Console.ReadLine());

            c.ActualizaEstado(descr, pieza, prec);
        }

    }
}

