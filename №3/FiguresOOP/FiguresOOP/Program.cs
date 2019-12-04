using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresOOP
{
    abstract class Figure
    {
        public abstract double getArea();
    }

    abstract class VolumeFigure : Figure
    {
        public abstract double getVolume();
    }

    class Rectangle : Figure
    {
        private double width;
        private double length;
        public Rectangle (double _width, double _length)
        {
            width = _width;
            length = _length;
        }
        public override double getArea()
        {
            return width * length;
        }
    }

    class Circle : Figure
    {
        private double radius;
        public Circle(double _radius)
        {
            radius = _radius;
        }
        public override double getArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }

    class Parallelepiped : VolumeFigure
    {
        private double width;
        private double length;
        private double height;
        public Parallelepiped(double _width, double _length, double _height)
        {
            width = _width;
            length = _length;
            height = _height;
        }
        public override double getArea()
        {
            return 2 * (length * width + width * height + height * length);
        }
        public override double getVolume()
        {
            return length * width * height;
        }
    }

    class Scope : VolumeFigure
    {
        private double radius;
        public Scope(double _radius)
        {
            radius = _radius;
        }
        public override double getArea()
        {
            return 4 * Math.PI * Math.Pow(radius, 2);
        }
        public override double getVolume()
        {
            return 4 / 3 * Math.PI * Math.Pow(radius, 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Figure> figures = new List<Figure>
            {
                new Rectangle(2, 3),
                new Parallelepiped(1.8, 2.6, 3.1),
                new Circle(4),
                new Scope(5.3),
                new Parallelepiped(3, 1.1, 2)
            };
            
            foreach (var f in figures)
            {
                VolumeFigure volFigure = f as VolumeFigure;
                if(volFigure == null)
                    Console.WriteLine("Area = {0}", f.getArea());
                else
                    Console.WriteLine("Area = {0}, Volume = {1}", volFigure.getArea(), volFigure.getVolume());
            }
            Console.ReadLine();
        }
    }
}
