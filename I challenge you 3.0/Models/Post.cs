﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_challenge_you_3._0.Models
{
    public class Post
    {
        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title{ get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string Description { get; set; }
        public int Reactions { get; set; }
        public Nullable<int> ChallengedPerson { get; set; }

        public Nullable<int> responseTo { get; set; }
    }
}
