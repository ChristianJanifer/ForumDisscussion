using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Models
{
    [Table("Tb_T_Discussion")]
    public class Discussion
    {
        [Key]
        public int DisId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateDis { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
