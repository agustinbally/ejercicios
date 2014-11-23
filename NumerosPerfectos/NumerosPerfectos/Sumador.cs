using NumerosPerfectos.Abstracciones;

namespace NumerosPerfectos
{
    public class Sumador : ISumador
    {
        public Sumador Sumar(int sumando1, int sumando2)
        {
            Suma += sumando1 + sumando2;

            return this;
        }

        public int Suma { get; private set; }

        public Sumador Sumar(int sumando)
        {
            Suma += sumando;

            return this;
        }

        public void Resetear()
        {
            Suma = 0;
        }
    }
}
