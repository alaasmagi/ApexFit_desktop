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
    public class CUserProfile : IUserProfile
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

        public int UserProfileExists(string userNameEnc)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            int userIdOutput= 0;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT user_id FROM user_data WHERE username_enc = @userNameEnc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userNameEnc", userNameEnc);

                connection.Open();
                object result = command.ExecuteScalar();
               
                if (result != null)
                {
                    int.TryParse(result.ToString(), out userIdOutput);
                    return userIdOutput;
                }
                else
                {
                    return userIdOutput;
                }
            }
        }

        public int CreateUserProfile(string usernameEnc, string userEmailEnc, string passwordHash, string firstNameEnc, int recoveryQuestion, string recoveryAnswerHash, int height, int weight, int sex, int age)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            int userIdOutput = 0;

            string query = "INSERT INTO user_data (username_enc, user_email_enc, password_hash, firstname_enc, recovery_question_id, recovery_answer_hash, height, weight, sex, age, calorie_limit, weight_goal) " +
                           "VALUES (@usernameEnc, @userEmailEnc, @passwordHash, @firstNameEnc, @recoveryQuestion, @recoveryAnswerHash, @height, @weight, @sex, @age, @calorieLimit, @weightGoal)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usernameEnc", usernameEnc);
                command.Parameters.AddWithValue("@userEmailEnc", userEmailEnc);
                command.Parameters.AddWithValue("@passwordHash", passwordHash);
                command.Parameters.AddWithValue("@firstNameEnc", firstNameEnc);
                command.Parameters.AddWithValue("@recoveryQuestion", recoveryQuestion);
                command.Parameters.AddWithValue("@recoveryAnswerHash", recoveryAnswerHash);
                command.Parameters.AddWithValue("@height", height);
                command.Parameters.AddWithValue("@weight", weight);
                command.Parameters.AddWithValue("@sex", sex);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@calorieLimit", weight);
                command.Parameters.AddWithValue("@weightGoal", 0); 

                connection.Open();
                command.ExecuteNonQuery();

                userIdOutput = UserProfileExists(userEmailEnc);

                return userIdOutput;
            }
        }

        public int GetIntegerFromUserData(int userId, string columnName)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            int resultOutput = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT {columnName} FROM user_data WHERE user_id = @userId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                object result = command.ExecuteScalar();

                int.TryParse(result.ToString(), out resultOutput);

                return resultOutput;
            }
        }

        public string GetStringFromUserData(int userId, string columnName)
        {
            Core = new CoreComponent.CCore();
            connectionString = Core.GetConnectionString();
            string resultOutput = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT {columnName} FROM user_data WHERE user_id = @userId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    resultOutput = result.ToString();
                }

                return resultOutput;
            }
        }

        public bool SecurityAnswerApproval(int userId, string securityAnswerHash)
        {
            Security = new SecurityLayer.CSecurity();
            string userSecurityAnswer = GetStringFromUserData(userId, "recovery_answer_hash");

            if (userSecurityAnswer == securityAnswerHash)
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
