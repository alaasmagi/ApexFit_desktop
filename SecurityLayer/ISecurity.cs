using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer
{
    internal interface ISecurity
    {
        bool LoginAttempt(string username, string password);
        string GenerateHash(string input);
    }
}
