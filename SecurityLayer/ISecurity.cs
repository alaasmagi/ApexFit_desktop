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
        string GenerateHash(string input);
    }
}
