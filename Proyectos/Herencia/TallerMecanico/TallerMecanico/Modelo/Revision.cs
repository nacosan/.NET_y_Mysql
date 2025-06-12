using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Modelo
{
    internal class Revision:Trabajos
    {
        internal int _Fijo { get; } = 20;
        

        public Revision(int id, string descripcion, int horas, int estado, string piezas, int precio) : base(id, descripcion, horas, estado, piezas, precio)
        {
        }
    }
}
