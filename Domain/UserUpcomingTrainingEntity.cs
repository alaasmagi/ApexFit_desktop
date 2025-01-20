using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserUpcomingTrainingEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public Guid TrainingId { get; set; }
        public int Duration { get; set; }
    }
}
