using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileComponent
{
    public interface IUserProfile
    {
        int UserProfileExists(string userEmail);
        string UserNameCreation(string userEmail);
        int CreateUserProfile(string usernameEnc, string emailEnc, string passwordHash, string firstNameEnc, int recoveryQuestion, string recoveryAnswerHash, int height, int weight, int sex, int age);
        object GetDataFromUserData(int userId, string columnName);
        void UpdateUserData(int userId, object input, string columnName);
        bool SecurityAnswerApproval(int userId, string securityAnswerHash);
    }
}
