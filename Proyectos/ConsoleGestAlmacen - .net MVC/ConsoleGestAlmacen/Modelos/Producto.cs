using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestAlmacen.Modelos
{
    internal class Producto
    {
        public int Id { get; set; }

        public String Codigo { get; set; }
        public String Tipo { get; set; }

        public String Nombre { get; set; }

        public override string ToString()
        {
            return $"Id #{Id} | Codigo : {Codigo} | Nombre: {Nombre} | Tipo: {Tipo}";
        }
    }
}
