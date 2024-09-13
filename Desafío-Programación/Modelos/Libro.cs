using Desafío_Programación.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafío_Programación.Modelos
{
    public class Libro : ILibreria
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Libro(string nombre, decimal precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Nombre: {Nombre}\n Precio: {Precio}\n Stock: {Stock}");
        }
    }
}
