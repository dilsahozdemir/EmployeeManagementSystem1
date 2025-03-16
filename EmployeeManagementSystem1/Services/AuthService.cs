using System;
using System.Data.SQLite;
using Dapper;
using BCrypt.Net;
using EmployeeManagementSystem1.Models;

namespace EmployeeManagementSystem1.Services
{
    public class AuthService
    {
        private static string ConnectionString = "Data Source=employeeDB.db;Version=3;";

        public static bool RegisterUser(string username, string password, string role)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
                int result = connection.Execute(query, new { Username = username, PasswordHash = passwordHash, Role = role });
                return result > 0;
            }
        }

        public static User AuthenticateUser(string username, string password)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Kullanıcıyı veritabanından al
                string query = "SELECT * FROM Users WHERE Username = @Username";
                var user = connection.QueryFirstOrDefault<User>(query, new { Username = username });

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                {
                    // Şifre doğruysa kullanıcıyı döndür
                    return user;
                }

                // Şifre yanlışsa null döndür
                return null;
            }
        }
    }
}


