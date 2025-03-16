using EmployeeManagementSystem1.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagementSystem1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DatabaseHelper.InitializeDatabase(); // Veritabanını başlat
            Views.LoginPage loginWindow = new Views.LoginPage();
            loginWindow.Show();
        }

    }
}
