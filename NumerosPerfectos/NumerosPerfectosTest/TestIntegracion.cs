using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumerosPerfectos;
using NumerosPerfectos.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerosPerfectosTest
{
    [TestClass]
    public class TestIntegracion
    {
        AutoMoqer _automoqer;
        EvaluadorNumerosPerfectos _evaluador;
        ISumador _sumador;
        IDivisorProvider _divisor;

        [TestInitialize]
        public void Setup()
        {
            _automoqer = new AutoMoqer();
            _divisor = _automoqer.Resolve<DivisorProvider>();
            _sumador = _automoqer.Resolve<Sumador>();
            _evaluador = new EvaluadorNumerosPerfectos(_sumador, _divisor);            
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero3NoEsPerfecto()
        {
            // ACT
            var esPerfecto = _evaluador.EsPerfecto(3);

            // ASSERT
            Assert.IsFalse(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero6EsPerfecto()
        {
            // ACT
            var esPerfecto = _evaluador.EsPerfecto(6);

            // ASSERT
            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero496EsPerfecto()
        {
            // ACT
            var esPerfecto = _evaluador.EsPerfecto(496);

            // ASSERT
            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void ElNumero28EsPerfecto()
        {
            // ACT
            var esPerfecto = _evaluador.EsPerfecto(28);

            // ASSERT
            Assert.IsTrue(esPerfecto);
        }

        [TestMethod]
        [TestCategory("Integracion")]
        public void EntreEl1yEl496SoloHay3NrosPerfectos()
        {
            var nrosPerfectos = new List<int>();
            for (int i = 1; i <= 496; i++)
            {
                if (_evaluador.EsPerfecto(i))
                {
                    nrosPerfectos.Add(i);
                }
            }

            Assert.AreEqual(3, nrosPerfectos.Count);
        }
    }
}
