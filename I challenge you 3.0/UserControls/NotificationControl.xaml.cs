using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using I_challenge_you_3._0.Pages;
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
    /// <summary>
    /// Interaction logic for NotificationControl.xaml
    /// </summary>
    public partial class NotificationControl : UserControl
    {
        public Notification Notif { get; set; }
        public User OtherUser { get; set; }
        public Post Post { get; set; }
        public Page Page { get; set; }
        public NotificationControl(Notification notif, Page page)
        {
            InitializeComponent();
            DataContext = this;
            Notif = notif;
            Page = page;
            LoadNotification();
        }

        private void LoadNotification()
        {
            if(Notif.Type == "message")
            {
                OtherUser = UserDAL.getUserById((int)Notif.MessageFrom);
            }
            else
            {
                Post = PostDAL.GetPostById((int)Notif.IdPost);
                OtherUser = UserDAL.getUserById(Post.IdUser);
            }
            

            switch(Notif.Type)
            {
                case "challenge":
                    notifText.Text = "Challenge: " + Post.Title;
                    break;
                case "response":
                    Post challenge = PostDAL.GetPostById((int)Post.responseTo);
                    notifText.Text = "Response: " + challenge.Title;
                    break;
                case "message":
                    Message message = MessageDAL.getLastMessage(OtherUser, MainWindow.LoggedUser);
                    notifText.Text = OtherUser.Username + ": " + message.Text;
                    break;
            }
        }

        private void NotificationControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NotificationDAL.RemoveNotificationById(Notif.IdNotification);
            ((Panel)this.Parent).Children.Remove(this);

            switch (Notif.Type)
            {
                case "message":
                    MessagesPage page = new MessagesPage();
                    MessagesPage.LoadMessages(OtherUser, page);
                    MainWindow.Frame.NavigationService.Navigate(page);
                    break;
                case "challenge":
                case "response":
                    MainWindow.Frame.NavigationService.Navigate(new PostPage(Post, Page));
                    break;
            }
        }
    }
}
