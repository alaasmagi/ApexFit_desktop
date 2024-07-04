using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading.Tasks;
using CoreComponent;

namespace UserProfileComponent
{
    public class CUserProfile:IUserProfile
    {
        private CoreComponent.ICore Core;
        private string connectionString;
        public bool IsValidEmailAddress(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(emailAddress, pattern);
        }

        public int GenerateUserId()
        {
            Core = new CoreComponent.CCore();
            Random randomInt = new Random();
            int userId = Core.DateToInt(DateTime.Today) * 10000 + randomInt.Next(1000, 10000);
            return userId;
        }
        
        //public bool CreateUserProfile(string firstName, string email, )
    }
}
