using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.UserControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace I_challenge_you_3._0.Pages
{
    public partial class FriendProfilePage : Page
    {
        public User friend { get; set; }
        public Brush statusColor { get; set; }
        public FriendProfilePage(User friend)
        {
            InitializeComponent();
            DataContext = this;
            this.friend = friend;
            userImage.ImageSource = friend.Image;
            username.Content = friend.Username;
            switch(this.friend.Status)
            {
                case "Available":
                    this.statusColor = new SolidColorBrush(Colors.Green);
                    break;
                case "Away":
                    this.statusColor = new SolidColorBrush(Colors.Yellow);
                    break;
                default:
                    this.statusColor = new SolidColorBrush(Colors.Red);
                    break;
            }
            LoadPosts();
        }

        public void LoadPosts()
        {
            List<Post> posts = PostDAL.getOwnPosts(this.friend.IdUser);

            foreach(var post in posts)
            {
                post.ContentType = "";
                LiteDisplayPost displayPost = new LiteDisplayPost(post, this);
                displayPost.Padding = new Thickness(10);
                postPanel.Children.Add(displayPost);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainWindow.HomePage);
        }
    }
}
