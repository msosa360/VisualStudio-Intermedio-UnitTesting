using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBanco.Domain
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public Banco Banco { get; set; }

        public decimal Saldo { get; set; }

        public EstadoCuenta Estado { get; set; }

        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }

        public void SaldoInicio(decimal importe)
        {
            if(importe <= 0)
                throw new ArgumentException("El saldo de inicio debe ser mayor a cero.", nameof(importe));

            Saldo = importe;
            Estado = EstadoCuenta.Abierta;
            FechaApertura = DateTime.Today;
        }

        public void Depositar (decimal importe)
        {
            Saldo = Saldo + importe;
        }

        public void Extraer(decimal importe)
        {
            if(Saldo >= importe)
            {
                Saldo -= importe;
            }
            else
            {
                throw new ArgumentException("El importe a debitar supera el saldo.", nameof(importe));
            }
        }

        public void Cerrar()
        {
            if(Saldo != 0)
                throw new Exception("La cuenta no puede cerrarse ya que el saldo es distinto de cero.");

            Estado = EstadoCuenta.Cerrada;
            FechaCierre = DateTime.Today;
        }
    }

    public enum EstadoCuenta
    {
        Abierta = 1,
        Cerrada
    }
}
