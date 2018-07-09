using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoryMarks.Models;

namespace RoryMarks.Models
{
    public class RoryMarksContext : DbContext
    {
        public RoryMarksContext (DbContextOptions<RoryMarksContext> options)
            : base(options)
        {
        }

        public DbSet<RoryMarks.Models.Topic> Topic { get; set; }

        public DbSet<RoryMarks.Models.Bookmarks> Bookmarks { get; set; }
    }
}
