using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace I_challenge_you_3._0.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Status { get; set; }
        public ImageSource Image { get; set; }
    }
}
