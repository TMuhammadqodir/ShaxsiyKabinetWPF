using MarketApplication.DbContexts;
using MarketApplication.Entities.Users;
using MarketApplication.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Create_Click1(object sender, RoutedEventArgs e)
        {
            AppDbContext appDbContext = new AppDbContext();
            
            var temp1 = tbEmail.Text;

            var user = appDbContext.UserEntities.FirstOrDefault(x =>
            x.Email.ToLower() == temp1.ToLower());

            if (pwbPassword.Password == pwbConfirmPassword.Password && user is null && tbFirstName.Text != "" && tbLastName.Text != "" && pwbPassword.Password != "")
            { 
                UserEntity userEntity = new UserEntity();

                var temp = PasswordHasher.Hash(pwbPassword.Password);

                userEntity.FirstName = tbFirstName.Text;
                userEntity.LastName = tbLastName.Text;
                userEntity.Email = tbEmail.Text;
                userEntity.PasswordHash = temp.PasswordHash;
                userEntity.Salt = temp.Passwordsalt;

                appDbContext.UserEntities.Add(userEntity);
                appDbContext.SaveChanges();
                
                LoginWindow loginWindow = new LoginWindow();

                loginWindow.Show(); 

                this.Close();
            }
            else
            {
                MessageBox.Show("Something is wrong!");
            }
        }

        private void Create_Click2(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();

            loginWindow.Show();

            this.Close();
        }
    }
}
