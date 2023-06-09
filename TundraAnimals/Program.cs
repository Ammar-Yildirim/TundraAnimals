using System.Linq;
using TextFile;

namespace TundraAnimals
{
    internal class Program
    {
        #region Complementary Functions For the Main program
        static bool PreysAreExtinct(List<Prey> animals)
        {
            return animals.Count == 0;
        }
        static int CalculateTotalSize(List<Prey> animals)
        {
            int sum = 0;
            foreach(Prey prey in animals)
            {
                sum += prey.size;
            }
            return sum;
        }
        static void PrintAll(List<Prey> preys, List<Predator> predators)
        {
            Console.WriteLine("Preys: ");
            foreach (Prey p in preys)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Predators: ");
            foreach (Predator p in predators)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("*******************************");
        }
        static void ReadFile(string fileName, ref List<Prey> preys, ref List<Predator> predators)
        {
            TextFileReader r = new TextFileReader(fileName);

            r.ReadInt(out int noOfPreyColonies);
            r.ReadInt(out int noOfPredatorColonies);

            for (int i = 0; i < noOfPreyColonies + noOfPredatorColonies; i++)
            {
                r.ReadString(out string name);
                r.ReadString(out string type);
                r.ReadInt(out int size);

                switch (type)
                {
                    case "l":
                        preys.Add(new Lemming(name, size));
                        break;
                    case "h":
                        preys.Add(new Hare(name, size));
                        break;
                    case "g":
                        preys.Add(new Gopher(name, size));
                        break;
                    case "o":
                        predators.Add(new Owl(name, size));
                        break;
                    case "f":
                        predators.Add(new Fox(name, size));
                        break;
                    case "w":
                        predators.Add(new Wolf(name, size));
                        break;
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            int startingPreyValue;

            List<Prey> preys = new List<Prey>();
            List<Predator> predators = new List<Predator>();
            List<Prey> finished = new List<Prey>();
            

            ///Reading the input
            ///

            ReadFile("input.txt", ref preys, ref predators);

            ///Perform the Operations
            ///
            Console.WriteLine("STARTING VALUES");
            PrintAll(preys, predators);

            startingPreyValue = CalculateTotalSize(preys);
            int round = 1;
            while (!PreysAreExtinct(preys) && !(CalculateTotalSize(preys) >= startingPreyValue * 4 ))
            {
                foreach (Colony colony in predators.Concat<Colony>(preys))
                {
                    colony.Reproduce(round);

                    if (colony is Prey prey)
                    {
                        prey.CheckNumber();
                    }
                    
                    if (colony is Predator predator && preys.Count > 0)
                    {
                        Prey p = Predator.ChoosePrey(preys);
                        predator.AttackPrey(p);
                        if (p.IsExtinct()) //If the Prey goes extinct after we attack, we remove it
                        {
                            finished.Add(p);
                            preys.Remove(p);
                        }
                        if (predator.IsExtinct())
                        {
                            predators.Remove(predator);
                        }
                    }
                }
                PrintAll(preys, predators);
                round++;
            }
            Console.WriteLine("The following prey colonies went extinct: ");
            foreach( Prey prey in finished)
            {
                Console.Write(prey.name + " ");
            }
        }
    }
}