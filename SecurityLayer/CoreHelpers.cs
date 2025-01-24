using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CoreHelpers
    {
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

        public Guid GenerateId()
        {
            return Guid.NewGuid();
        }

    }
}
