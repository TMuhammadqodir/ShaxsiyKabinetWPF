using Azure;
using MarketApplication.DbContexts;
using MarketApplication.Security;
using Microsoft.EntityFrameworkCore;
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

namespace MarketApplication.Windows.Users
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click1(object sender, RoutedEventArgs e)
        {
            AppDbContext appDbContext = new AppDbContext();

            var temp1 = tbEmail.Text;

            var user = appDbContext.UserEntities.FirstOrDefault(x =>
            x.Email.ToLower() == temp1.ToLower());

            if(user is null)
            {
                MessageBox.Show("something is wrong!");
                return;
            }

            bool CheckPassword = PasswordHasher.Verify(pwbPassword.Password, user.PasswordHash, user.Salt);

            if(CheckPassword)
            {
                MainWindow mainWindow = new MainWindow(user.Id);

                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("something is wrong");
            }
        }

        private void Login_Click2(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();

            registerWindow.Show();

            this.Close();
        }
    }
}
