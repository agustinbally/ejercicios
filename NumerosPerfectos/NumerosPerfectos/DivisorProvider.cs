using NumerosPerfectos.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
