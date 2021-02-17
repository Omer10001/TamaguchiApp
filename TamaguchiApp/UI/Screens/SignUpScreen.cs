using TamaguchiApp.UI;
using TamaguchiApp.DataTransferObjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;


namespace TamaguchiApp.UI
{
    class SignUpScreen: Screen
    {
        public SignUpScreen() : base("Sign Up Screen")
        {

        }
        public override void Show()
        {
            base.Show();
            Console.Write("Enter player's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter player's last name:  ");
            string lastName = Console.ReadLine();
            Console.Write("Enter player's email:      ");
            string email = Console.ReadLine();
           
            #region genderGetting
            bool valid1 = false;
            int genderChoose = 0;
            while (!valid1)
            {
                try
                {
                    Console.WriteLine("Choose your gender:\n1.Male\n2.Female");
                    genderChoose = int.Parse(Console.ReadLine());
                    while(genderChoose < 1 || genderChoose > 2)
                    {
                        Console.Write("Please enter 1 or 2: ");
                        genderChoose = int.Parse(Console.ReadLine());
                    }
                    valid1 = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Please enter a valid intiger...");
                    valid1 = false;
                }
            }
            string gender = "XOXOXO";
            if (genderChoose == 1)
                gender = "Male";
            if (genderChoose == 2)
                gender = "Female";
            #endregion
            #region BirthDate
            bool valid2 = false;
            int birthYear = 0;
            while(!valid2)
            {
                try
                {
                    Console.Write("Please enter your birth Year: ");
                    birthYear = int.Parse(Console.ReadLine());
                    while(birthYear < 1900 || birthYear > 2019)
                    {
                        Console.Write("Please enter a year between 1900 to 2019: ");
                    }
                    valid2 = true;
                }
                catch(Exception e)
                {
                    valid2 = false;
                    Console.WriteLine("Please enter a valid intiger...");
                }
            }
            bool valid3 = false;
            int birthMonth = 0;
            while (!valid3)
            {
                try
                {
                    Console.Write("Please enter your birth Month: ");
                    birthMonth = int.Parse(Console.ReadLine());
                    while (birthMonth < 1 || birthMonth > 12)
                    {
                        Console.Write("Please enter a month between 1 to 12: ");
                    }
                    valid3 = true;
                }
                catch (Exception e)
                {
                    valid3 = false;
                    Console.WriteLine("Please enter a valid intiger...");
                }
            }
            bool valid4 = false;
            int birthDay = 0;
            while (!valid4)
            {
                try
                {
                    Console.Write("Please enter your birth Day (Number): ");
                    birthDay = int.Parse(Console.ReadLine());
                    if (birthYear % 4 == 0)
                    {
                        if (birthMonth == 2)
                        {
                            while (birthDay < 1 || birthDay > 29)
                            {
                                Console.Write("Please enter a day between 1 to 29: ");
                                birthDay = int.Parse(Console.ReadLine());
                            }
                        }
                        else if (birthMonth == 1 || birthMonth == 3 || birthMonth == 5 || birthMonth == 7 || birthMonth == 8 || birthMonth == 10 || birthMonth == 12)
                        {
                            while (birthDay < 1 || birthDay > 31)
                            {
                                Console.Write("Please enter a day between 1 to 31: ");
                                birthDay = int.Parse(Console.ReadLine());
                            }
                        }
                        else
                        {
                            while (birthDay < 1 || birthDay > 30)
                            {
                                Console.Write("Please enter a day between 1 to 30: ");
                                birthDay = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    else
                    {
                        if (birthMonth == 2)
                        {
                            while (birthDay < 1 || birthDay > 28)
                            {
                                Console.Write("Please enter a day between 1 to 28: ");
                                birthDay = int.Parse(Console.ReadLine());
                            }
                        }
                        else if (birthMonth == 1 || birthMonth == 3 || birthMonth == 5 || birthMonth == 7 || birthMonth == 8 || birthMonth == 10 || birthMonth == 12)
                        {
                            while (birthDay < 1 || birthDay > 31)
                            {
                                Console.Write("Please enter a day between 1 to 31: ");
                                birthDay = int.Parse(Console.ReadLine());
                            }
                        }
                        else
                        {
                            while (birthDay < 1 || birthDay > 30)
                            {
                                Console.Write("Please enter a month between 1 to 30: ");
                                birthDay = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    valid4 = true;
                }
                catch (Exception e)
                {
                    valid4 = false;
                    Console.WriteLine("Please enter a valid intiger...");
                }
            }
            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
            #endregion
            Console.Write("Enter userName: ");
            string userName = Console.ReadLine();
            Console.Write("Enter PassWord: ");
            string userPassword = Console.ReadLine();
            try
            {
                PlayerDTO newPlayer = new PlayerDTO { FirstName = firstName, LastName = lastName, Email = email, Gender = gender, BirthDate = birthDate, UserName = userName, UserPassword = userPassword };
                Task<bool> t = MainUI.api.SignUpAsync(newPlayer);
                t.Wait();
                if(t.Result )
                {
                    MainUI.CurrentPlayer = newPlayer;
                    Console.WriteLine("Sign up successful, press any key to continue");
                    Console.ReadKey();
                    Screen next = new CreateAnimalScreen();
                    next.Show();
                }
                else
                {
                    Console.WriteLine("Something went wrong or the email has already been used, please try again");
                    Console.ReadKey();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong {e}");
                Console.ReadKey();
            }

        }
    }
}
