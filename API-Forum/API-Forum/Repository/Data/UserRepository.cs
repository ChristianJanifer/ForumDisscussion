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

		public IEnumerable<ProfileVM> GetProfileAll()
		{
			var profile = (from User in context.Users
						   join Account in context.Accounts on User.UserId equals Account.UserId
						   join acr in context.AccountRoles on User.UserId equals acr.UserId
						   join r in context.Roles on acr.RoleId equals r.RoleId
						   select new ProfileVM
						   {
							   UserId = User.UserId,
							   FirstName = User.FirstName,
							   LastName = User.LastName,
							   Gender = (ViewModel.Gender)User.Gender,
							   Phone = User.Phone,
							   BirthDate = User.BirthDate,
							   Email = User.Email,
							   RoleId = r.RoleId
						   });
			return profile.ToList();

		}

		public Object GetProfile(int Id)
		{
			var profile = (from User in context.Users
						   join Account in context.Accounts on User.UserId equals Account.UserId
						   join acr in context.AccountRoles on User.UserId equals acr.UserId
						   join r in context.Roles on acr.RoleId equals r.RoleId
						   where User.UserId == Id
						   select new ProfileVM
						   {
							   UserId = User.UserId,
							   FirstName = User.FirstName,
							   LastName = User.LastName,
							   Gender = (ViewModel.Gender)User.Gender,
							   Phone = User.Phone,
							   BirthDate = User.BirthDate,
							   Email = User.Email,
							   RoleId = r.RoleId
						   });
			var result = profile.First();
			return result;

		}

		public override int Delete(int id)
		{
			var findStatus = (from u in context.Users
							  join d in context.Discussions on u.UserId equals d.UserId
							  join c in context.Comments on d.DisId equals c.DisId
							  where u.UserId == id
							  select new
							  {
								  User = u,
								  Dis = d,
								  Com = c
							  }).ToList();
			foreach (var x in findStatus)
			{
				x.User.Status = Status.off;
				x.Dis.Status = Status.off;
				x.Com.Status = Status.off;
			}
			var result = context.SaveChanges();
			return result;
		}

		public int UpdatePassword(LoginVM login)
		{
			var findUserPassword = (from u in context.Users
									join a in context.Accounts on u.UserId equals a.UserId
									where u.Email == login.Email
									select new
									{
										User = a
									});
			foreach (var x in findUserPassword)
			{
				x.User.Password = Hashing.HashPassword(login.Password);
			}
			var result = context.SaveChanges();
			return result;
		}

		public int Login(LoginVM login)
		{
			var checkEmail = context.Users.Where(p => p.Email == login.Email).FirstOrDefault();
			if (checkEmail == null)
			{
				return 1;
			}
			else
			{
				var dataLogin = checkEmail.UserId;
				var dataPassword = context.Accounts.Find(dataLogin).Password;
				var verify = Hashing.ValidatePassword(login.Password, dataPassword);
				if (verify)
				{
					return 0;
				}
				else
				{
					return 2;
				}
			}
		}

		public string[] GetRole(LoginVM loginVM)
		{
			var dataExist = context.Users.Where(fn => fn.Email == loginVM.Email).FirstOrDefault();
			var userId = dataExist.UserId;
			var userRole = context.AccountRoles.Where(fn => fn.UserId == userId).ToList();
			List<string> result = new List<string>();
			foreach (var item in userRole)
			{
				result.Add(context.Roles.Where(fn => fn.RoleId == item.RoleId).First().RoleName);
			}

			return result.ToArray();
		}
	}
}
