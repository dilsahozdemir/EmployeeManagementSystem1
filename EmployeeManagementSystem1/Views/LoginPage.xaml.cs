using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EmployeeManagementSystem1.Services;
using EmployeeManagementSystem1.Models;

namespace EmployeeManagementSystem1.Views
{
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;      // Kullanıcı adını al
            string password = txtPassword.Password;  // Şifreyi al

            // Kullanıcıyı doğrula
            User user = AuthService.AuthenticateUser(username, password);

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Username}!", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Giriş başarılıysa pencereyi kapat
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
