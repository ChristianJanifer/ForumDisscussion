using API_Forum.Context;
using API_Forum.Models;
using API_Forum.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Repository.Data
{
    public class DiscussionRepository : GeneralRepository<MyContext, Discussion, int>
    {
        private readonly MyContext context;
        public DiscussionRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }

        public IEnumerable<Discussion> GetAll()
        {
            var data = context.Discussions.Where(p => p.Status == Status.on).ToList();
            return data;
        }
    }
}
