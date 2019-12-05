using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Product
    {
        private List<string> computerParts = new List<string>();

        public void Add(string part)
        {
            computerParts.Add(part);
        }

        public string partsOutput()
        {
            string listParts = string.Empty;
            foreach (object part in computerParts)
                listParts += part + ", ";

            listParts = listParts.Remove(listParts.Length - 2);

            return "Parts: " + listParts;
        }
    }

    abstract class ComputerBuilder
    {
        public abstract void AddSSD();
        public abstract void AddHDD();
        public abstract void AddCPU();
        public abstract void AddProc();
        public abstract Product GetProduct();
    }

    class ConcretSpecification : ComputerBuilder
    {
        private Product computer = new Product();

        public override void AddSSD()
        {
            computer.Add("SSD");
        }

        public override void AddHDD()
        {
            computer.Add("HDD");
        }

        public override void AddCPU()
        {
            computer.Add("CPU");
        }

        public override void AddProc()
        {
            computer.Add("Proc");
        }

        public override Product GetProduct()
        {
            Product result = computer;
            computer = new Product();
            return result;
        }
    }


    class Director
    {
        private ComputerBuilder builder;

        public Director(ComputerBuilder someBuilder)
        {
            builder = someBuilder;
        }

        public void fullComplication()
        {
            builder.AddSSD();
            builder.AddHDD();
            builder.AddCPU();
            builder.AddProc();
        }

        public void SSDComplication()
        {
            builder.AddSSD();
            builder.AddCPU();
            builder.AddProc();
        }

        public void HDDComplication()
        {
            builder.AddHDD();
            builder.AddCPU();
            builder.AddProc();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComputerBuilder builder = new ConcretSpecification();
            Director director = new Director(builder);

            Console.WriteLine("Full complication:");
            director.fullComplication();
            Console.WriteLine(builder.GetProduct().partsOutput());

            Console.WriteLine("HDD complication:");
            director.HDDComplication();
            Console.WriteLine(builder.GetProduct().partsOutput());

            Console.WriteLine("SSD complication:");
            director.SSDComplication();
            Console.WriteLine(builder.GetProduct().partsOutput());

            Console.WriteLine("I'm need only SSD");
            builder.AddSSD();
            Console.WriteLine(builder.GetProduct().partsOutput());
            Console.ReadLine();
        }
    }
}
