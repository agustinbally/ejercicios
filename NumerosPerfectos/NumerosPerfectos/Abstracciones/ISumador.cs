using System;

namespace NumerosPerfectos.Abstracciones
{
    public interface ISumador
    {
        int Suma { get; }
        Sumador Sumar(int sumando);
        Sumador Sumar(int sumando1, int sumando2);
        void Resetear();
    }
}
