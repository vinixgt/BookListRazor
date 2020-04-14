using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using BookListRazor.Model;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int id { get; set; }
         
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
    }
}