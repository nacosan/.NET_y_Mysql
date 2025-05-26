using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresaTecnologica.Modelos
{
    internal class Consultor
    {
        public int Id { get; set; }

        public String Nombre { get; set; }
        public String Categoria { get; set; }

        public double Sueldo_actual { get; set; }
        public double Salario_recomendado { get; set; }




        public override string ToString()
        {
            return $"Id #{Id} | Nombre : {Nombre} | Categoria: {Categoria} | Sueldo_actual: {Sueldo_actual} | Salario_recomendado: {Salario_recomendado}" ;
        }
    }
}
