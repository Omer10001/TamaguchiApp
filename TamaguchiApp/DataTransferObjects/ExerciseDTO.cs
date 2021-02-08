using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiApp.DataTransferObjects
{
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public int ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public int LevelAffect { get; set; }
        public int WeightAffect { get; set; }
        public ExerciseDTO() { }

    }
}
