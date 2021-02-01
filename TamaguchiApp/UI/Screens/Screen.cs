using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace TamaguchiApp.UI
{
    abstract class Screen
    {
        public string Title { get; set; }
        public Screen(string title)
        {
            Title = title;
        }
        public virtual void Show()
        {
            Console.Clear();
            Loading();
            Console.WriteLine($"{Title}".PadLeft(Console.WindowWidth / 2));
        }
        public void Loading()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Write("Loading");
                Thread.Sleep(400);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" .");
                    Thread.Sleep(400);
                }
                Console.Clear();
            }
        }
    }
}
