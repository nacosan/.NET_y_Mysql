using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerMecanico.Modelo;

namespace TallerMecanico.Controlador
{
    internal class MiControlador
    {
        private List<Trabajos> servicios = new List<Trabajos>();
        int ultimoId = 0;
        int est = 0;

        public void AltaMecanica( String descripcion, int horas)
        {
            ultimoId++;
            
            Mecanica m = new Mecanica(ultimoId, est, descripcion,horas);
            servicios.Add(m);
            
        }
        public void AltaChapa(String descripcion, int horas)
        {
            ultimoId++;
            Chapa c = new Chapa(ultimoId, est, descripcion, horas);
            servicios.Add(c);

        }
        public int ActualizaEstado(string descripcion, string piezas, int precio)
        {
            Trabajos t = Buscar(descripcion);
            if(t != null)
            {

                t.setProp(piezas, precio);
                return t.Finalizar();
              
            }
            else
            {
                return -99;
            }
           
        }

        public Trabajos Buscar(String descripcion)
        {
            foreach (var t in servicios)
            {
                t.ToString();
                if(t.Descripcion == descripcion)
                {
                    return t;
                }
            }
            return null;
        }
        public List<Trabajos> ListarTrabajos()
        {
            return servicios;
        }
    }
}
