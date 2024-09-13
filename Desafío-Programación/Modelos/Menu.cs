    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Desafío_Programación.Modelos
    {
    public class Menu
    {
        private Usuario usuarioActual;
        private Libreria libreria;

        public Menu()
        {
            libreria = new Libreria();
        }
        public void MenuMain()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido. ");
                Console.WriteLine("1) Iniciar Sesión.");
                Console.WriteLine("2) Registrarse.");
                Console.WriteLine("3) Salir.");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        if (IniciarSesion())
                        {
                            MostrarCategorias();
                        }
                        break;
                    case "2":
                        RegistrarUsuario();
                        break;
                    case "3":
                        Console.WriteLine("Adios.");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Seleccione una opcion valida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void RegistrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("REGISTRO.");
            Console.Write("Usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();
            usuarioActual = new Usuario(nombreUsuario, contrasena);
        }
        private bool IniciarSesion()
        {
            Console.Clear();

            if (usuarioActual == null)
            {
                Console.WriteLine("Crea un usuario.");
                Console.ReadKey();
                return false;
            }

            Console.Write("Usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Contraseña: ");
            string contrasena = Console.ReadLine();

            if (usuarioActual.InicioDeSesion(nombreUsuario, contrasena))
            {
                Console.WriteLine("Bienvenido.");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos.");
                Console.ReadKey();
                return false;
            }
        }
        private void MostrarCategorias()
        {
            Console.Clear();

            libreria.MostrarCategorias();
            Console.Write("Seleccione una categoría: ");
            string categoria = Console.ReadLine();
            libreria.MostrarLibrosCategoria(categoria);
            Console.Write("Ingrese el nombre del libro: ");
            string nombreLibro = Console.ReadLine();

            var libroSeleccionado = libreria.Categorias[categoria].Find(libro => libro.Nombre == nombreLibro);

            if (libroSeleccionado != null)
            {
                Console.Write("Ingrese la cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (libreria.ProcesarCompra(libroSeleccionado, cantidad))
                {
                    DatosTarjeta();
                }
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
                Console.ReadKey();
            }
        }
        private void DatosTarjeta()
        {
            Console.Clear();

            Console.Write("Numero de tarjeta: ");
            string numeroDeTarjeta = Console.ReadLine();
            Console.Write("Fecha de vencimiento (MM/AA): ");
            string fechaDeVencimiento = Console.ReadLine();
            Console.Write("Código de seguridad: ");
            string codigoDeSeguridad = Console.ReadLine();

            TarjetaDeCredito tarjeta = new TarjetaDeCredito(numeroDeTarjeta, fechaDeVencimiento, codigoDeSeguridad);

            if (tarjeta.VerificarLaTarjeta())
            {
                Console.WriteLine("Pago confirmado.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No se pudo completar la compra, intente nuevamente.");
                Console.ReadKey();
            }
        }
    }
}
