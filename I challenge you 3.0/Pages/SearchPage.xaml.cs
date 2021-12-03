using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
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

namespace I_challenge_you_3._0.Pages
{
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            searchedPanel.Children.Clear();

            List<User> foundUsers = UserDAL.searchUsers(searchBox.Text);
            if(foundUsers.Count != 0 )
            {
                foreach(User foundUser in foundUsers)
                {
                    if (foundUser.Username != MainWindow.LoggedUser.Username)
                    {
                        searchedPanel.Children.Add(new SearchedUser(foundUser));
                    }
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}
