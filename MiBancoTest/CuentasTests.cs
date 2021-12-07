using MiBanco.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiBancoTest
{
    [TestClass]
    public class CuentasTests
    {
        [TestMethod]
        public void Establecer_Saldo_Inicio_Invalido_Error()
        {
            // arrange
            var cuenta = new MiBanco.Domain.Cuenta();
            var importe = 0m;

            // act 
            // assets
            Assert.ThrowsException<System.ArgumentException>(() => cuenta.SaldoInicio(importe));
        }

        [TestMethod]
        public void Establecer_Saldo_Inicio_Valido_Ok()
        {
            // arrange
            var cuenta = new MiBanco.Domain.Cuenta();
            var importe = 1000m;
            var saldoEsperado = 1000m;

            // act
            cuenta.SaldoInicio(importe);

            // act and assets
            Assert.AreEqual(saldoEsperado, importe);
            Assert.AreEqual(cuenta.Estado, EstadoCuenta.Abierta); //
        }

        [TestMethod]
        public void Depositar_Saldo_Incrementado_Ok()
        {
            // arrange
            var cuenta = new MiBanco.Domain.Cuenta();
            var saldoInicio = 1000m;
            var importeDepositado = 2000m;
            var saldoEsperado = 3000m;
            cuenta.SaldoInicio(saldoInicio);

            // act
            cuenta.Depositar(importeDepositado);

            // act and assets
            Assert.AreEqual(saldoEsperado, cuenta.Saldo);
        }

        [TestMethod]
        public void Extraer_Importe_Invalido_Error()
        {
            // arrange
            var cuenta = new MiBanco.Domain.Cuenta();
            var saldoInicio = 1000m;
            var importeExtraido = 2000m;            
            cuenta.SaldoInicio(saldoInicio);

            // act
            // assets
            Assert.ThrowsException<System.ArgumentException>(() => cuenta.Extraer(importeExtraido));
        }
    }
}
