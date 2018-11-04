using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public class Element
    {
        private Object data;
        private Element next;
        private Element prev;

        public Element(Object obj)
        {
            data = obj;
            next = null;
            prev = null;
        }

        public Object Data { get => data; set => this.data = value; }
        public Element Next { get => next; set => this.next = value; }

        public Element Prev { get => prev; set => this.prev = value; }
    }
}