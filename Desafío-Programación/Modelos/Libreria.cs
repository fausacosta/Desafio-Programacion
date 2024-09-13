using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafío_Programación.Modelos
{
    public class Libreria
    {
        public Dictionary<string, List<Libro>> Categorias { get; private set; }

        public Libreria()
        {

            Categorias = new Dictionary<string, List<Libro>>();



            Categorias["Romance"] = new List<Libro>
        {
            new Libro("Orgullo y prejuicio", 29, 10)
        };
            Categorias["Misterio"] = new List<Libro>
        {
            new Libro("Estudio en escarlata", 49, 3)
        };
            Categorias["Historia"] = new List<Libro>
        {
            new Libro("Historia Argentina", 30, 15)
        };
            Categorias["Ciencia"] = new List<Libro>
        {
            new Libro("El gen egoista", 22, 13)
        };
            Categorias["Ficcion"] = new List<Libro>
        {
            new Libro("El imperio final", 50, 25)
        };
        }

        public void MostrarCategorias()
        {
            Console.WriteLine("Categorías: ");
            foreach (var categoria in Categorias.Keys)
            {
                Console.WriteLine($"- {categoria}");
            }
        }
        public void MostrarCategorias(string categoria)
        {
            if (Categorias.ContainsKey(categoria))
            {
                Console.WriteLine($"Libros{categoria}: ");
                foreach (var libro in Categorias[categoria])
                {
                    libro.MostrarDetalles();
                }
            }
            else
            {
                Console.WriteLine("No se encontro la categoría.");
            }
        }
        public void MostrarLibrosCategoria(string categoria)
        {
            if (Categorias.ContainsKey(categoria))
            {
                Console.WriteLine($"Libros {categoria}:");
                foreach (var libro in Categorias[categoria])
                {
                    libro.MostrarDetalles();
                }
            }
            else
            {
                Console.WriteLine("Categoria no encontrada.");
            }
        }
        public bool ProcesarCompra(Libro libro, int cantidad)
        {
            if (libro.Stock >= cantidad)
            {
                libro.Stock -= cantidad;
                Console.WriteLine($"Compra exitosa. {cantidad} unidades de '{libro.Nombre}' adquiridas.");
                return true;
            }
            else
            {
                Console.WriteLine("Sin stock.");
                return false;
            }
        }
    }
}
