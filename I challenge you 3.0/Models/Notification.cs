using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_challenge_you_3._0.Models
{
    public class Notification
    {
        public int IdNotification { get; set; }
        public int IdUser { get; set; }
        public string Type { get; set; }
        public Nullable<int> IdPost { get; set; }
        public Nullable<int> MessageFrom { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Seen { get; set; }
    }
}
