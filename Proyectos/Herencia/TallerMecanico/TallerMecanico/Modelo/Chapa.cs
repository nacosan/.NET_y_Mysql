using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Modelo
{
    internal class Chapa:Trabajos
    {
        internal double _Multiplicador { get; } = 1.3;

        public Chapa(int id, int estado, string descripcion, int horas)
        : base(id, descripcion, horas, estado, "", 0)
        {
        }

       
    }
}
