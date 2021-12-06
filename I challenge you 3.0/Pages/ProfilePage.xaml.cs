using I_challenge_you_3._0.Converters;
using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using Microsoft.Win32;
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
        public ProfilePage()
        {
            if(StatusMap.Statuses.Count == 0) 
            {
                StatusDAL.getStatuses();
            }
            InitializeComponent();
            Statuses.ItemsSource = StatusMap.Statuses;
            Statuses.SelectedIndex = StatusMap.getStatusId(MainWindow.LoggedUser.Status) - 1;
            Username.Text = MainWindow.LoggedUser.Username;
            Email.Text = MainWindow.LoggedUser.Email;
            DataContext = this;
            userImage.ImageSource = MainWindow.LoggedUser.Image;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDAL.changeStatus(MainWindow.LoggedUser.IdUser, Statuses.SelectedIndex + 1);
            MainWindow.LoggedUser = UserDAL.getUserById(MainWindow.LoggedUser.IdUser);
        }

        private void EditUsername_Click(object sender, RoutedEventArgs e)
        {
            UserDAL.changeUsername(MainWindow.LoggedUser.IdUser, Username.Text);
        }

        private void EditEmail_Click(object sender, RoutedEventArgs e)
        {
            UserDAL.changeEmail(MainWindow.LoggedUser.IdUser, Email.Text);
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (OldPass.Text == MainWindow.LoggedUser.Pass)
            {
                if (NewPass.Text == ReNewPass.Text)
                {
                    UserDAL.changePassword(MainWindow.LoggedUser.IdUser, NewPass.Text);
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
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] image;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg;";
            if (fileDialog.ShowDialog() == true)
            {
                MainWindow.LoggedUser.Image = new BitmapImage(new Uri(fileDialog.FileName));
                userImage.ImageSource = MainWindow.LoggedUser.Image;
                image = ByteImageConverter.ConvertImageToBytes(System.Drawing.Image.FromFile(fileDialog.FileName));
                UserDAL.changeUserImage(MainWindow.LoggedUser.IdUser, image);
            }
            else
            {
                image = null;
            }
        }
    }
}
