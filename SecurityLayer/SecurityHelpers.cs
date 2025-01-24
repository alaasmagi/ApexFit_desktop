using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BusinessLogic
{
    public class SecurityHelpers
    {
        public string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public string GenerateHash(string input, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string saltedInput = salt + input;
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedInput));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string EncryptString(string input)
        {
            StringBuilder ouput = new StringBuilder();

            foreach (char taht in input)
            {
                if (taht == 'z')
                {
                    ouput.Append('a');
                }
                else if (taht == 'Z')
                {
                    ouput.Append('A');
                }
                else if (char.IsLetter(taht))
                {
                    ouput.Append((char)(taht + 1));
                }
                else
                {
                    ouput.Append(taht);
                }
            }
            return ouput.ToString();
        }

        public string DecryptString(string input)
        {
            StringBuilder ouput = new StringBuilder();

            foreach (char taht in input)
            {
                if (taht == 'a')
                {
                    ouput.Append('z');
                }
                else if (taht == 'A')
                {
                    ouput.Append('Z');
                }
                else if (char.IsLetter(taht))
                {
                    ouput.Append((char)(taht - 1));
                }
                else
                {
                    ouput.Append(taht);
                }
            }
            return ouput.ToString();
        }

        public string GenerateLoginToken()
        {
            return GenerateHash(EncryptString(GetMacAddress()), "LoginToken");
        }

        public string GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback && nic.OperationalStatus == OperationalStatus.Up)
                {
                    return FormatMacAddress(nic.GetPhysicalAddress());
                }
            }
            return null;
        }

        public string FormatMacAddress(PhysicalAddress macAddress)
        {
            return string.Join(":", macAddress.GetAddressBytes().Select(b => b.ToString("X2")));
        }
    }
}

