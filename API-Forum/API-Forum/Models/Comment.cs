using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Models
{
    [Table("Tb_T_Comment")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime DateComment { get; set; }
        public User User { get; set; }
        public Discussion Discussion { get; set; }
    }
}
