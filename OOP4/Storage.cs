using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP4
{
    class Storage
    {
        private Element first;
        private Element current;
        private int count;

        public Storage()
        {
            count = 0;
            first = null;
            current = null;
        }

        public void add_front(Element element)
        {
            if (count == 0)
            {
                first = element;
                current = element;
                first.Next = element;
                first.Prev = element;
                count++;
            }
            else
            {
                element.Next = current;
                element.Prev = current.Prev;
                current.Prev.Next = element;
                current.Prev = element;
                if (current == first)
                    first = element;
                current = element;
                count++;
            }
        }

        public void add_back(Element element)
        {
            if (count == 0)
            {
                first = element;
                current = element;
                first.Next = element;
                first.Prev = element;
                count++;
            }
            else
            {
                element.Prev = current;
                element.Next = current.Next;
                current.Next.Prev = element;
                current.Next = element;
                current = element;
                count++;
            }
        }

        public void move_next()
        {
            current = current.Next;
        }

        public void move_prev()
        {
            current = current.Prev;
        }

        public void add_at_end(Element element)
        {
            while (current != first)
            {
                move_next();
            }

            add_front(element);
            Console.WriteLine("add at end");
        }

        public void delete_current()
        {
            count--;
            if (count == -1)
            {
                Console.WriteLine("Элементов в списке нет, удалять нечего. \n");
                count++;
            }

            if (count == 0)
            {
                first = null;
                current = null;
            }

            if (count >= 1)
            {
                Element tmp = current.Next;
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
                if (current == first)
                {
                    first = tmp;
                }

                current = tmp;
            }
        }

        public void delete_at_first()
        {
            current = first;
            delete_current();
        }

        public void delete_at_end()
        {
            while (current.Next != first)
                current = current.Next;
            delete_current();
        }

        public void delete_before_current()
        {
            move_prev();
            delete_current();
        }

        public void delete_after_current()
        {
            move_next();
            delete_current();
            move_prev();
        }

        public int get_count()
        {
            return count;
        }

        public void show_count()
        {
            Console.WriteLine(count);
        }
        public Element getCurrent(){
            return current;
        }
        public Element getFirst() {
            return first;
        }
        public void setCurrent(Element current) {
            this.current = current;
        }
    }
}