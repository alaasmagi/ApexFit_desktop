﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingsComponent
{
    public interface ITrainings
    {
        int GenerateTrainingId();
        bool AddTraining(string trainingName, int energyConsumption);
        List<string> GetTrainingNames();
        int TrainingNameExists(string trainingName);
    }
}
