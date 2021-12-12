using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.UserControls;
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
    /// Interaction logic for SelectChallengeForResponse.xaml
    /// </summary>
    public partial class SelectChallengeForResponse : Page
    {
        public SelectChallengeForResponse()
        {
            InitializeComponent();
            DataContext = this;
            LoadPosts();
        }

        public void LoadPosts()
        {
            List<Post> posts = PostDAL.getPosts(MainWindow.LoggedUser.IdUser);

            foreach (var post in posts)
            {
                
                DisplayPost displayPost = new DisplayPost(post);
                displayPost.postImage.Visibility = Visibility.Hidden;
                displayPost.MouseDoubleClick += DisplayPost_MouseDoubleClick;
                displayPost.Padding = new Thickness(10);
                postPanel.Children.Add(displayPost);
            }
        }

        private void DisplayPost_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //(DisplayPost)sender.usernameLabel.
            var displayedPost = (DisplayPost)sender;
            displayedPost.usernameLabel.Content = "Clicked";
        }
    }
}
