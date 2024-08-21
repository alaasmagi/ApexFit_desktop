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

namespace SecurityLayer
{
    public class CSecurity : ISecurity
    {
        private CoreComponent.ICore Core;
        string connectionString;

        public bool LoginAttempt(int userId, string password)
        {
            CoreComponent.ICore Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            string salt = GetUserSalt(userId);
            string tempPasswordHash = GenerateHash(password, salt);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT password_hash FROM user_data WHERE user_id = @userId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                object result = command.ExecuteScalar();

                string storedPasswordHash = result.ToString();

                if (storedPasswordHash == tempPasswordHash)
                {
                    return true;
                }
                return false;
            }
        }

        public string GetUserSalt(int userId)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            string saltOutput = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT salt FROM user_data WHERE user_id = @userId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    saltOutput = result.ToString();
                }
                return saltOutput;
            }
        }

        public List<string> GetAllSecurityQuestions()
        {
            List<string> securityQuestions = new List<string>();

            CoreComponent.ICore Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT recovery_question FROM recovery_questions";

                SqlCommand command = new SqlCommand(query, connection);
                
                try
                {
                    connection.Open();
                }
                catch
                {
                    return null;
                }

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string question = reader["recovery_question"].ToString();
                    securityQuestions.Add(question);
                }
                reader.Close();
            }

            return securityQuestions;
            }

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

        public string GetSecurityQuestion(int recoveryQuestionId)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            string securityQuestion = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT recovery_question FROM recovery_questions WHERE recovery_question_id = @recoveryQuestionId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@recoveryQuestionId", recoveryQuestionId);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    securityQuestion = result.ToString();
                }
                return securityQuestion;
            }
        }

        public void CreateLoginToken(int userId)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            string tokenEnc = GenerateHash(EncryptString(GetMacAddress()), "LoginToken");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE user_data SET token_enc = @tokenEnc WHERE user_id = @userId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tokenEnc", tokenEnc);
                command.Parameters.AddWithValue("@userId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
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

        public bool ChangeUserPassword(int userId, string password)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            string salt = GetUserSalt(userId);
            string passwordHash = GenerateHash(password, salt);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = "UPDATE user_data SET password_hash = @passwordHash WHERE user_id = @userId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public int LoginWithToken()
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            string tokenEnc = GenerateHash(EncryptString(GetMacAddress()), "LoginToken");

            int userIdOutput = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT user_id FROM user_data WHERE token_enc = @tokenEnc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tokenEnc", tokenEnc);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    int.TryParse(result.ToString(), out userIdOutput);
                }
                return userIdOutput;
            }
        }

        public void RemoveToken(int userId)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE user_data SET token_enc = @tokenEnc WHERE user_id = @userId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tokenEnc", 0);
                command.Parameters.AddWithValue("@userId", userId);
                command.ExecuteNonQuery();
            }
        }
    }
}

