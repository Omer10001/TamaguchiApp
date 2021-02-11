using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TamaguchiApp.DataTransferObjects
{
    public class PetDTO
    {

        public int PetId { get; set; }
        public int PlayerId { get; set; }
        public string PetName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PetWeight { get; set; }
        public int Age { get; set; }
        public int HungerLevel { get; set; }
        public int CleanLevel { get; set; }
        public int HappinessLevel { get; set; }
        public int HealthStatusId { get; set; }
        public int LifeCycleStageId { get; set; }

        public PetDTO() { }


    }
}
