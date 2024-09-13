using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafío_Programación.Modelos
{
    public class Usuario
    {
        public string NombreDeUsuario { get; set; }
        public string Contraseña { get; set; }

        public Usuario(string nombreDeUsuario, string contraseña)
        {
            NombreDeUsuario = nombreDeUsuario;
            Contraseña = contraseña;
        }
        public bool InicioDeSesion(string nombreDeUsuario, string contraseña)
        {
            return NombreDeUsuario == nombreDeUsuario && Contraseña == contraseña;
        }
    }
}
