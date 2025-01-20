using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserSleepEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public int TotalSleep { get; set; }
        public int RemSleep { get; set; }
        public int DeepSleep { get; set; }
        public int LightSleep { get; set; }
        public int AwakeTime { get; set; }
    }
}
