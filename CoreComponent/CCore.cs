using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

            string password = Environment.GetEnvironmentVariable("AF_userlogin");

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

        public bool CheckPasswordRequirements(string password1, string password2)
        {
            if (password1 == "Salasõna" || password1 == "Uus salasõna" || password1 == "Praegune salasõna")
            {
                return false;
            }
            else if (password1.Length < 8)
            {
                return false;
            }
            else if (password2 != null && (password2 == "Salasõna" || password2 == "Uus salasõna" || password2 == "Korda salasõna"))
            {
                return false;
            }
            else if (password2 != null && password1 != password2)
            {
                return false;
            }

            return true;
        }
        
        public bool CheckEmailRequirements(string email)
        { 
                string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                return Regex.IsMatch(email, pattern);
        }

        public int CalculateTrainingConsumption(int calories, int duration)
        {
            int result = Math.Round(duration * (TreeninguEnergiakuluParing(treeninguId) / 60), 1)
        }
    }
}
