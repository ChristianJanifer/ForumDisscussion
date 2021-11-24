using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.ViewModel
{
    public class ReplyVM
    {
        public string Content { get; set; }

        public DateTime DateComment { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
