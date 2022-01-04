using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    if(VerifyEmail(email.Text) == false)
                    {
                        MessageBox.Show("Invalid email address");
                    }
                    else
                    {
                        if(VerifyPassword() == false)
                        {
                            MessageBox.Show("Password must contain at least one lower case letter, at least one upper case letter, at least a special character, at least one number and must be at least 8 characters long");
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

        private bool VerifyEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private bool VerifyPassword()
        {
            int validConditions = 0;
            foreach (char c in password.Password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in password.Password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in password.Password)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            if (validConditions == 2)
            {
                char[] special = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+' };   
                if (password.Password.IndexOfAny(special) == -1) return false;
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
