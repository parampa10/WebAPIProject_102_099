using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {

        }
        public DbSet<Books> Books { get; set; }
    }
}