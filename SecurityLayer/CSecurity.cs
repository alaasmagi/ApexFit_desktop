﻿using System;
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
    public class CSecurity:ISecurity
    {
        private CoreComponent.ICore Core;

        public bool LoginAttempt(string username, string password)
        {
            CoreComponent.ICore Core = new CoreComponent.CCore();
            string connectionString = Core.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT password_hash FROM user_data WHERE username_hash = @username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null) // Check if a password_hash was returned
                    {
                        string storedPasswordHash = result.ToString();

                        // For simplicity, assuming password comparison (should use hashed passwords)
                        if (storedPasswordHash.Equals(password))
                        {
                            return true; // Password matches
                        }
                    }

                    return false; // Password does not match or user not found
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false; // Return false on error
                }
            }
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

    }
    }

