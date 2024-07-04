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
        
        public bool CreateUserProfile(string firstName_enc, string email_enc, string password_hash, )
        { 
            string query = "INSERT INTO Users (user_id, usename_enc, user_email_enc, password_hash, firstname_hash, recovery_question, recovery_answer_hash, height, weight, sex, age, calorie_limit, weight_goal)" +
                "VALUES (@Id, @Name, @Email)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine("Row inserted successfully.");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error inserting row: " + e.Message);
                }
            }
        }
}
