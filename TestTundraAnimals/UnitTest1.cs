using TundraAnimals;
using static TundraAnimals.Colony;

namespace TestTundraAnimals
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReproduction()
        {
            ///Preys
            ///
            //Lemming
            Prey lemming = new Lemming("john", 100);
            lemming.Reproduce(2); //Lemmings double every second turn
            Assert.AreEqual(200, lemming.size);
            lemming.Reproduce(3);
            Assert.AreEqual(200, lemming.size);

            //Hare 
            Prey hare = new Hare("john", 100);
            hare.Reproduce(2); //Hare grow by 50% every second turn
            Assert.AreEqual(150, hare.size);
            hare.Reproduce(3);
            Assert.AreEqual(150, hare.size);

            //Gopher
            Prey gopher = new Gopher("john", 100);
            gopher.Reproduce(4); //Gophers double every fourth round
            Assert.AreEqual(200, gopher.size);
            gopher.Reproduce(5);
            Assert.AreEqual(200, gopher.size);

            ///Predators
            ///

            //Snow Owl
            Predator o = new Owl("john", 8);
            o.Reproduce(8); //Snow owls have 2 offspring per 4 animals
            Assert.AreEqual(10, o.size);
            o.Reproduce(9);
            Assert.AreEqual(10, o.size);

            //Fox
            Predator f = new Fox("john", 4);
            f.Reproduce(8); //Foxes have 3 offsprings per 4 animals
            Assert.AreEqual(7, f.size);
            f.Reproduce(9);
            Assert.AreEqual(7, f.size);

            //Wolves
            Predator w = new Wolf("john", 4);
            w.Reproduce(8); //Wolves have 2 offsprings per 4 animals
            Assert.AreEqual(6, w.size);
            w.Reproduce(9);
            Assert.AreEqual(6, w.size);
        }

        [TestMethod]
        public void TestCheckNumbers()
        {
            Prey lemming = new Lemming("john", 201);
            Prey h = new Hare("john", 101);
            Prey g = new Gopher("john", 201);

            //Lemming
            lemming.CheckNumber(); //If there are more 200 lemmings, their number decreases to 30
            Assert.AreEqual(30, lemming.size);
            lemming.CheckNumber(); //Now, size should remain same
            Assert.AreEqual(30, lemming.size);

            //Hare
            h.CheckNumber(); //If there are more 100 hares, their number decreases to 20
            Assert.AreEqual(20, h.size);
            h.CheckNumber(); //Size should remain same
            Assert.AreEqual(20, h.size);

            //Gopher
            g.CheckNumber(); //If there are more 200 hares, their number decreases to 40
            Assert.AreEqual(40, g.size);
            g.CheckNumber(); //Size should remain same
            Assert.AreEqual(40, g.size);
        }

        [TestMethod]
        public void TestOwlAttacks()
        {
            Predator o = new Owl("coolJohnny", 10);

            //Preparing our Preys
            Prey l1 = new Lemming("lem", 100);
            List<Prey> l = new List<Prey>() { l1 };
            Prey h1 = new Hare("hare", 100);
            List<Prey> h = new List<Prey>() { h1 };
            Prey g1 = new Gopher("go", 100);
            List<Prey> g = new List<Prey>() { g1 };

            List<Colony> finished = new List<Colony>();
            List<Predator> predators = new List<Predator>();

            //A lemming's size decreases by four times the predator's size
            o.AttackPrey(ref l, ref finished, ref predators);
            Assert.AreEqual(60, l[0].size);
            //If there are not enough lemmings, every fourth owl dies
            l[0].size = 30;
            o.AttackPrey(ref l, ref finished, ref predators);
            Assert.AreEqual(0, l.Count); //The preys extinct, and should be removed
            Assert.AreEqual(7, o.size);

            //A hare's size decreases by double the predator's size
            o.size = 10;
            o.AttackPrey(ref h, ref finished, ref predators);
            Assert.AreEqual(80, h[0].size);
            //If there are not enough lemmings, every fourth owl dies
            h[0].size = 18;
            o.AttackPrey(ref h, ref finished, ref predators);
            Assert.AreEqual(0, h.Count); //The preys extinct, and should be removed
            Assert.AreEqual(9, o.size);

            //A gopher's size decreases by double the predator's size
            o.size = 10;
            o.AttackPrey(ref g, ref finished, ref predators);
            Assert.AreEqual(80, g[0].size);
            //If there are not enough lemmings, every fourth owl dies
            g[0].size = 18;
            o.AttackPrey(ref g, ref finished, ref predators);
            Assert.AreEqual(0, g.Count); //The preys extinct, and should be removed
            Assert.AreEqual(9, o.size);
        }

        [TestMethod]
        public void TestFoxAttacks()
        {
            Predator f = new Fox("coolKayle", 10);

            //Preparing our Preys
            Prey l1 = new Lemming("lem", 100);
            List<Prey> l = new List<Prey>() { l1 };
            Prey h1 = new Hare("hare", 100);
            List<Prey> h = new List<Prey>() { h1 };
            Prey g1 = new Gopher("go", 100);
            List<Prey> g = new List<Prey>() { g1 };

            List<Colony> finished = new List<Colony>();
            List<Predator> predators = new List<Predator>();

            //A lemming's size decreases by four times the predator's size
            f.AttackPrey(ref l, ref finished, ref predators);
            Assert.AreEqual(60, l[0].size);
            //If there are not enough lemmings, every fourth owl dies
            l[0].size = 30;
            f.AttackPrey(ref l, ref finished, ref predators);
            Assert.AreEqual(0, l.Count); //The preys extinct, and should be removed
            Assert.AreEqual(7, f.size);

            //A hare's size decreases by double the predator's size
            f.size = 10;
            f.AttackPrey(ref h, ref finished, ref predators);
            Assert.AreEqual(80, h[0].size);
            //If there are not enough lemmings, every fourth owl dies
            h[0].size = 18;
            f.AttackPrey(ref h, ref finished, ref predators);
            Assert.AreEqual(0, h.Count); //The preys extinct, and should be removed
            Assert.AreEqual(9, f.size);

            //A gopher's size decreases by double the predator's size
            f.size = 10;
            f.AttackPrey(ref g, ref finished, ref predators);
            Assert.AreEqual(80, g[0].size);
            //If there are not enough lemmings, every fourth owl dies
            g[0].size = 18;
            f.AttackPrey(ref g, ref finished, ref predators);
            Assert.AreEqual(0, g.Count); //The preys extinct, and should be removed
            Assert.AreEqual(9, f.size);
        }

        [TestMethod]
        public void TestWolfAttacks()
        {
            Predator w = new Wolf("coolJohnny", 10);

            //Preparing our Preys
            Prey l1 = new Lemming("lem", 100);
            List<Prey> l = new List<Prey>() { l1 };
            Prey h1 = new Hare("hare", 100);
            List<Prey> h = new List<Prey>() { h1 };
            Prey g1 = new Gopher("go", 100);
            List<Prey> g = new List<Prey>() { g1 };

            List<Colony> finished = new List<Colony>();
            List<Predator> predators = new List<Predator>();

            //A lemming's size decreases by four times the predator's size
            w.AttackPrey(ref l, ref finished, ref predators);
            Assert.AreEqual(60, l[0].size);
            //If there are not enough lemmings, every fourth owl dies
            l[0].size = 30;
            w.AttackPrey(ref l, ref finished, ref predators);
            Assert.AreEqual(0, l.Count); //The preys extinct, and should be removed
            Assert.AreEqual(7, w.size);

            //A hare's size decreases by double the predator's size
            w.size = 10;
            w.AttackPrey(ref h, ref finished, ref predators);
            Assert.AreEqual(80, h[0].size);
            //If there are not enough lemmings, every fourth owl dies
            h[0].size = 18;
            w.AttackPrey(ref h, ref finished, ref predators);
            Assert.AreEqual(0, h.Count); //The preys extinct, and should be removed
            Assert.AreEqual(9, w.size);

            //A gopher's size decreases by double the predator's size
            w.size = 10;
            w.AttackPrey(ref g, ref finished, ref predators);
            Assert.AreEqual(80, g[0].size);
            //If there are not enough lemmings, every fourth owl dies
            g[0].size = 18;
            w.AttackPrey(ref g, ref finished, ref predators);
            Assert.AreEqual(0, g.Count); //The preys extinct, and should be removed
            Assert.AreEqual(9, w.size);
        }
    }
}
