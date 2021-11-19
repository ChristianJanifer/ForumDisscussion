using API_Forum.Context;
using API_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Repository.Data
{
    public class DiscussionRepository : GeneralRepository<MyContext, Discussion, int>
    {
        public DiscussionRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
