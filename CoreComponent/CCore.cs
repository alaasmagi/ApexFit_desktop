using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponent
{
    public class CCore:ICore
    {
        public int DateToInt(DateTime inputDate)
        {
            DateTime unixTime = new DateTime(1970, 1, 1);
            return (inputDate - unixTime).Days;
        }

        public DateTime IntToDate(int inputInt)
        {
            DateTime unixTime = new DateTime(1970, 1, 1);
            return unixTime.AddDays(inputInt);
        }
    }
}
