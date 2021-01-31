using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class MenuItem
    {
        public string NavName { get; set; }
        public Screen TargetScreen { get; set; }

        public MenuItem(string n, Screen t)
        {
            NavName = n;
            TargetScreen = t;
        }

        public void Show()
        {
            if (TargetScreen == null)
                throw new NullReferenceException("Target Screen Was not Defined");
            TargetScreen.Show();
        }
        public override string ToString()
        {
            return $"{NavName}";
        }
    }
}
