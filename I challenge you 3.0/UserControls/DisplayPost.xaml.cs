using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Model;
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
    /// Interaction logic for DisplayPost.xaml
    /// </summary>
    public partial class DisplayPost : UserControl
    {
        //public Post post { get; set; }
        public DisplayPost() //Post post
        {
            InitializeComponent();
            //this.post = post;
            DataContext = this;
        }
    }
}
