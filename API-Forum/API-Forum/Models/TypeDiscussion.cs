using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Models
{
    [Table("Tb_M_TypeDiscussion")]

    public class TypeDiscussion
    {
        [Key]
        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}
