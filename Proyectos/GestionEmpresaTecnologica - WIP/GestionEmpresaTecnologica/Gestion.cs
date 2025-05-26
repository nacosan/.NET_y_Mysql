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
                      
                        break;
                    case "3":
                      
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

        Console.WriteLine("\nLISTADO DE PRODUCTOS:");
            foreach (Consultor c in consultor)
            {
                Console.WriteLine($"Nombre: {c.Nombre} | Categoria: {c.Categoria} | Sueldo actual: {c.Sueldo_actual} | Salario recomendado: {c.Salario_recomendado}");
            }
}



}
}
