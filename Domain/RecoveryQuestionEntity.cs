﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecoveryQuestionEntity
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = default;
    }
}
