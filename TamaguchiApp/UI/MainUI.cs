using TamaguchiApp.DataTransferObjects;
using TamaguchiApp.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace TamaguchiApp.UI
{
    class MainUI
    {      
        private Screen StartScreen;
        public static PlayerDTO CurrentPlayer { get; set; }
        public static TamaguchiWebAPI api { get; private set; }

        public MainUI()
        {          
            StartScreen = new StartScreen();
        }
        public void ApplicationStart()
        {
            api = new TamaguchiWebAPI(@"https://localhost:44311/api");
            CurrentPlayer = null;
            StartScreen.Show();
        }
    }
}
