using I_challenge_you_3._0.DataAccessLayers;
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

namespace I_challenge_you_3._0.UserControls
{
    public partial class SearchedUser : UserControl
    {
        public User loggedUser { get; set; }
        public User searchedUser { get; set; }
        public SearchedUser(User searchedUser, User loggedUser)
        {
            InitializeComponent();
            DataContext = this;

            this.loggedUser = loggedUser;
            this.searchedUser = searchedUser;
        }

        private void AddFriendClick(object sender, RoutedEventArgs e)
        {
            FriendshipDAL.createFriendship(loggedUser, searchedUser);
            AddFriendButton.Visibility = Visibility.Hidden;

            MessageBox.Show("The user has been added to your friends list");
        }
    }
}
