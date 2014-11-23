using System.Collections.Generic;

namespace NumerosPerfectos.Abstracciones
{
    public interface ICalificadorNumeros
    {
        bool EsPerfecto(int numero);
        IEnumerable<int> DeterminarNrosPerfectos(List<int> nros);
        bool EsAbundante(int numero);
        bool EsPrimo(int numero);
        ClasificacionNumero ClasificarNumero(int numero);
        List<NumeroClasificado> ClasificarNumeros(List<int> numeros);
    }
}