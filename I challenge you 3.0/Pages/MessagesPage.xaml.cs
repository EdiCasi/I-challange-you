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
    public partial class MessagesPage : Page
    {
        public MessagesPage()
        {
            InitializeComponent();
            LoadFriends();
        }

        public void LoadFriends()
        {
            List<User> friends = UserDAL.getUserFriends(MainWindow.LoggedUser.IdUser);

            foreach (var friend in friends)
            {
                MessageFriend messageFriend = new MessageFriend(friend);
                messageFriend.Padding = new Thickness(10);
                friendPanel.Children.Add(messageFriend);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}
