using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public User LoggedUser { get; set; }

        public ProfilePage(User user)
        {
            StatusDAL.getStatuses();
            InitializeComponent();
            this.LoggedUser = user;
            Statuses.ItemsSource = StatusMap.Statuses;
            Statuses.SelectedIndex = StatusMap.getStatusId(LoggedUser.Status) - 1;
            Username.Text = LoggedUser.Username;
            Email.Text = LoggedUser.Email;
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDAL.changeStatus(LoggedUser.IdUser, Statuses.SelectedIndex + 1);
        }

        private void EditUsername_Click(object sender, RoutedEventArgs e)
        {
            UserDAL.changeUsername(LoggedUser.IdUser, Username.Text);
        }

        private void EditEmail_Click(object sender, RoutedEventArgs e)
        {
            UserDAL.changeEmail(LoggedUser.IdUser, Email.Text);
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
           if(OldPass.Text==LoggedUser.Pass)
            {
                if(NewPass.Text == ReNewPass.Text)
                {
                    UserDAL.changePassword(LoggedUser.IdUser, NewPass.Text);
                }
                else
                {
                    MessageBox.Show("The new password was not typed again properly");
                }
            }
            else
            {
                MessageBox.Show("The old password you entered is wrong");
            }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage(loggedUser));
        }
    }
}
