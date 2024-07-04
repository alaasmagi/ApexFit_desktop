using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer
{
    public interface ISecurity
    {
        bool LoginAttempt(string username, string password);
        List<string> GetSecurityQuestions();
        string GenerateHash(string input);
        string EncryptString(string input);
        string DecryptString(string input);
    }
}
