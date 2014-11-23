using NumerosPerfectos.Abstracciones;
using System.Collections.Generic;

namespace NumerosPerfectos
{
    public class DivisorProvider : IDivisorProvider
    {
        public List<int> ObtenerDivisores(int p)
        {
            var divisores = new List<int>();
            for (int i = 1; i <= p; i++)
            {
                if (p % i == 0) divisores.Add(i);
            }

            return divisores;
        }
    }
}
