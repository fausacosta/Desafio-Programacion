using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafío_Programación.Interface
{
    public interface ILibreria
    {
        string Nombre { get; set; }
        decimal Precio { get; set; }
        int Stock { get; set; }

        void MostrarDetalles();
    }
}
