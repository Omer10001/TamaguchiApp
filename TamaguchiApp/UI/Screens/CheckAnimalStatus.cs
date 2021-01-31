using System;
using System.Collections.Generic;
using System.Text;
using Tamaguchi.Models;

namespace TamaguchiApp.UI
{
    class CheckAnimalStatus : Screen
    {

        public CheckAnimalStatus() : base("Check Animal Status")
        {


        }

        public override void Show()
        {

            try
            {
                base.Show();

                Pet CurrentPet = MainUI.db.GetCurrentPetInfo(MainUI.currentPlayer.PlayerId);

                Console.WriteLine("Your pet name is: " +CurrentPet.PetName);
                Console.WriteLine("your pet status is:" + CurrentPet.HealthStatus.StatusName);
                Console.WriteLine("Your pet age is: " + CurrentPet.Age);
                Console.WriteLine("Your pet birth day is: " + CurrentPet.BirthDate);
                Console.WriteLine("Your pet life cycle stage is: " + CurrentPet.LifeCycleStage.StageName);
                Console.WriteLine("Your pet clean level is: " + CurrentPet.CleanLevel);
                Console.WriteLine("Your pet hunger level is: " + CurrentPet.HungerLevel);
                Console.WriteLine("Your pet happiness level is: " + CurrentPet.HappinessLevel);
                Console.WriteLine("Your pet weight is: " + CurrentPet.PetWeight);

                Console.WriteLine("Press any key to go back to the menu");               
                Console.ReadKey();
            }
            catch(Exception e)
            {

                Console.WriteLine($"error, can't retrieve pet info exeption:{e}");
            }










        }









    }
}
