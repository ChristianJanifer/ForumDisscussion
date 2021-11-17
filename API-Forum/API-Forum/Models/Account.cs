﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Models
{
    [Table("Tb_T_Account")]

    public class Account
    {
        [Key]
        public string UserId { get; set; }

        public string Password { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<AccountRole> AccountRoles { get; set; }
    }
}
