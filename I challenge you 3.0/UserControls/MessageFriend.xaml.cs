using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace I_challenge_you_3._0.UserControls
{
    public partial class MessageFriend : UserControl
    {
        public User Friend { get; set; }
        public MessagesPage Page { get; set; }
        public MessageFriend(User friend, MessagesPage page)
        {
            InitializeComponent();

            DataContext = this;
            Friend = friend;
            Page = page;
        }

        private void MessageFriend_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessagesPage.LoadMessages(Friend, Page);
            Notification notif = NotificationDAL.GetNotificationByMessageFrom(MainWindow.LoggedUser.IdUser, Friend.IdUser);
            if(notif != null)
            {
                notif.Seen = true;
                NotificationDAL.UpdateMessageNotification(notif);
                MainPage mainPage = new MainPage();
                mainPage.LoadNotificationCount();
            }
        }
    }
}
