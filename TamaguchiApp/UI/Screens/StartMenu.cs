using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class StartMenu:MenuScreen
    {
        public StartMenu(string title) : base(title)
        {
            this.items = new List<MenuItem>();
            this.items.Add(new MenuItem("Login", new LoginScreen()));
            this.items.Add(new MenuItem("SignUp", new SignUpScreen()));
        }
    }
}
