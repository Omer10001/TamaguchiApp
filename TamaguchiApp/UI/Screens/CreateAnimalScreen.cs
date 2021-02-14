using TamaguchiApp.UI;
using System;
using System.Collections.Generic;
using TamaguchiApp.WebServices;
using TamaguchiApp.DataTransferObjects;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TamaguchiApp.UI
{
    // get info and do a function to server side and the server side will put it in the db and will return a response.
    // I get a reponse and set it in the clients end side.

    class CreateAnimalScreen : Screen
    {
        public CreateAnimalScreen() : base ("Create Animal") 
        {




        }

        

        public override void Show()
        {
            base.Show();






            // name weight playerid
            try
            {

            
               Console.WriteLine("whats your pet name?");
               string petname = Console.ReadLine();

                PetDTO newpet = new PetDTO {PetName = petname };
               
    

                Task<bool> t = MainUI.api.AddAnimal(newpet);

                t.Wait();
                if (t.Result == true)
                {
                    Console.WriteLine("Pet was created succesfully press any key to continue");
                    Console.ReadKey();
                    Screen next = new MainMenu("Main Menu");
                    next.Show();
                }
                else
                {
                    Console.WriteLine("Please login to use this feature");
                    Console.ReadKey();       
                   
                }


                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating pet: " + e);


            }



        }









    }
}
