using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepComponent
{
    internal interface ISleep
    {
        bool AddSleepToHistory(int userId, int date, int totalSleep, int remSleep, int deepSleep, int lightSleep, int awakeTime);
        int[] GetSleepHistoryData(int userId, int date, string columnName);
    }
}
