using NumerosPerfectos.Abstracciones;
using System.Collections.Generic;
using System.Linq;

namespace NumerosPerfectos
{
    public class CalificadorNumeros : ICalificadorNumeros
    {
        readonly IDivisorProvider _divisorProvider;

        public CalificadorNumeros(IDivisorProvider divisorProvider)
        {
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

        public bool EsAbundante(int numero)
        {
            var divisores = _divisorProvider.ObtenerDivisores(numero);
            divisores.Remove(numero);

            return divisores.Sum() > numero;
        }

        public bool EsPrimo(int numero)
        {
            var divisores = _divisorProvider.ObtenerDivisores(numero);

            return divisores.Count == 2;
        }

        public ClasificacionNumero ClasificarNumero(int numero)
        {
            var esAbundante = EsAbundante(numero);

            return new ClasificacionNumero
            {
                EsAbundante = esAbundante,
                EsDeficiente = !esAbundante,
                EsPrimo = EsPrimo(numero),
                EsPerfecto = EsPerfecto(numero)
            };
        }

        public List<NumeroClasificado> ClasificarNumeros(List<int> numeros)
        {
            return numeros.ConvertAll(n => new NumeroClasificado
            {
                Numero = n,
                Clasificacion = ClasificarNumero(n)
            });            
        }
    }
}
