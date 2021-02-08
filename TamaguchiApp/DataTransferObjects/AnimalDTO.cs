using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TamaguchiApp.DataTransferObjects
{
    public class AnimalDTO
    {
        
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int PlayerId { get; set; }
        public double AnimalWeight { get; set; }
        public DateTime BirthDate { get; set; }
        public int HungryLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int HappinessLevel { get; set; }

        public AnimalDTO() { }


    }
}
