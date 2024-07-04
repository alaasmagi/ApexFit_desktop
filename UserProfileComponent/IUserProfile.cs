using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileComponent
{
    public interface IUserProfile
    {
        bool IsValidEmailAddress(string emailAddress);
        int GenerateUserId();

    }
}
