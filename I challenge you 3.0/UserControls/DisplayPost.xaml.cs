﻿using I_challenge_you_3._0.Converters;
using I_challenge_you_3._0.DataAccessLayers;
using I_challenge_you_3._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        private bool playingVideo;
        public Post post { get; set; }
        public User postUser { get; set; }
        public User challengedPerson { get; set; }
        public DisplayPost(Post post)
        {
            InitializeComponent();
            DataContext = this;
            this.post = post;
            this.postUser = UserDAL.getUserById(post.IdUser);

            if(post.ChallengedPerson != null)
            {
                challengeFor.Visibility = Visibility.Visible;
                this.challengedPerson = UserDAL.getUserById((int)post.ChallengedPerson);
            }

            LoadContent();
        }

        private void LoadContent()
        {
            if(post.ContentType == "image")
            {
                postImage.Source = ByteImageConverter.ConvertByteArrayToImageSource(this.post.Content);
                postImage.Visibility = contentContainer.Visibility = Visibility.Visible;
            }
            else if(post.ContentType == "video")
            {
                string filePath = "temp/" + string.Format(@"{0}.mp4", "video_post" + post.IdPost);
                if (!File.Exists(filePath))
                {
                    File.WriteAllBytes(filePath, post.Content);
                }
                postVideo.Source = new Uri(filePath, UriKind.Relative);
                postVideo.Visibility = contentContainer.Visibility = Visibility.Visible;
            }
        }

        private void MediaPlayToggle(object sender, MouseButtonEventArgs e)
        {
            if(playingVideo)
            {
                postVideo.Pause();
                playingVideo = false;
            }
            else
            {
                postVideo.Play();
                playingVideo = true;
            }
        }

        private void MediaLoaded(object sender, RoutedEventArgs e)
        {
            postVideo.Pause();
            playingVideo = false;
        }

        private void MediaEnded(object sender, RoutedEventArgs e)
        {
            postVideo.Stop();
            playingVideo = false;
        }
    }
}