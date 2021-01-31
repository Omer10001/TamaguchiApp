using Tamaguchi.UI;
using Tamaguchi.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.UI
{
    class TypedExcersicesMenuScreen:Screen
    {
        Dictionary<int, Exercise> Dic = new Dictionary<int, Exercise>();
        int typeID;
        int count = 1;
        public TypedExcersicesMenuScreen(int typeID, string methodType) : base(methodType)
        {
            this.typeID = typeID;
            List<Exercise> list = MainUI.db.ExercisesByType(typeID);
            foreach(Exercise ex in list)
            {
                Dic.Add(count, ex);
                count++;
            }
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Choose one of the method by number: ");
            foreach(KeyValuePair<int, Exercise> ex in Dic)
            {
                Console.WriteLine($"{ex.Key}. {ex.Value.ExerciseName}");
            }
            int exNum = Dic.Count + 1;
            Console.WriteLine($"{exNum}. Back to previous Screen");
            Console.Write("Enter the method number: ");
            int option = 0;
            int.TryParse(Console.ReadLine(), out option);
            while (option > exNum || option < 1)
            {
                Console.Write("Enter the method number: ");
                int.TryParse(Console.ReadLine(), out option);
            }
            if (option < exNum)
            {
                Exercise ex = Dic.Where(d => d.Key == option).FirstOrDefault().Value;
                if (ex == null)
                {
                    throw new Exception("Something went wrong");
                }
                else
                {
                    Pet p = MainUI.db.GetCurrentPetInfo(MainUI.currentPlayer.PlayerId);
                    p.DoExersice(ex);
                    MainUI.db.UpdatePlayerMethodHistory(p, MainUI.currentPlayer, ex);
                    Console.WriteLine("Your method was done successfuly!\nPress any key to return to main menu");
                    Console.ReadKey();
                   
                }
            }
             
        }
    }
}
