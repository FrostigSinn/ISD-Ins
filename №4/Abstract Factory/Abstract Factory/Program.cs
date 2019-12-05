using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    abstract class Chair
    {
        public abstract void Create();
    }

    class VictorianChair : Chair
    {
        override public void Create()
        {
            Console.WriteLine("Here is victorian chair");
        }
    }

    class ModernChair : Chair
    {
        override public void Create()
        {
            Console.WriteLine("Here is modern chair");
        }
    }

    abstract class Sofa
    {
        public abstract void Create();
    }

    class VictorianSofa : Sofa
    {
        override public void Create()
        {
            Console.WriteLine("Here is victorian sofa");
        }
    }

    class ModernSofa : Sofa
    {
        override public void Create()
        {
            Console.WriteLine("Here is modern sofa");
        }
    }

    abstract class FurnitureFactory
    {
        public abstract Chair CreateChair();
        public abstract Sofa CreateSofa();
    }

    class VictorianFactory : FurnitureFactory
    {
        public override Chair CreateChair()
        {
            return new VictorianChair();
        }

        public override Sofa CreateSofa()
        {
            return new VictorianSofa();
        }
    }

    class ModernFactory : FurnitureFactory
    {
        public override Chair CreateChair()
        {
            return new ModernChair();
        }

        public override Sofa CreateSofa()
        {
            return new ModernSofa();
        }
    }

    class Client
    {
        private Chair chair;
        private Sofa sofa;

        public Client(FurnitureFactory factory)
        {
            chair = factory.CreateChair();
            sofa = factory.CreateSofa();
        }

        public void getFurniture()
        {
            chair.Create();
            sofa.Create();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Client client;
            Console.WriteLine("Need a victorian furniture");
            client = new Client(new VictorianFactory());
            client.getFurniture();
            Console.WriteLine("Need a modern furniture");
            client = new Client(new ModernFactory());
            client.getFurniture();
            Console.ReadLine();
        }
    }

}
