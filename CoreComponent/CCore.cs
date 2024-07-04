using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponent
{
    public class CCore:ICore
    {
        public string GetConnectionString()
        {
            string baseConnectionString = ConfigurationManager.ConnectionStrings["DefaultDBConnection"]?.ConnectionString;

            if (baseConnectionString == null)
            {
                throw new InvalidOperationException("Connection string 'DefaultDBConnection' not found in the configuration file.");
            }

            string password = Environment.GetEnvironmentVariable("APEX_DB");

            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidOperationException("Database password is not set in the environment variables.");
            }

            string connectionString = baseConnectionString.Replace("{PASSWORD}", password);

            return connectionString;
        }

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
