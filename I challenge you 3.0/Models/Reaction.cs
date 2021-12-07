using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_challenge_you_3._0.Models
{
    public class Reaction
    {
        public int IdUser { get; set; }
        public int IdPost { get; set; }
        public string ReactionType { get; set; }
    }
}
