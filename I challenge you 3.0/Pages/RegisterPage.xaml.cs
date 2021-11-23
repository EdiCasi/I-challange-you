using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
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

namespace I_challenge_you_3._0.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            int numberOfRecords = UserDAL.verifyEmail(email.Text);
            if (DataValidation() == true)
            {
                if (numberOfRecords == 1)
                {
                    MessageBox.Show("Email allready in use");
                    RegisterPopup.IsOpen = true;
                }
                else
                {
                    if (password.Password == confirmPassword.Password)
                    {
                        CreateUser();
                        message.Text = "Account created successfully.";
                        RegisterPopup.IsOpen = true;
                    }
                    else
                    {
                        MessageBox.Show("Passwords don`t match. Please try again");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please complete all fields");
            }
        }

        private void CreateUser()
        {
            User newUser = new User();
            newUser.Username = username.Text;
            newUser.Email = email.Text;
            newUser.Pass = password.Password;

            UserDAL.createUser(newUser);
        }

        private bool DataValidation()
        {
            if(String.IsNullOrWhiteSpace(username.Text) || String.IsNullOrWhiteSpace(email.Text) || String.IsNullOrWhiteSpace(password.Password)){
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterPopup.IsOpen = false;
            NavigationService.Navigate(new LoginPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
