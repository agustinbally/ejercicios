using NumerosPerfectos.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerosPerfectos
{
    public class EvaluadorNumerosPerfectos
    {
        ISumador _sumador;
        IDivisorProvider _divisorProvider;

        public EvaluadorNumerosPerfectos(ISumador sumador, IDivisorProvider divisorProvider)
        {
            _sumador = sumador;
            _divisorProvider = divisorProvider;
        }

        public bool EsPerfecto(int num)
        {
            var divisores = _divisorProvider.ObtenerDivisores(num);
            _sumador.Resetear();

            if (divisores != null)
            {
                foreach (var n in divisores)
                {
                    if (!n.Equals(num))
                    {
                         _sumador.Sumar(n);
                    }
                }              
            }

            return _sumador.Suma.Equals(num);
        }
    }
}
