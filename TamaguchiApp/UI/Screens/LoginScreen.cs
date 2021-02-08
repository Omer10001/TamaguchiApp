using TamaguchiApp.UI;
using System;
using System.Collections.Generic;
using TamaguchiApp.WebServices;
using System.Threading.Tasks;
using TamaguchiApp.DataTransferObjects;
using System.Text;

namespace TamaguchiApp.UI
{
    class LoginScreen:Screen
    {
        public LoginScreen() : base("Login Screen")
        {

        }

        public override void Show()
        {
            base.Show();
            if (MainUI.CurrentPlayer == null)
            {
               
                
                
                    Console.WriteLine("Please enter email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Please enter password");
                    string pass = Console.ReadLine();
                    Task<PlayerDTO> t = MainUI.api.LoginAsync(email, pass);
                Console.WriteLine("please wait....");
                t.Wait();
                MainUI.CurrentPlayer = t.Result;

                
                
                if (MainUI.CurrentPlayer == null)
                {
                    Console.WriteLine("error usr,pass");
                    Console.ReadLine();
                }
                    
                else
                {
                    Console.WriteLine("Login Succesfull press any key to continue");
                    Console.ReadKey();
                    //if the animal is dead
                    
                    if(MainUI.CurrentPlayer.IsPetDead())
                    {
                        Screen next = new DeadMenu("your animal died");
                        next.Show();
                    }
                    else
                    {
                        Screen next = new MainMenu("Main Menu");
                        next.Show();
                    }
                    

                }
            }
            else
            {
                Console.WriteLine("Would like to sign out and re-Login?");

                bool validChoice = false;
                while (!validChoice)
                {
                    char choice = Console.ReadKey().KeyChar;
                    switch (choice)
                    {
                        case 'y':
                            MainUI.db.SaveChanges();
                            MainUI.currentPlayer = null;
                            validChoice = true;
                            this.Show();
                            break;
                        case 'n':
                            validChoice = true;
                            if (MainUI.currentPlayer.IsPetDead())
                            {
                                Screen next = new DeadMenu("your animal died");
                                next.Show();
                            }
                            else
                            {
                                Screen next = new MainMenu("Main Menu");
                                next.Show();
                            }



                            break;
                        default:
                            Console.WriteLine("\ny or n only");

                            break;
                    }
                }

            }
        }
    }
}

