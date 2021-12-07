using MiBanco.Domain;
using System;

namespace MiBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema Bancario inicializado. ");
            
            var opcion = "";
            var cuenta = new Cuenta();
            do
            {

                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("------------------");
                Console.WriteLine("1 - Establecer Saldo de Inicio");
                Console.WriteLine("2 - Depositar Fondos");
                Console.WriteLine("3 - Extraer Fondos");
                Console.WriteLine("4 - Obtener Saldo");
                opcion = Console.ReadLine();

                try
                {
                    if (opcion == "1")
                    {
                        Console.WriteLine("Ingrese el Saldo de Inicio: ");
                        var importe = Console.ReadLine();
                        cuenta.SaldoInicio(Convert.ToDecimal(importe));
                    }

                    if (opcion == "2")
                    {
                        Console.WriteLine("Ingrese el Importe a Depositar: ");
                        var importe = Console.ReadLine();
                        cuenta.Depositar(Convert.ToDecimal(importe));
                    }

                    if (opcion == "3")
                    {
                        Console.WriteLine("Ingrese el Importe a Extraer: ");
                        var importe = Console.ReadLine();
                        cuenta.Extraer(Convert.ToDecimal(importe));
                    }

                    if (opcion == "4")
                    {
                        Console.WriteLine($"El saldo de la cuenta es de {cuenta.Saldo:n2}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"ERROR: {ex.Message}");
                }

                Console.WriteLine("");
                Console.WriteLine("");

            } while (opcion != "");
        }
    }
}
