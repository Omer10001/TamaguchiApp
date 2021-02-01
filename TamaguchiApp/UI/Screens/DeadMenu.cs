using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class DeadMenu:MenuScreen
    {
        public DeadMenu(string title):base(title)
        {
            this.items = new List<MenuItem>();
            this.items.Add(new MenuItem("See pets", new SeeAllPetsScreen()));
            this.items.Add(new MenuItem("Create new pet", new CreateAnimalScreen()));
        }       
    }
}
