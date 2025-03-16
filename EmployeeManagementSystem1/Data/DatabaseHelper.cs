using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Dapper;



namespace EmployeeManagementSystem1.Data
{
    public class DatabaseHelper
    {
        private static readonly string ConnectionString = "Data Source=employeeDB.db;Version=3;";
        private static readonly string dbFile = "employee_db.sqlite";
        private static readonly string connectionString = $"Data Source={dbFile};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Kullanıcılar tablosunu oluştur
                string createUsersTable = @"CREATE TABLE IF NOT EXISTS Users (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Username TEXT UNIQUE,
            PasswordHash TEXT,
            Role TEXT)";
                connection.Execute(createUsersTable);

                // Eğer admin yoksa ekle
                string checkAdmin = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'";
                long adminExists = connection.ExecuteScalar<long>(checkAdmin);

                if (adminExists == 0)
                {
                    // Şifreyi hash'le
                    string adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("123456");

                    // Admin kullanıcısını veritabanına ekle
                    string insertAdmin = "INSERT INTO Users (Username, PasswordHash, Role) VALUES ('admin', @PasswordHash, 'Admin')";
                    connection.Execute(insertAdmin, new { PasswordHash = adminPasswordHash });
                }
            }
        }


    }
}