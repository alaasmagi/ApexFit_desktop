using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class UserDailyEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime Date {  get; set; }
        public int Weight { get; set; }
        public int EnergyIntake { get; set; }
        public int EnergyConsumption { get; set; }
        public int TotalSleep { get; set; }
    }
}
