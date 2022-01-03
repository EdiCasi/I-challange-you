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
    /// Interaction logic for NotificationsPage.xaml
    /// </summary>
    public partial class NotificationsPage : Page
    {
        public NotificationsPage()
        {
            InitializeComponent();
            NotificationDAL.UpdateNotificationsSeen(MainWindow.LoggedUser.IdUser, true);
            MainWindow.HomePage.LoadNotificationCount();
            LoadFriendRequests();
            LoadNotifications();
        }

        private void LoadFriendRequests()
        {
            List<User> requests = UserDAL.getUserPendingFriends(MainWindow.LoggedUser.IdUser);

            friendsPanel.Children.Add(new Label()
            {
                Content = requests.Count() + " friend request(s) pending.",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 18
            });
            Button fButton = friendsButton;
            friendsPanel.Children.Remove(friendsButton);
            friendsPanel.Children.Add(fButton);
        }
        private void LoadNotifications()
        {
            List<Notification> notifs = NotificationDAL.GetNotifications(MainWindow.LoggedUser.IdUser);
            bool postExist = false;
            bool messageExist = false;

            if(notifs.Count() > 0)
            {
                foreach(var notif in notifs)
                {
                    if(notif.Type == "message")
                    {
                        messagePanel.Children.Add(new NotificationControl(notif, this)
                        {
                            Padding = new Thickness(10)
                        });
                        messageExist = true;
                    }
                    else
                    {
                        postPanel.Children.Add(new NotificationControl(notif, this)
                        {
                            Padding = new Thickness(10)
                        });
                        postExist = true;
                    }
                }
            }

            if(messageExist == false)
            {
                messagePanel.Children.Add(new Label()
                {
                    Content = "No challenges / responses received.",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 18
                });
            }

            if(postExist == false)
            {
                postPanel.Children.Add(new Label()
                {
                    Content = "No challenges / responses received.",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontSize = 18
                });
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainWindow.HomePage);
        }
        
        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FriendsPage());
        }
    }
}
