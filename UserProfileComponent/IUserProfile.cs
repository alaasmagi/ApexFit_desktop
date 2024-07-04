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
        bool UserProfileExists(string userEmail);
        string UserNameCreation(string userEmail);
        bool CreateUserProfile(string usernameEnc, string emailEnc, string passwordHash, string firstNameEnc, int recoveryQuestion, string recoveryAnswerHash, int height, int weight, int sex, int age);
    }
}
