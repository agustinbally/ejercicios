using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumerosPerfectos;
using NumerosPerfectos.Abstracciones;
using System.Collections.Generic;
using System.Linq;

namespace NumerosPerfectosTest
{
    [TestClass]
    public class TestIntegracion
    {
        AutoMoqer _automoqer;
        CalificadorNumeros _calificadorNros;
        IDivisorProvider _divisor;

        [TestInitialize]
        public void Setup()
        {
            _automoqer = new AutoMoqer();
            _divisor = _automoqer.Resolve<DivisorProvider>();
            _calificadorNros = new CalificadorNumeros(_divisor);            
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero3NoEsPerfecto()
        {
            // ACT
            var esPerfecto = _calificadorNros.EsPerfecto(3);

            // ASSERT
            Assert.IsFalse(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero6EsPerfecto()
        {
            // ACT
            var esPerfecto = _calificadorNros.EsPerfecto(6);

            // ASSERT
            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero496EsPerfecto()
        {
            // ACT
            var esPerfecto = _calificadorNros.EsPerfecto(496);

            // ASSERT
            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero28EsPerfecto()
        {
            // ACT
            var esPerfecto = _calificadorNros.EsPerfecto(28);

            // ASSERT
            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void EntreEl1YEl496SoloHay3NrosPerfectos()
        {
            var nrosPerfectos = new List<int>();
            for (int i = 1; i <= 496; i++)
            {
                if (_calificadorNros.EsPerfecto(i))
                {
                    nrosPerfectos.Add(i);
                }
            }

            Assert.AreEqual(3, nrosPerfectos.Count);

            Assert.IsTrue(nrosPerfectos.Contains(6));
            Assert.IsTrue(nrosPerfectos.Contains(28));
            Assert.IsTrue(nrosPerfectos.Contains(496));
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void DebeDeterminarQueEl6EsPerfectoEnUnaListaDeNros_SoloEl6Perfecto()
        {
            var nros = new List<int> { 1, 5, 6, 9 };

            var nrosPerfectos = _calificadorNros.DeterminarNrosPerfectos(nros);
           
            Assert.AreEqual(1, nrosPerfectos.Count());
            Assert.AreEqual(6, nrosPerfectos.First());
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void EnLaListaNoHayNrosPerfectos()
        {
            var nros = new List<int> { 1, 5, 9 };

            var nrosPerfectos = _calificadorNros.DeterminarNrosPerfectos(nros);

            Assert.AreEqual(0, nrosPerfectos.Count());
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void SonTresNrosPerfectos()
        {
            var nros = new List<int> { 6, 28, 496 };

            var nrosPerfectos = _calificadorNros.DeterminarNrosPerfectos(nros);

            Assert.AreEqual(3, nrosPerfectos.Count());
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero12ComoAbundante()
        {
            const int numero = 12;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsTrue(clasificacionNro.EsAbundante);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero9ComoNoAbundante()
        {
            const int numero = 9;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsFalse(clasificacionNro.EsAbundante);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero9ComoDeficiente()
        {
            const int numero = 9;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsTrue(clasificacionNro.EsDeficiente);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero12ComoNoDeficiente()
        {
            const int numero = 12;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsFalse(clasificacionNro.EsDeficiente);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero1ComoPrimo()
        {
            const int numero = 1;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsTrue(clasificacionNro.EsPrimo);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero3ComoPrimo()
        {
            const int numero = 3;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsTrue(clasificacionNro.EsPrimo);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero4ComoNoPrimo()
        {
            const int numero = 4;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsFalse(clasificacionNro.EsPrimo);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void QuieroClasificarElNumero0ComoNoPrimo()
        {
            const int numero = 0;

            ClasificacionNumero clasificacionNro = _calificadorNros.ClasificarNumero(numero);

            Assert.IsFalse(clasificacionNro.EsPrimo);
        }
    }
}
