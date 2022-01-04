using I_challenge_you_3._0.DataAccessLayers;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            userImage.ImageSource = MainWindow.LoggedUser.Image;
            frame.Source = new Uri("HomePage.xaml", UriKind.RelativeOrAbsolute);
            LoadNotificationCount();
        }

        public void LoadNotificationCount()
        {
            int c = NotificationDAL.GetNotificationCount(MainWindow.LoggedUser.IdUser) + (
                                UserDAL.getUserPendingFriends(MainWindow.LoggedUser.IdUser).Count() > 0 ? 1 : 0);
            notifCount.count.Content = Math.Min(c, 99).ToString();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("ProfilePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void NewPost_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("PostOrChallengePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("SearchPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("FriendsPage.xaml", UriKind.RelativeOrAbsolute);
        }
        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("MessagesPage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            frame.Source = new Uri("HomePage.xaml", UriKind.RelativeOrAbsolute);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LoggedUser = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
}
