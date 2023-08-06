using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TundraAnimals
{
    public abstract class Colony
    {
        public string name { get; }
        public int size;

        protected Colony(string name, int size) 
        {
            this.name = name;
            this.size = size;
        }
        public void Reproduce(int roundNo)
        {
            if(roundNo != 0 && roundNo % ReproductionTime() == 0)
            {
                CalculateReproduction();
            }
        }
        protected abstract int ReproductionTime();
        protected abstract void CalculateReproduction();
        public bool IsExtinct()
        {
            return size == 0;
        }
        public override string ToString()
        {
            return $"{name} {size}";
        }
    }   
}
