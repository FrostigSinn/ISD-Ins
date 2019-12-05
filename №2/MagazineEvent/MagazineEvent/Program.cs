using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineEvent
{
    delegate void newIssueDelegate(Magazine someMagazine);
    interface IMagazine
    {
        event newIssueDelegate newIssueEvent;
        void newIssue();
    }

    class Magazine : IMagazine
    {
        public event newIssueDelegate newIssueEvent;
        public string Name { get; set; }

        public Magazine(string name)
        {
            Name = name;
        }


        public void newIssue()
        {
            newIssueEvent?.Invoke(this);
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
                someMagazine.newIssueEvent += magazinesCount;
            }
            else
                Console.WriteLine("Already subscribed");
        }

        public void unsubscribe(Magazine someMagazine)
        {
            if (count.ContainsKey(someMagazine.Name))
            {
                count.Remove(someMagazine.Name);
                someMagazine.newIssueEvent -= magazinesCount;
            }
            else
                Console.WriteLine("Not subscribed");
        }

        public void magazinesCount(Magazine someMagazine)
        {
            count[someMagazine.Name]++;
            Console.WriteLine("{0} read {1} issue of the {2} magazine", Name, count[someMagazine.Name], someMagazine.Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Magazine TimeMagazine = new Magazine("Time");
            Magazine Esquire = new Magazine("Esquire");
            Reader someReader1 = new Reader("Tom");
            Reader someReader2 = new Reader("Tod");
            Reader someReader3 = new Reader("Juli");
            someReader1.subscribe(TimeMagazine);

            TimeMagazine.newIssue();

            someReader2.subscribe(Esquire);
            TimeMagazine.newIssue();
            Esquire.newIssue();
            Esquire.newIssue();

            someReader3.subscribe(Esquire);
            TimeMagazine.newIssue();
            Esquire.newIssue();

            someReader3.subscribe(TimeMagazine);
            TimeMagazine.newIssue();

            Console.ReadLine();
        }
    }
}
