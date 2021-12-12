using I_challenge_you_3._0.DataAccessLayer;
using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.Pages;
using I_challenge_you_3._0.UserControls;
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

namespace I_challenge_you_3._0
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = this;
            userImage.ImageSource = MainWindow.LoggedUser.Image;
            LoadPosts();
        }

        public void LoadPosts()
        {
            List<Post> posts = PostDAL.getPosts(MainWindow.LoggedUser.IdUser);

            foreach (var post in posts )
            {
                DisplayPost displayPost = new DisplayPost(post);
                displayPost.Padding = new Thickness(10);
                postPanel.Children.Add(displayPost);
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void NewPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PostOrChallengePage());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchPage());
        }
        
        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendsPage());
        }
        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MessagesPage());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LoggedUser = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
}
