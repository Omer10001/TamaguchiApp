using TamaguchiApp.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class StartScreen : Screen
    {
        public StartScreen() : base("Welcome to our App")
        {
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Welcome to our Tamaguchi App");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Screen l = new StartMenu("");
            l.Show();

        }
    }
}
