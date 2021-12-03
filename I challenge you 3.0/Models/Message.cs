using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_challenge_you_3._0.Models
{
    public class Message
    {
        public int IdMessage { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
