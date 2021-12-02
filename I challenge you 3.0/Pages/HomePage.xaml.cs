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
        public User loggedUser { get; set; }

        public HomePage(User user)
        {
            InitializeComponent();
            DataContext = this;
            this.loggedUser = user;
            loadPosts();
        }

        public void loadPosts()
        {
            List<Post> posts = new List<Post>();
            posts.AddRange(PostDAL.getPosts(loggedUser.IdUser));
            foreach(User friend in UserDAL.getUserFriends(loggedUser.IdUser))
            {
                posts.AddRange(PostDAL.getPosts(friend.IdUser));
            }
            foreach (var post in posts )
            {
                DisplayPost displayPost = new DisplayPost(post);
                displayPost.Padding = new Thickness(10);
                postPanel.Children.Add(displayPost);
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(loggedUser));
        }

        private void NewPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePostPage(loggedUser));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SearchPage(loggedUser));
        }
        
        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendsPage(loggedUser));
        }
    }
}
