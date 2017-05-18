using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TechTrader.Models
{
    [Table("Sellers")]
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
