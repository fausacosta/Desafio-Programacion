using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafío_Programación.Modelos
{
    public class TarjetaDeCredito
    {
        public string NumeroDeTarjeta { get; set; }
        public string FechaDeVencimiento { get; set; }
        public string CodigoDeSeguridad { get; set; }

        public TarjetaDeCredito(string numeroDeTarjeta, string fechaDeVencimiento, string codigoDeSeguridad)
        {
            NumeroDeTarjeta = numeroDeTarjeta;
            FechaDeVencimiento = fechaDeVencimiento;
            CodigoDeSeguridad = codigoDeSeguridad;
        }
        public bool VerificarLaTarjeta()
        {
            return true;
        }
    }
}
