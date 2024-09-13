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
                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("1. Registrarse.");
                Console.WriteLine("2. Iniciar Sesión.");
                Console.WriteLine("3. Salir.");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarUsuario();
                        break;
                    case "2":
                        if (IniciarSesion())
                        {
                            MostrarCategorias();
                        }
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
            Console.Write("Ingresa tu usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Ingresa tu contraseña: ");
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

            Console.Write("Ingresa tu usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Ingresa tu contraseña: ");
            string contrasena = Console.ReadLine();

            if (usuarioActual.InicioDeSesion(nombreUsuario, contrasena))
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Nombre de usuario o contraseña incorrectos.");
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
                    SolicitarDatosTarjeta();
                }
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
                Console.ReadKey();
            }
        }
        private void SolicitarDatosTarjeta()
        {
            Console.Clear();

            Console.Write("Numero de tarjeta: ");
            string numeroTarjeta = Console.ReadLine();
            Console.Write("Fecha de vencimiento (MM/AA): ");
            string fechaVencimiento = Console.ReadLine();
            Console.Write("Código de seguridad: ");
            string codigoSeguridad = Console.ReadLine();

            TarjetaDeCredito tarjeta = new TarjetaDeCredito(numeroTarjeta, fechaVencimiento, codigoSeguridad);

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
