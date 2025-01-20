﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TrainingEntity : BaseEntity
    {
        public string Name { get; set; } = default;
        public int AvgConsumptionPerHour { get; set; }
    }
}
