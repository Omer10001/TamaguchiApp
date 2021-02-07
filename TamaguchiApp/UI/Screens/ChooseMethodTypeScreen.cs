using Tamaguchi.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class ChooseMethodTypeScreen:MenuScreen
    {
        public ChooseMethodTypeScreen() : base("Choose Method Type Screen: ")
        {

            this.items = new List<MenuItem>();
            this.AddItem(new MenuItem("Eating Methods", new TypedExcersicesMenuScreen(1, "Feeding Exercises")));
            this.items.Add(new MenuItem("Playing Methods", new TypedExcersicesMenuScreen(3, "Playing Exercises")));
            this.items.Add(new MenuItem("Cleaning Methods", new TypedExcersicesMenuScreen(2, "Cleaning Exercices")));
        }
     
    }
}
