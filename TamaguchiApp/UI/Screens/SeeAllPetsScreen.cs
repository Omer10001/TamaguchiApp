using System;
using System.Collections.Generic;
using System.Text;
using Tamaguchi.Models;

namespace TamaguchiApp.UI
{
    class SeeAllPetsScreen:Screen
    {
        public SeeAllPetsScreen() : base("Pets list")
        { }
        public override void Show()
        {
            try
            {
                base.Show();
                var list = MainUI.currentPlayer.GetAllPets();
                foreach (Pet a in list)
                {
                    if (a.HealthStatusId == 4)
                    {
                        DateTime t = a.BirthDate.AddDays(a.Age);
                        Console.WriteLine($"{a.PetName} {a.HealthStatus.StatusName} {a.BirthDate.ToShortDateString()} - {t.ToShortDateString()}");
                    }
                    else
                    {
                        Console.WriteLine($"{a.PetName} {a.HealthStatus.StatusName} {a.BirthDate.ToShortDateString()}");
                    }
                    Console.WriteLine("Press any key to go back to the menu");
                    Console.ReadKey();
            }   }   
            catch (Exception e)
            {
                Console.WriteLine($"cannot get info exeption:{e}");
            }
        }
    }
}
