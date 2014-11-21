using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contador;
using System.Linq;

namespace ContadorTest
{
    [TestClass]
    public class MiContadorTest
    {
        [TestMethod]
        public void TengoQuePoderCrearUnContadorIndicandoValoresIniciales()
        {
            const int inicial = 0;
            const int incremento = 1;
            const int limite = 10;

            var miContador = new MiContador(inicial, incremento, limite);

            Assert.IsNotNull(miContador);
        }

        [TestMethod]
        public void DeboPoderCrearUnContadorConLimiteYTengaIncrementoYValorInicialPorDefecto()
        {
            const int limite = 10;

            var miContador = new MiContador(limite);

            Assert.IsNotNull(miContador);
            Assert.AreEqual(0, miContador.ValorInicial);
            Assert.AreEqual(1, miContador.ValorIncremento);
            Assert.AreEqual(limite, miContador.Limite);
        }

        [TestMethod]
        public void DebeIncrementarElContadorEn5()
        {
            var miContador = new MiContador(0, 1, 10);

            Enumerable.Range(1,5).ToList().ForEach(e => miContador.Incrementar());

            Assert.AreEqual(5, miContador.ValorActual);            
        }

        [TestMethod]
        public void DebeIncrementarElContadorEn1()
        {
            var miContador = new MiContador(0, 1, 10);

            miContador.Incrementar();

            Assert.AreEqual(1, miContador.ValorActual);
        }

        [TestMethod]
        public void DebeIndicarQueSuperoElLimite()
        {
            var miContador = new MiContador(4);
            bool superoElLimite = false;

            for (int idx = 1; idx <= 5; idx++)
            {
                superoElLimite = miContador.Incrementar();
            }

            Assert.IsTrue(superoElLimite);
        }

        [TestMethod]
        public void DebeIndicarQueNoSuperoElLimite()
        {
            var miContador = new MiContador(4);
            var superoElLimite = miContador.Incrementar();

            Assert.IsFalse(superoElLimite);
        }

        [TestMethod]
        public void DebeVolverALValorInicialCuandoSeSuperaElLimite()
        {
            var miContador = new MiContador(4);

            for (int idx = 1; idx <= 5; idx++)
            {
                miContador.Incrementar();
            }

            Assert.AreEqual(0, miContador.ValorActual);
        }

        [TestMethod]
        public void DebePoderVolverAlValorInicial()
        {
            var miContador = new MiContador(4);
            miContador.Resetear();

            Assert.AreEqual(0, miContador.ValorInicial);
        }
    }

    // Al crear el contador indicamos el valor inicial del mismo, el incremento y el valor límite.
    // El valor inicial y el incremento tomarán un valor de 0 y 1 respectivamente si no se indica nada. El límite es necesario indicarlo siempre.
    // Ninguno de los tres valores (valor inicial, incremento y límite) pueden cambiarse una vez creado el contador
    // Al incrementar el contador se suma al valor actual el incremento y nos indican si se superó el límite.
    // Cuando se supere el límite, el valor actual del contador vuelve a ser el valor inicial.
    // En cualquier momento se puede conocer el valor actual del contador y 
    // En cualquier momento se puede establecer el contador a su valor inicial.

}
