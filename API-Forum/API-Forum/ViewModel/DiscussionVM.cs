using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.ViewModel
{
    public class DiscussionVM
    {
        public int DisId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateDis { get; set; }
        public string CategoryName { get; set; }
    }
}
