﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponent
{
    public interface ICore
    {
        int DateToInt(DateTime inputDate);
        string GetConnectionString();
        DateTime IntToDate(int inputInt);
    }
}