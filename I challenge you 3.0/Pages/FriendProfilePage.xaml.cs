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
    public partial class FriendProfilePage : Page
    {
        public User loggedUser { get; set; }

        public User friend { get; set; }
        public FriendProfilePage(User loggedUser, User friend)
        {
            InitializeComponent();
            DataContext = this;

            this.loggedUser = loggedUser;
            this.friend = friend;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendsPage(loggedUser));
        }
    }
}
