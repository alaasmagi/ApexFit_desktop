using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserFitnessEntity : BaseEntity
    {
        public EUserSex Sex { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int? WeightGoal { get; set; }
        public int? CalorieLimit { get; set; }
        public int? TrainingCalorieGoal { get; set; }
        public int? SleepGoal { get; set; }
    }
}
