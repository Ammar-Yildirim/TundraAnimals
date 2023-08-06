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
        public void AttackPrey(ref List<Prey> preys, ref List<Colony> finished, ref List<Predator> predators)
        {
            if (preys.Count == 0) return;

            Random rnd = new Random();
            int randomNo = rnd.Next(0, preys.Count);
            Prey prey = preys[randomNo];
            prey.HuntedBy(this);

            if (prey.IsExtinct())
            {
                finished.Add(prey);
                preys.Remove(prey);
                Console.WriteLine($"{prey.name} Extinct !!!");
            }
            if (this.IsExtinct())
            {
                finished.Add(this);
                predators.Remove(this);
                Console.WriteLine($"{this.name} Extinct !!!");
            }
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
