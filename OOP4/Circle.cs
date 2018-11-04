using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    class Circle : Shape
    {
        private int radius;
        private char color;

        public Circle(int x, int y, int z, char a) : base(x, y)
        {
            radius = z;
            color = a;
        }

        public void show()
        {
            Console.WriteLine("Представлен круг с координатами x= "+X+" y= "+Y+" и радиусом =" + radius);
        }
        public int Radius { get => radius; set => this.radius = value; }
        public char Color { get => color; set => this.color = value; }
    }
}