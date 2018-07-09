using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rorymarks.Models
{
    public class Topics
    {
        public int TopicID { get; set; }
        public string TopicTitle { get; set; }

        public virtual ICollection<Bookmarks> Bookmarks { get; set; }
    }
}