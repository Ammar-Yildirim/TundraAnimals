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
        static void PrintAll(List<Prey> preys, List<Predator> predators, int round)
        {
            Console.WriteLine($"\nRound {round} \n");   
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
            Console.WriteLine("\n*******************************");
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
            int round = 0;

            List<Prey> preys = new List<Prey>();
            List<Predator> predators = new List<Predator>();
            List<Colony> finished = new List<Colony>();
            
            ///Reading the input
            ///

            ReadFile("input.txt", ref preys, ref predators);
            PrintAll(preys, predators, round++);
            ///Perform the Operations
            ///

            startingPreyValue = CalculateTotalSize(preys);
            while (!PreysAreExtinct(preys) && !(CalculateTotalSize(preys) >= startingPreyValue * 4 ))
            {
                for(int i = 0; i<preys.Count; i++)
                {
                    preys[i].Reproduce(round);
                    preys[i].CheckNumber();
                }
                for(int j=0; j<predators.Count; j++)
                {
                    predators[j].Reproduce(round);
                    predators[j].AttackPrey(ref preys, ref finished, ref predators);
                }
                PrintAll(preys, predators,round++);
            }
            Console.WriteLine("The following colonies went extinct: ");
            foreach( Colony colony in finished)
            {
                Console.Write(colony.name + " ");
            }
        }
    }
}