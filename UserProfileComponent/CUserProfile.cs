using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading.Tasks;
using CoreComponent;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace UserProfileComponent
{
    public class CUserProfile:IUserProfile
    {
        private CoreComponent.ICore Core;
        private SecurityLayer.ISecurity Security;
        private string connectionString;
        public bool IsValidEmailAddress(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(emailAddress, pattern);
        }

        public int GenerateUserId()
        {
            Core = new CoreComponent.CCore();
            Random randomInt = new Random();
            int userId = Core.DateToInt(DateTime.Today) * 10000 + randomInt.Next(1000, 10000);
            return userId;
        }

        public string UserNameCreation(string userEmail)
        {
            int atIndex = userEmail.IndexOf('@');
            return userEmail.Substring(0, atIndex);
        }

        public bool UserProfileExists(string userEmail)
        {
            Core = new CoreComponent.CCore();

            int userId = 0;
            connectionString = Core.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT user_id FROM user_data WHERE user_email_enc = @userEmail";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username_enc", userEmail);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }

                if (userId != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        public bool CreateUserProfile(string usernameEnc, string emailEnc, string passwordHash, string firstNameEnc, int recoveryQuestion, string recoveryAnswerHash, int height, int weight, int sex, int age)
        {
            int userId = GenerateUserId();

            string query = "INSERT INTO user_data (user_id, usename_enc, user_email_enc, password_hash, firstname_hash, recovery_question, recovery_answer_hash, height, weight, sex, age, calorie_limit, weight_goal)" +
                "VALUES (@userId, @username_enc, @user_email_enc, @password_hash, @firstname_hash, @recovery_question, @recovery_answer_hash, @height, @weight, @sex, @age, @calorie_limit, @weight_goal)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@username_enc", usernameEnc);
                command.Parameters.AddWithValue("@user_email_enc", emailEnc);
                command.Parameters.AddWithValue("@password_hash", passwordHash);
                command.Parameters.AddWithValue("@firstname_hash", firstNameEnc);
                command.Parameters.AddWithValue("@recovery_question", recoveryQuestion);
                command.Parameters.AddWithValue("@recovery_answer_hash", recoveryAnswerHash);
                command.Parameters.AddWithValue("@height", height);
                command.Parameters.AddWithValue("@weight", weight);
                command.Parameters.AddWithValue("@sex", sex);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@calorie_limit", weight);
                command.Parameters.AddWithValue("@weight_goal", 0);

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
                catch (SqlException e)
                {
                }
            }
        }
}
