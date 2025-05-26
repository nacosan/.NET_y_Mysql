using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpresaTecnologica.Modelos
{
    internal class Empresas
    {
        public int Id { get; set; }

        public String Nombre { get; set; }
        public String Direccion { get; set; }

        public String Cif { get; set; }
        public String Telefono{ get; set; }




        public override string ToString()
        {
            return $"Id #{Id} | Nombre : {Nombre} | Direccion: {Direccion} | Cif: {Cif} | Telefono: {Telefono}";
        }

    }
}
