using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileComponent
{
    internal interface IUserProfile
    {
        bool IsValidEmailAddress(string emailAddress);
        int GenerateUserId();

    }
}
