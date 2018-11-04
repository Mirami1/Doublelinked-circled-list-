using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    class Shape
    {
        private int x,y;
        public int X { get => x; set => this.x = value; }

        public int Y { get => y; set => this.y = value; }

        public override string ToString()
        {
            return "Shape{" +
                   "x=" + x +
                   ", y=" + y +
                   '}';
        }

        public Shape(int x, int y) {
            this.x = x;
            this.y = y;
        }

      public void Show()
        {
            Console.WriteLine("Абстарктная фигура с координатами x= "+x+" y= "+y);
        }
    }
}
