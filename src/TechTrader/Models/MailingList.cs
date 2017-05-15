using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechTrader.Models
{
    [Table ("MailingLists")]
    public class MailingList
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
