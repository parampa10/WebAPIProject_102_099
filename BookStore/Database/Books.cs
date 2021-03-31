using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Books
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string author { get; set; }

    }
}