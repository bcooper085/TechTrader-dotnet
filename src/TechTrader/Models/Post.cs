using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTrader.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public Post() { }
    }
}
