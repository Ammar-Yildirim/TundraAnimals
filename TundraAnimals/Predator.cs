using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TundraAnimals
{
    public abstract class Predator : Colony
    {
        public int starting_value;
        protected Predator(string name, int size) : base(name, size) { starting_value = size; }

        //Reproduce
        protected override void CalculateReproduction()
        {
            size += PredatorReproductionRatio();
        }
        protected abstract int PredatorReproductionRatio();
        protected override int ReproductionTime()
        {
            return 8;
        }

        //Attack
        public static Prey ChoosePrey(List<Prey> preys)
        {
            int randomNo = 0;
            if(preys.Count != 0)
            {
                Random rnd = new Random();
                randomNo = rnd.Next(0, preys.Count);
            }

            return preys[randomNo];
        }
        public void AttackPrey(Prey p)
        {
            p.HuntedBy(this);
        }
        
    }
    public class Owl : Predator
    {
        public Owl(string name, int size) : base(name, size) { }

        protected override int PredatorReproductionRatio()
        {
            return size / 4;
        }
    }
    public class Fox : Predator
    {
        public Fox(string name, int size) : base(name, size) { }

        protected override int PredatorReproductionRatio()
        {
            return (size / 4) * 3;
        }
    }
    public class Wolf : Predator
    {
        public Wolf(string name, int size) : base(name, size) { }

        protected override int PredatorReproductionRatio()
        {
            return (size / 4) * 2;
        }
    }
}
