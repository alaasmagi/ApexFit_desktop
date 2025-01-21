using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TrainingEntity : BaseEntity
    {
        [MaxLength(128)]
        public string Name { get; set; } = string.Empty;
        public int AvgConsumptionPerHour { get; set; }
    }
}
