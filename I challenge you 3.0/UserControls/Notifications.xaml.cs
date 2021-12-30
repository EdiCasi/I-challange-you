using I_challenge_you_3._0.DataAccessLayers;
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
    public partial class Notifications : UserControl
    {
        public Notifications()
        {
            InitializeComponent();
            GetNotifCount();
        }

        private void GetNotifCount()
        {
            notifCount.Content = NotificationDAL.GetNotificationCount(MainWindow.LoggedUser.IdUser).ToString();
        }
    }
}
