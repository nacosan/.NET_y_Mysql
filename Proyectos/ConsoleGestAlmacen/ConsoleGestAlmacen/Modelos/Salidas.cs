using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestAlmacen.Modelos
{
    internal class Salidas
    {
        public int Id { get; set; }

        public Producto MiProducto { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }
    }
}
