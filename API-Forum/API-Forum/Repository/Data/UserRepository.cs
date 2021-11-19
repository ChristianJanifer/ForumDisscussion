using API_Forum.Context;
using API_Forum.HashingPassword;
using API_Forum.Models;
using API_Forum.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Forum.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        private readonly MyContext context;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }

		public int Register(RegisterVM registerVM)
		{
			var checkEmail = context.Users.Where(p => p.Email == registerVM.Email).FirstOrDefault();
			var checkPhone = context.Users.Where(p => p.Phone == registerVM.Phone).FirstOrDefault();
			if (checkEmail != null)
			{
				return 2;
			}
			else if (checkPhone != null)
			{
				return 3;
			}
			else
			{
				var userResult = new User
				{
					FirstName = registerVM.FirstName,
					LastName = registerVM.LastName,
					Gender = (Models.Gender)registerVM.Gender,
					BirthDate = registerVM.BirthDate,
					Phone = registerVM.Phone,
					Email = registerVM.Email,
					Account = new Account
					{
						Password = Hashing.HashPassword(registerVM.Password)
					}
				};
				context.Users.Add(userResult);
				context.SaveChanges();

				int checkRole = registerVM.RoleId;
				int roleId = 0;

				if(checkRole == 1)
                {
					roleId += 1;
				}
				else if(checkRole == 2)
                {
					roleId += 2;
				}


				var userRole = new AccountRole
				{
					UserId = userResult.UserId,
					RoleId = roleId
				};

				context.AccountRoles.Add(userRole);
				var result = context.SaveChanges();
				return result;
			}
		}
    }
}
