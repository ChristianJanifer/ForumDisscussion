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

       /* public override int Insert(DiscussionVM entity)
        {
            var disResult = new Discussion
            {
                Title = entity.Title,
                Content = entity.Content,
                DateDis = entity.DateDis,
                StatusComt = (Models.GenericUriParserOptions)entity.StatusComt,
                UserId =
            };

        }*/
    }
}
