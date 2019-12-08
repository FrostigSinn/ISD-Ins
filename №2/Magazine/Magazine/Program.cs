using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    class Magazine
    {
        public delegate void MagazineDelegate(Magazine someMagazine);
        public MagazineDelegate subscribers;
        public string Name { get; set; }

        public Magazine (string name)
        {
            Name = name;
        }

        public void newIssue()
        {
            subscribers?.Invoke(this);
        }
    }

    class Reader
    {
        private Dictionary<string, int> count = new Dictionary<string, int>();
        public string Name { get; set; }

        public Reader(string name)
        {
            Name = name;
        }

        public void subscribe(Magazine someMagazine)
        {
            if (!count.ContainsKey(someMagazine.Name))
            {
                count.Add(someMagazine.Name, 0);
                someMagazine.subscribers += readIssue;
            }
            else
                Console.WriteLine("Already subscribed");
        }

        public void unsubscribe(Magazine someMagazine)
        {
            if (count.ContainsKey(someMagazine.Name))
            {
                count.Remove(someMagazine.Name);
                someMagazine.subscribers -= readIssue;
            }
            else
                Console.WriteLine("Not subscribed");
        }

        public void readIssue(Magazine someMagazine)
        {
            count[someMagazine.Name]++;
            Console.WriteLine("{0} read {1} issue of the {2} magazine", Name, count[someMagazine.Name], someMagazine.Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Magazine forbesMagazine = new Magazine("Forbes");
            Magazine futuresMagazine = new Magazine("Futures");
            Reader someReader1 = new Reader("Tom");
            Reader someReader2 = new Reader("Tod");
            Reader someReader3 = new Reader("Juli");
            someReader1.subscribe(forbesMagazine);

            forbesMagazine.newIssue();

            someReader2.subscribe(futuresMagazine);

            forbesMagazine.newIssue();
            futuresMagazine.newIssue();
            forbesMagazine.newIssue();

            someReader3.subscribe(forbesMagazine);

            someReader1.subscribe(futuresMagazine);

            futuresMagazine.newIssue();
            futuresMagazine.newIssue();
            forbesMagazine.newIssue();

            someReader1.subscribe(forbesMagazine);
            someReader1.unsubscribe(forbesMagazine);
            someReader1.unsubscribe(forbesMagazine);

            forbesMagazine.newIssue();
            Console.ReadLine();
        }
    }
}
