using API_Forum.Context;
using API_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
