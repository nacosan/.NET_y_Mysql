using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Modelo
{
    internal class Mecanica:Trabajos
    {
        internal double _Multiplicador { get; } = 1.1;

        public Mecanica(int id, int estado, string descripcion, int horas)
        : base(id, descripcion, horas, estado, "", 0)
        {
        }
    }
}
