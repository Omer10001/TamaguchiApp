using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class CreateAnimalScreen : Screen
    {
        public CreateAnimalScreen() : base ("Create Animal") 
        {




        }

        public override void Show()
        {
            base.Show();


            try
            {

            
               Console.WriteLine("whats your pet name?");
               string petname = Console.ReadLine();

                Random weight = new Random();
                int rand_weight = weight.Next(200, 401);
    
            
            // random 200-400 gr


                MainUI.db.CreateAnimal(petname, MainUI.currentPlayer.PlayerId, rand_weight);

                Console.WriteLine("Pet was created succesfully press any key to continue");
                Console.ReadKey();
                Screen next = new MainMenu("Main Menu");
                next.Show();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating pet: " + e);


            }



        }









    }
}
