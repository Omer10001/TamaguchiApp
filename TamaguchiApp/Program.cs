using System;
using TamaguchiApp.UI;

namespace TamaguchiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainUI ui = new MainUI(new LoginScreen());
            ui.ApplicationStart();
        }
    }
}
