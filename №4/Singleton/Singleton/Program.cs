using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class President
    {
        private static President instance;

        public string Name { get; set; }

        private President(string name)
        {
            Name = name;
        }

        public static President getInstance(string name)
        {
            if (instance == null)
                return instance = new President(name);
            else return instance;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            President president = President.getInstance("Tom");
            President anotherPresident = President.getInstance("Tom");

            Console.WriteLine(president.Name);
            Console.WriteLine(anotherPresident.Name);

            president.Name = "Jack";

            Console.WriteLine(president.Name);
            Console.WriteLine(anotherPresident.Name);

            Console.ReadLine();
        }
    }
}
