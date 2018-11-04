using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OOP4
{
    public partial class Form1 : Form
    {
        Storage storage = new Storage();
        Pen pen1 = new Pen(Color.Blue, 10);
        Pen pe2 = new Pen(Color.White, 10);

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (int) e.X;
            int y = (int) e.Y;
            //var p = sender as Panel;
            Console.WriteLine("TUDU");
            Graphics g = panel1.CreateGraphics();
            if ((e.Button.Equals(MouseButtons.Left)) && (Check(x, y)))
            {
                ChangeYellow(g);
                storage.add_at_end(new Element(new Circle(x, y, 60, 'Y')));

                g.DrawEllipse(pen1, ((Circle) storage.getCurrent().Data).X - 30,
                    ((Circle) storage.getCurrent().Data).Y - 30, ((Circle) storage.getCurrent().Data).Radius,
                    ((Circle) storage.getCurrent().Data).Radius);
                g.FillEllipse(Brushes.Yellow, ((Circle) storage.getCurrent().Data).X - 30,
                    ((Circle) storage.getCurrent().Data).Y - 30, ((Circle) storage.getCurrent().Data).Radius,
                    ((Circle) storage.getCurrent().Data).Radius);
                storage.show_count();
            }

            if ((e.Button.Equals(MouseButtons.Left)) && (Check1(x, y)))
            {
                ChangeYellow(g);
                g.FillEllipse(Brushes.Yellow, ((Circle) storage.getCurrent().Data).X - 30,
                    ((Circle) storage.getCurrent().Data).Y - 30, ((Circle) storage.getCurrent().Data).Radius,
                    ((Circle) storage.getCurrent().Data).Radius);
                ((Circle) storage.getCurrent().Data).Color = 'Y';
            }

            if ((e.Button.Equals(MouseButtons.Right)) && Check1(x, y))
            {
                g.FillEllipse(Brushes.Red, ((Circle) storage.getCurrent().Data).X - 30,
                    ((Circle) storage.getCurrent().Data).Y - 30, ((Circle) storage.getCurrent().Data).Radius,
                    ((Circle) storage.getCurrent().Data).Radius);
                ((Circle) storage.getCurrent().Data).Color = 'R';
            }

            if ((e.Button.Equals(MouseButtons.Right)) && Check(x, y))
            {
                bool found = true;
                storage.setCurrent(storage.getFirst());
                Console.WriteLine("Начинаю удалять");
                int cnt = 0;
                while (cnt != storage.get_count())
                {
                    if (((Circle) storage.getCurrent().Data).Color == 'R')
                    {
                        Console.WriteLine("Working");
                        found = false;
                        g.DrawEllipse(pe2, ((Circle) storage.getCurrent().Data).X - 30,
                            ((Circle) storage.getCurrent().Data).Y - 30, ((Circle) storage.getCurrent().Data).Radius,
                            ((Circle) storage.getCurrent().Data).Radius);
                        g.FillEllipse(Brushes.White, ((Circle) storage.getCurrent().Data).X - 30,
                            ((Circle) storage.getCurrent().Data).Y - 30, ((Circle) storage.getCurrent().Data).Radius,
                            ((Circle) storage.getCurrent().Data).Radius);
                        storage.delete_current();
                        Console.WriteLine("Красный удалён");
                    }
                    else
                    {
                        cnt++;
                        storage.move_next();
                        Console.WriteLine("Двигаюсь дальше");
                    }
                }

                if (found == false)
                {
                    SetYellow();
                }

                int cnt1 = 0;
                if (found == true)
                {
                    storage.setCurrent(storage.getFirst());
                    while (cnt1 != storage.get_count())
                    {
                        if (((Circle) storage.getCurrent().Data).Color == 'Y')
                        {
                            Console.WriteLine("Working");
                            g.DrawEllipse(pe2, ((Circle) storage.getCurrent().Data).X - 30,
                                ((Circle) storage.getCurrent().Data).Y - 30,
                                ((Circle) storage.getCurrent().Data).Radius,
                                ((Circle) storage.getCurrent().Data).Radius);
                            g.FillEllipse(Brushes.White, ((Circle) storage.getCurrent().Data).X - 30,
                                ((Circle) storage.getCurrent().Data).Y - 30,
                                ((Circle) storage.getCurrent().Data).Radius,
                                ((Circle) storage.getCurrent().Data).Radius);
                            storage.delete_current();
                        }
                        else
                        {
                            cnt1++;
                            storage.move_next();
                            Console.WriteLine("Двигаюсь дальше");
                        }
                    }
                }
            }
        }

        public bool Check(int X, int Y)
        {
            //есть ли место для кружка ??
            bool chck = true;
            int cnt = 0;

            Element el = storage.getFirst();
            while (cnt != storage.get_count())
            {
                if (Math.Pow(Y - ((Circle) el.Data).Y, 2) + Math.Pow(X - ((Circle) el.Data).X, 2) <=
                    Math.Pow(((Circle) el.Data).Radius, 2))
                {
                    chck = false;
                    Console.WriteLine("Yes");
                    break;
                }
                else
                {
                    el = el.Next;
                    Console.WriteLine("Счётчик=" + cnt);
                    cnt++;
                }
            }

            return chck;
        }

        public bool Check1(int X, int Y)
        {
            //наоборот, в кружке ли мы
            bool chck = false;
            int cnt = 0;
            Element el = storage.getFirst();
            while (cnt != storage.get_count())
            {
                if (Math.Pow(Y - ((Circle) el.Data).Y, 2) + Math.Pow(X - ((Circle) el.Data).X, 2) <=
                    Math.Pow(((Circle) el.Data).Radius, 2))
                {
                    chck = true;
                    storage.setCurrent(el);
                    Console.WriteLine("FCK");
                    break;
                }
                else
                {
                    el = el.Next;
                    cnt++;
                }
            }

            return chck;
        }

        public void ChangeYellow(Graphics gc)
        {
            Element el = storage.getFirst();
            int cnt = 0;

            while (cnt != storage.get_count())
            {
                Console.WriteLine("YEP11");
                if (((Circle) el.Data).Color == 'Y')
                {
                    Console.WriteLine("working");
                    ((Circle) el.Data).Color = 'B';
                    gc.FillEllipse(Brushes.Blue, ((Circle) el.Data).X - 30, ((Circle) el.Data).Y - 30,
                        ((Circle) el.Data).Radius, ((Circle) el.Data).Radius);
                    Console.WriteLine("YEP");
                }
                else
                {
                    cnt++;
                    el = el.Next;
                }
            }
        }

        public void SetYellow()
        {
            Element el = storage.getFirst();
            int cnt2 = 0;

            while (cnt2 != storage.get_count())
            {
                Console.WriteLine("WOW");
                if (((Circle) el.Data).Color == 'Y')
                {
                    Console.WriteLine("working");
                    storage.setCurrent(el);
                    Console.WriteLine("Выставил курент");
                    break;
                }
                else
                {
                    cnt2++;
                    el = el.Next;
                }
            }
        }
    }
}