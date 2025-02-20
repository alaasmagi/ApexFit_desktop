﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserTrainingEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public Guid TrainingId { get; set; }
        public int TotalConsumption { get; set; }
        public int Duration { get; set; }
    }
}
