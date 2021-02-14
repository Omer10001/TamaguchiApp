using TamaguchiApp.UI;
using TamaguchiApp.DataTransferObjects;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TamaguchiApp.UI
{
    class TypedExcersicesMenuScreen:Screen
    {
        Dictionary<int, ExerciseDTO> Dic = new Dictionary<int, ExerciseDTO>();
        int typeID;
        int count = 1;
        public TypedExcersicesMenuScreen(int typeID, string methodType) : base(methodType)
        {
            this.typeID = typeID;
            Task<List<ExerciseDTO>> listTask = MainUI.api.GetExByTypeAsync(typeID);
            listTask.Wait();
            List<ExerciseDTO> list = listTask.Result;
            foreach (ExerciseDTO ex in list)
            {
                Dic.Add(count, ex);
                count++;
            }
        }
        // hhjgkjhjhlhhkjhljkygjgjh
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Choose one of the method by number: ");
            foreach(KeyValuePair<int, ExerciseDTO> ex in Dic)
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
                ExerciseDTO ex = Dic.Where(d => d.Key == option).FirstOrDefault().Value;
                if (ex == null)
                {
                    throw new Exception("Something went wrong");
                }
                else
                {
                    Task<bool> t = MainUI.api.DoExerciseAsync(ex);
                    t.Wait();
                    if (t.Result)
                        Console.WriteLine("Your method was done successfuly!\nPress any key to return to main menu");
                    else
                        Console.WriteLine("Method calling didn't work out... :(");
                    Console.ReadKey();
                   
                }
            }
             
        }
    }
}
