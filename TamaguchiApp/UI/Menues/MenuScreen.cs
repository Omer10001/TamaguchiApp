using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace TamaguchiApp.UI
{
    class MenuScreen : Screen
    {
        protected List<MenuItem> items { get; set; }

        public MenuScreen(string title) : base(title) { }
        public void AddItem(MenuItem m)
        {
            items.Add(m);
        }

        public void RemoveItem(MenuItem m)
        {
            items.Remove(m);
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Please Choose from the following Options");
            int count = 1;
            bool exit = false;
            while (!exit) //Loop until user press the exit option (last option)
            {
                
                foreach (MenuItem m in items)
                {
                    Console.WriteLine($"\n{count} - {m}");
                    count++;
                }
                Console.WriteLine($"\n{count} - exit");

                int option = 0;
                int.TryParse(Console.ReadLine(), out option);
                if (option >= 1 && option <= count)
                {
                    if (option == count)//Exit
                        exit = true;
                    else
                    {
                        if (this.items[option - 1].TargetScreen != null)
                            this.items[option - 1].Show(); //Show selected screen!
                        else
                            Console.WriteLine("no screen to show");
                    }
                }
                count = 1;
                base.Show();
            }
        }
    }
}
