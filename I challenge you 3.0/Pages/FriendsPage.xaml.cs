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
    public partial class FriendsPage : Page
    {
        public User loggedUser { get; set; }
        public List<User> friends { get; set; }
        public FriendsPage(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.friends = UserDAL.getUserFriends(loggedUser.IdUser);

            foreach(User user in friends)
            {
                Friend friend = new Friend(user, loggedUser,this);
                friendsPanel.Children.Add(friend);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage(loggedUser));
        }
    }
}
