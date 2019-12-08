using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineEvent
{
    delegate void newIssueDelegate(IMagazine someMagazine);
    interface IMagazine
    {
        string Name { get; set; }
        event newIssueDelegate newIssueEvent;
        void newIssue();

    }

    class OnlineMagazine : IMagazine
    {
        public event newIssueDelegate newIssueEvent;
        public string Name { get; set; }

        public OnlineMagazine(string name)
        {
            Name = name;
        }


        public void newIssue()
        {
            newIssueEvent?.Invoke(this);
        }

    }

    class GlossyMagazine : IMagazine
    {
        public event newIssueDelegate newIssueEvent;
        public string Name { get; set; }

        public GlossyMagazine(string name)
        {
            Name = name;
        }


        public void newIssue()
        {
            newIssueEvent?.Invoke(this);
        }

    }

    class NewsPaper : IMagazine
    {
        public event newIssueDelegate newIssueEvent;
        public string Name { get; set; }

        public NewsPaper(string name)
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

        public void subscribe(IMagazine someMagazine)
        {
            if (!count.ContainsKey(someMagazine.Name))
            {
                count.Add(someMagazine.Name, 0);
                someMagazine.newIssueEvent += readIssue;
            }
            else
                Console.WriteLine("Already subscribed");
        }

        public void unsubscribe(IMagazine someMagazine)
        {
            if (count.ContainsKey(someMagazine.Name))
            {
                count.Remove(someMagazine.Name);
                someMagazine.newIssueEvent -= readIssue;
            }
            else
                Console.WriteLine("Not subscribed");
        }

        public void readIssue(IMagazine someMagazine)
        {
            count[someMagazine.Name]++;
            Console.WriteLine("{0} read {1} issue of the {2} magazine", Name, count[someMagazine.Name], someMagazine.Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OnlineMagazine TimeMagazine = new OnlineMagazine("Time");
            GlossyMagazine Esquire = new GlossyMagazine("Esquire");
            NewsPaper WashingtonPost = new NewsPaper("The Washington Post");

            Reader someReader1 = new Reader("Tom");
            Reader someReader2 = new Reader("Tod");
            Reader someReader3 = new Reader("Juli");

            someReader1.subscribe(TimeMagazine);

            TimeMagazine.newIssue();

            someReader2.subscribe(Esquire);
            TimeMagazine.newIssue();
            Esquire.newIssue();
            Esquire.newIssue();

            someReader1.subscribe(WashingtonPost);
            WashingtonPost.newIssue();

            someReader3.subscribe(Esquire);
            TimeMagazine.newIssue();
            Esquire.newIssue();
            WashingtonPost.newIssue();

            someReader3.subscribe(TimeMagazine);
            TimeMagazine.newIssue();
            WashingtonPost.newIssue();

            Console.ReadLine();
        }
    }
}
