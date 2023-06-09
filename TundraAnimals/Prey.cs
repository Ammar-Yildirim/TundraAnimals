using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TundraAnimals
{
    public abstract class Prey : Colony
    {
        protected Prey(string name, int size) : base(name, size) { }

        //What happens when a prey is attacked?
        public void HuntedBy(Predator predator)
        {
            if (size - (Multiplier() * predator.size) < 0)
            {   
                predator.size = size / Multiplier();
                size = 0;
            }
            else
            {
                size -= (Multiplier() * predator.size);
            }
        }
        protected virtual int Multiplier()
        {
            return 2;
        }

        //Reproduction
        protected override void CalculateReproduction() {
            size = (int)Math.Floor(Convert.ToDouble(size) * PreyReproductionRatio());
        }
        protected virtual double PreyReproductionRatio() { return 2; }
        protected override int ReproductionTime() { return 2; }

        //What happens when there are too many animals?
        public void CheckNumber()
        {
            if (this.size > MaxSize())
            {
                this.size = NewSize();
            }
        }
        protected virtual int MaxSize()
        {
            return 200;
        }
        protected abstract int NewSize();
    }
    public class Lemming : Prey
    {
        public Lemming(string name, int size) : base(name, size) { }

        //What happens when attacked
        protected override int Multiplier() { return 4; }
        //Reproduction

        //What happens when too many animals are present
        protected override int NewSize() { return 30; }
    }
    public class Hare : Prey
    {
        public Hare(string name, int size) : base(name, size) { }
        //What happens when attacked

        //Reproduction
        protected override double PreyReproductionRatio() { return 1.5; }
        //What happens when too many animals are present
        protected override int MaxSize() { return 100; }
        protected override int NewSize() { return 20; }
    }
    public class Gopher : Prey
    {
        public Gopher(string name, int size) : base(name, size) { }
        //What happens when attacked

        //Reproduction
        protected override int ReproductionTime() { return 4; }
        //What happens when too many animals are present
        protected override int NewSize() { return 40; }
    }
}
