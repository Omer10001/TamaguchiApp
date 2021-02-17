using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class MainMenu:MenuScreen
    {
        public MainMenu(string title):base(title)
        {
            this.items = new List<MenuItem>();
            
            this.items.Add(new MenuItem("Do action", new ChooseMethodTypeScreen()));
           
        }
    }
}
