using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contador
{
    public class MiContador
    {
        public int ValorIncremento { get; private set; }
        public int ValorInicial { get; private set; }
        public int Limite { get; private set; }

        public MiContador(int inicial, int incremento, int limite)
        {
            ValorInicial = inicial;
            valorActual = inicial;
            ValorIncremento = incremento;
            Limite = limite;            
        }

        public MiContador(int limite) : this(0, 1, limite)
        {
        }

        public bool Incrementar()
        {
            this.valorActual += this.ValorIncremento;

            var superaLimite = this.ValorActual > this.Limite;
            if (superaLimite)
            {
                this.valorActual = 0;
            }
            
            return superaLimite;
        }

        private int valorActual;
        public int ValorActual 
        {
            get { return valorActual; }
            private set { this.valorActual = value; }
        }

        public void Resetear()
        {
            this.ValorActual = this.ValorInicial;
        }
    }
}
