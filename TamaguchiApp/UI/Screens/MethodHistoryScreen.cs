using System;
using System.Collections.Generic;
using System.Text;
using Tamaguchi.Models;

namespace TamaguchiApp.UI
{
    class MethodHistoryScreen:Screen
    {
        public MethodHistoryScreen():base("Method history")
        { }
        public override void Show()
        {
            try
            {
                base.Show();
                var list = MainUI.currentPlayer.GetPlayerMethodsHistories();
                foreach (PlayerMethodsHistory a in list)
                {
                    Console.WriteLine(a.Exercise.ExerciseName + " " + a.Pet.PetName + " " + a.MethodDate);
                }
                Console.WriteLine("Press any key to go back to the menu");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine($"cannot get info exeption:{e}");
            }
        }
    }
}
