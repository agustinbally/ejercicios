using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumerosPerfectos;
using NumerosPerfectos.Abstracciones;
using System.Collections.Generic;
using Moq;
using AutoMoq;

namespace NumerosPerfectosTest
{
    [TestClass]
    public class NumerosPerfectosTestFixture
    {
        AutoMoqer _automoqer;
        CalificadorNumeros _calificadorNros;
        Mock<IDivisorProvider> _divisorMoq;

        [TestInitialize]
        public void Setup()
        {
            _automoqer = new AutoMoqer();
            _calificadorNros = _automoqer.Resolve<CalificadorNumeros>();
            _divisorMoq = _automoqer.GetMock<IDivisorProvider>();
        }


        [TestMethod]
        public void DebeRetornarQueUnoNoEsPerfecto()
        {
            var num = 8;

            _divisorMoq.Setup(d => d.ObtenerDivisores(num)).Returns(new List<int> {1});

            var esPerfecto = _calificadorNros.EsPerfecto(num);
            
            Assert.IsFalse(esPerfecto);
        }

        [TestMethod]
        public void DebeRetornarQueDosNoEsPerfecto()
        {
            var num = 8;

            _divisorMoq.Setup(d => d.ObtenerDivisores(num)).Returns(new List<int> { 1,2,5 });

            var esPerfecto = _calificadorNros.EsPerfecto(num);

            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        public void SiLosDivisoresSon1_2yElNroEs3_yLaSumaEs3_EtoncesEsPerfecto()
        {
            // ARRANGE
            var sumandos = new List<int> { 1, 2 };

            _divisorMoq.Setup(d => d.ObtenerDivisores(It.IsAny<int>()))
                .Returns(sumandos);

            // ACT
            var esPerfecto = _calificadorNros.EsPerfecto(3);

            // ASSERT
            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        public void ParaVerificarSiUnNroEsPerfectoTieneQueObtenerSusDivisores()
        {
            // ARRANGE
            var sumandos = new List<int> { 1, 2, 3, 4 };
            
            _divisorMoq.Setup(d => d.ObtenerDivisores(It.IsAny<int>()))
                .Returns(sumandos);
            
            // ACT
            var esPerfecto = _calificadorNros.EsPerfecto(6);

            // ASSERT
            _divisorMoq.Verify(d => d.ObtenerDivisores(It.IsAny<int>()), Times.Once());        
        }

    }

    [TestClass]
    public class DivisorProviderTestFixture
    {
        [TestMethod]
        public void DebeObtenerDivisorDe1()
        {
            var dp = new DivisorProvider();

            List<int> divisores = dp.ObtenerDivisores(1);

            Assert.AreEqual(1, divisores.Count());
            Assert.AreEqual(1, divisores.First());
        }

        [TestMethod]
        public void DebeObtenerDivisoresDe2()
        {
            var dp = new DivisorProvider();

            List<int> divisores = dp.ObtenerDivisores(2);

            Assert.AreEqual(2, divisores.Count());
            Assert.AreEqual(1, divisores.First());
            Assert.AreEqual(2, divisores.Last());
        }

        [TestMethod]
        public void DebeObtenerDivisoresDe3()
        {
            var dp = new DivisorProvider();

            List<int> divisores = dp.ObtenerDivisores(3);

            Assert.AreEqual(2, divisores.Count());
            Assert.AreEqual(1, divisores[0]);
            Assert.AreEqual(3, divisores[1]);
        }

        [TestMethod]
        public void UnNumeroSeTieneComoDivisorASiMismo()
        {
            var max = 20;
            for (int i = 1; i < max; i++)
            {
                 Assert.IsTrue( new DivisorProvider().ObtenerDivisores(i).Contains(i));
            }
        }
    }

    [TestClass]
    public class SumadorTestFixture
    {
        [TestMethod]
        public void DebeSumarNumeros1YDar2()
        {
            var sumador = new Sumador();

            sumador.Sumar(1, 1);

            Assert.AreEqual(2, sumador.Suma);
        }

        [TestMethod]
        public void DebeSumar1Y2Ydar3()
        {
            var sumador = new Sumador();
            sumador.Sumar(1, 2);
            Assert.AreEqual(3, sumador.Suma);
        }

        [TestMethod]
        public void DebeSumar1Y2Y3YDar6()
        {
            var sumador = new Sumador();
            sumador.Sumar(1,2);
            sumador.Sumar(3);

            Assert.AreEqual(6, sumador.Suma);
        }

        [TestMethod]
        public void DebeSumarCuatroVeces1YDar4()
        {
            var sumador = new Sumador();
            sumador.Sumar(1, 1).Sumar(1).Sumar(1);            

            Assert.AreEqual(4, sumador.Suma);
        }

        [TestMethod]
        public void AlSumarYLuegoResetearLaSumaTieneQueQuedarEnCero()
        {
            var sumador = new Sumador();
            sumador.Sumar(1, 1).Sumar(1).Sumar(1);

            sumador.Resetear();

            Assert.AreEqual(0, sumador.Suma);
        }
    }
}
