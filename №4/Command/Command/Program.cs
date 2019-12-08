using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    interface ICommand
    {
        void execude();
        void undo();
    }

    class Programmer
    {
        public void startCoding()
        {
            Console.WriteLine("Programmer writes a program");
        }

        public void stopCoding()
        {
            Console.WriteLine("Programmer stopped work");
        }
    }

    class CodeCommand : ICommand
    {
        Programmer programmer;

        public CodeCommand(Programmer someProgrammer)
        {
            programmer = someProgrammer;
        }

        public void execude()
        {
            programmer.startCoding();
        }

        public void undo()
        {
            programmer.stopCoding();
        }
    }

    class Tester
    {
        public void startTesting()
        {
            Console.WriteLine("Testing project");
        }

        public void stopTesting()
        {
            Console.WriteLine("Tester stopped work");
        }
    }


    class TestCommand : ICommand
    {
        Tester tester;

        public TestCommand(Tester someTester)
        {
            tester = someTester;
        }

        public void execude()
        {
            tester.startTesting();
        }

        public void undo()
        {
            tester.stopTesting();
        }
    }

    class ProjectManager
    {
        List<ICommand> commands;
        public void setCommand(List<ICommand> someCommands)
        {
            commands = someCommands;
        }

        public void startWork()
        {
            foreach(var command in commands)
                command.execude();
        }

        public void stopWork()
        {
            foreach (var command in commands)
                command.undo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProjectManager someManager = new ProjectManager();
            Programmer someProgrammer = new Programmer();
            Tester someTester = new Tester();

            List<ICommand> commands = new List<ICommand>
            {
                new CodeCommand(someProgrammer),
                new TestCommand(someTester)
            };

            someManager.setCommand(commands);

            someManager.startWork();
            someManager.stopWork();
            

            Console.ReadLine();
        }
    }
}
