using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rorymarks.Models
{
    public class Bookmarks
    {
        public int BookmarkID { get; set; }
        public string BookmarkAddress { get; set; }
        public int TopicID { get; set; }

        public virtual Topics Topics { get; set; }
    }
}