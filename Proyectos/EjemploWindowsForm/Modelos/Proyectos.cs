using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresaTecnologica.Modelos
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    internal class Proyectos
    {
        public int Id { get; set; }

        public String Nombre { get; set; }

        public String Descripcion { get; set; }

        public double Coste { get; set; }

        public double Precio { get; set; }

        public Consultor Id_consultor { get; set; }

        public Empresas Id_empresa { get; set; }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
