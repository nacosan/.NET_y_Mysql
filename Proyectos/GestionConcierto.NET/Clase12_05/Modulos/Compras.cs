using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase12_05.Modulos;

namespace Clase12_05.Modulos
{
    internal class Compra
    {
        public int IdCompra { get; set; }
        public Usuarios obUsuario { get; set; }

        public Evento obEvento { get; set; }

        public DateTime FechaCompra { get; set; }


        public override string ToString()
        {
            return $"Compra #{IdCompra} | Usuario: {obUsuario?.Nombre} | Evento: {obEvento?.NombreEvento} | Fecha Evento: {obEvento?.FechaEvento:d} | Precio: {obEvento?.precioEvento:f} | Fecha Compra: {FechaCompra:g}";
        }

    }
}
