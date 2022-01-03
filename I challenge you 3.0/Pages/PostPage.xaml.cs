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
    /// Interaction logic for PostPage.xaml
    /// </summary>
    public partial class PostPage : Page
    {
        public Page PrevPage { get; set; }

        public PostPage(Post post, Page page)
        {
            InitializeComponent();
            DataContext = this;
            PrevPage = page;
            LoadPost(post);
        }

        private void LoadPost(Post post)
        {
            postPanel.Children.Add(new DisplayPost(post, this)
            {
                Margin = new Thickness(10)
            });
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PrevPage);
        }
    }
}
