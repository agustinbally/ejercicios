using NumerosPerfectos.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerosPerfectos
{
    public class CalificadorNumeros
    {
        ISumador _sumador;
        IDivisorProvider _divisorProvider;

        public CalificadorNumeros(ISumador sumador, IDivisorProvider divisorProvider)
        {
            _sumador = sumador;
            _divisorProvider = divisorProvider;
        }

        public bool EsPerfecto(int numero)
        {
            var divisores = _divisorProvider.ObtenerDivisores(numero);

            var suma = divisores.Where(d => d != numero).Sum();

            return suma.Equals(numero);
        }

        public IEnumerable<int> DeterminarNrosPerfectos(List<int> nros)
        {
            return nros.Where(EsPerfecto);
        }

        private bool EsAbundante(int numero)
        {
            var divisores = _divisorProvider.ObtenerDivisores(numero);
            divisores.Remove(numero);

            return divisores.Sum() > numero;
        }

        private bool EsPrimo(int numero)
        {
            var divisores = _divisorProvider.ObtenerDivisores(numero);

            return numero == 1 ? true : divisores.Count == 2;
        }

        public ClasificacionNumero ClasificarNumero(int numero)
        {
            var esAbundante = EsAbundante(numero);

            return new ClasificacionNumero
            {
                EsAbundante = esAbundante,
                EsDeficiente = !esAbundante,
                EsPrimo = EsPrimo(numero)
            };
        }
    }
}
