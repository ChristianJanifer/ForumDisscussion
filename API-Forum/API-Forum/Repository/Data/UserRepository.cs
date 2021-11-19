﻿using API_Forum.Context;
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
	}
}