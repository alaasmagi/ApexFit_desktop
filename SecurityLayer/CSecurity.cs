using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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

        public bool LoginAttempt(string username, string password)
        {
            CoreComponent.ICore Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT password_hash FROM user_data WHERE username_enc = @username_enc";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username_enc", username);

                connection.Open();
                object result = command.ExecuteScalar();

                string storedPasswordHash = result.ToString();

                if (storedPasswordHash == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                connection.Open();

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

        public string GenerateHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

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

        public bool ChangeUserPassword(int userId, string passwordHash)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString(); // Replace with your method to get the connection string

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
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}

