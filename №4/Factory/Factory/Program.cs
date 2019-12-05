using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    abstract class Developer
    {
        abstract public Project createProject();
    }

    class DesktopDeveloper : Developer
    {
        public override Project createProject()
        {
            return new DesktopProject();
        }
    }

    class MobileDeveloper : Developer
    {
        public override Project createProject()
        {
            return new MobileProject();
        }
    }

    abstract class Project
    {

    }

    class DesktopProject : Project
    {
        public DesktopProject()
        {
            Console.WriteLine("Desktop project created");
        }
    }

    class MobileProject : Project
    {
        public MobileProject()
        {
            Console.WriteLine("Mobile project created");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Developer desktopDeveloper = new DesktopDeveloper();
            Developer mobileDeveloper = new MobileDeveloper();

            Project desctopProject = desktopDeveloper.createProject();

            Project mobileProject = mobileDeveloper.createProject();

            Console.ReadLine();
        }
    }
}
