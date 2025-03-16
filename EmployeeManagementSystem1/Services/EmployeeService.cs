using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using EmployeeManagementSystem1.Data;
using EmployeeManagementSystem1.Models;


namespace EmployeeManagementSystem1.Services
{
    public class EmployeeService
    {
        // Personel ekleme işlemi
        public static bool AddEmployee(string name, string position, decimal salary, string department)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Employees (Name, Position, Salary, Department) VALUES (@Name, @Position, @Salary, @Department)";
                int result = connection.Execute(query, new { Name = name, Position = position, Salary = salary, Department = department });
                return result > 0;
            }
        }

        // Personel silme işlemi
        public static bool DeleteEmployee(int employeeId)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Employees WHERE Id = @Id";
                int result = connection.Execute(query, new { Id = employeeId });
                return result > 0;
            }
        }

        // Personel güncelleme işlemi
        public static bool UpdateEmployee(int id, string name, string position, decimal salary, string department)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Employees SET Name = @Name, Position = @Position, Salary = @Salary, Department = @Department WHERE Id = @Id";
                int result = connection.Execute(query, new { Id = id, Name = name, Position = position, Salary = salary, Department = department });
                return result > 0;
            }
        }
        // Personel listeleme işlemi
        public static List<Employee> GetAllEmployees()
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Employees";
                return connection.Query<Employee>(query).ToList();
            }
        }
    }
}
