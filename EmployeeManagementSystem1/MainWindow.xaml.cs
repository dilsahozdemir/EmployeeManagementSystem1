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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmployeeManagementSystem1.Services;
using EmployeeManagementSystem1.Models;

namespace EmployeeManagementSystem1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Personel Güncelleme Butonu Tıklandığında Çalışacak Kod
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text, position = PositionTextBox.Text, department = DepartmentTextBox.Text;
            decimal salary;


            if (!decimal.TryParse(SalaryTextBox.Text, out salary))
            {
                MessageBox.Show("Lütfen geçerli bir maaş girin.");
                return;
            }

            bool isAdded = EmployeeService.AddEmployee(name, position, salary, department);

            if (isAdded)
            {
                MessageBox.Show("Personel başarıyla eklendi!");
            }
            else
            {
                MessageBox.Show("Personel eklenirken bir hata oluştu.");
            }
        }

    }
}

