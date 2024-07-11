using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer
{
    public interface ISecurity
    {
        bool LoginAttempt(int userId, string password);
        List<string> GetAllSecurityQuestions();
        string GenerateSalt();
        string GetUserSalt(int userId);
        string GenerateHash(string input, string salt);
        string EncryptString(string input);
        string DecryptString(string input);
        string GetMacAddress();
        string FormatMacAddress(PhysicalAddress macAddress);
        void CreateLoginToken(int userId);
        string GetSecurityQuestion(int recoveryQuestionId);
        int LoginWithToken();
        void RemoveToken(int userId);
        bool ChangeUserPassword(int userId, string passwordHash);
    }
}
