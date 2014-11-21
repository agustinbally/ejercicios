using System;
using System.Collections.Generic;

namespace NumerosPerfectos.Abstracciones
{
    public interface IDivisorProvider
    {
        List<int> ObtenerDivisores(int p);
    }
}
