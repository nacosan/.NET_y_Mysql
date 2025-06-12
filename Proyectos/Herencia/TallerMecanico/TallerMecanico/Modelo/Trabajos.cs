using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.Modelo
{
    internal class Trabajos
    {
      int Id;
        internal String Descripcion { get; set; }
        int Horas;
        int Estado;
        String Piezas;
        int Precio;

        public Trabajos(int id, String descripcion, int horas, int estado, String piezas, int precio)
        {
            Id = id;
            Descripcion = descripcion;
            Horas = horas;
            Estado = estado;
            Piezas = piezas;
            Precio = precio;
        }

        public Trabajos(int id, int estado, String piezas, int precio)
        {
            Id = id;
            Estado = estado;
            Piezas = piezas;
            Precio = precio;
        }

       
        public int setDesc(string descripcion, int horas)
        {
            try
            {
                if(descripcion.Length > 0)
                {
                    Descripcion = descripcion;
                    Horas = horas;
                    return 0;
                }
                else if (descripcion.Length > 100)
                {
                    return -2;

                }
                return -1;
            }
            catch(Exception ex)
            {
                return -10;
            }
           
        }
        public int Finalizar()
        {
            int estado = 1;
            try
            {
                if (estado == 1)
                {
                    Estado = estado;
                    return 1;
                }
                return -1;
            }
            catch
            {
                return -10;
            }
        }
        public int setProp( String piezas, int precio)
        {
            try
            {
                if (Finalizar() == 1)
                {
                    Piezas = piezas;
                    double multiplicador = 1.0;
                    int fijo = 0;

                    if (this is Chapa c)
                    {
                        multiplicador = c._Multiplicador;
                        Precio = (int)(precio * multiplicador);
                    }
                    else if (this is Revision r)
                    {
                        fijo = r._Fijo;
                        Precio = precio + fijo; 
                    }
                    else if (this is Mecanica m)
                    {
                        multiplicador = m._Multiplicador;
                        Precio = (int)(precio * multiplicador);
                    }
                    else
                    {
                        Precio = precio; 
                    }

                    return 0;
                }
                return -1;
            }
            catch
            {
                return -10;
            }

        }
        public override string ToString()
        {
            return $"Id: {Id}, Descripcion: {Descripcion}, Horas: {Horas}, Estado: {Estado}, Piezas: {Piezas}, Precio: {Precio}";
        }



    }
}
