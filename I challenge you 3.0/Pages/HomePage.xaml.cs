using I_challenge_you_3._0.DataAccessLayer;
using I_challenge_you_3._0.Model;
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
            this.loggedUser = user;
            DataContext = this;
            int num = 100;
            for (int i = 0; i < num; i++)
            {
                DisplayPost displayPost = new DisplayPost();
                displayPost.Padding = new Thickness(10);
                postPanel.Children.Add(displayPost);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage(loggedUser));
        }

        private void NewPost_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePostPage(loggedUser));
        }
    }
}
