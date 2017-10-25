using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    
    public interface IShape
    {
        void printShape();
    }

    public class Circle : IShape
    {
        public void printShape()
        {
            Console.WriteLine("This is a circle");
        }
    }
    public class Rectangle : IShape
    {
        public void printShape()
        {
            Console.WriteLine("This is a rectangle");
        }
    }
    public class Triangle : IShape
    {
        public void printShape()
        {
            Console.WriteLine("This is a triangle");
        }
    }

    public class ShapeFactory
    {
        public enum Type { circle, rectangle, triangle }
        public IShape Create(Type type)
        {
            switch (type)
            {
                case Type.circle:
                    return new Circle();
                    break;
                case Type.rectangle:
                    return new Rectangle();
                    break;
                case Type.triangle:
                    return new Triangle();
                    break;
                default:
                    throw new Exception("Invalid ShapeFactory type supplied...");
                    break;
            }
        }
    }

}
