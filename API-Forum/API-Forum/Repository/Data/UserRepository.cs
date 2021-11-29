﻿using API_Forum.Context;
using API_Forum.HashingPassword;
using API_Forum.Models;
using API_Forum.ViewModel;
using System;
using System.Collections;
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
					Status = Status.on,
					Account = new Account
					{
						Password = Hashing.HashPassword(registerVM.Password)
					}
				};
				context.Users.Add(userResult);
				context.SaveChanges();

				int checkRole = registerVM.RoleId;
				int roleId = 0;

				if (checkRole == 1)
				{
					roleId += 1;
				}
				else if (checkRole == 2)
				{
					roleId += 2;
				}


				var userRole = new AccountRole
				{
					UserId = userResult.UserId,
					RoleId = 2
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
						   where User.Status == Status.@on
						   select new ProfileVM
						   {
							   UserId = User.UserId,
							   FirstName = User.FirstName,
							   LastName = User.LastName,
							   Gender = (ViewModel.Gender)User.Gender,
							   Phone = User.Phone,
							   BirthDate = User.BirthDate,
							   Email = User.Email
						   });
			var result = profile;
			return result;

		}

		public IEnumerable<ProfileVM> GetAllMember()
		{
			var profile = (from u in context.Users
						   join ac in context.Accounts on u.UserId equals ac.UserId
						   join acr in context.AccountRoles on u.UserId equals acr.UserId
						   where u.Status == Status.@on && acr.RoleId == 2
						   select new ProfileVM
						   {
							   UserId = u.UserId,
							   FirstName = u.FirstName,
							   LastName = u.LastName,
							   Gender = (ViewModel.Gender)u.Gender,
							   Phone = u.Phone,
							   BirthDate = u.BirthDate,
							   Email = u.Email
						   });
			var result = profile;
			return result;

		}

		public Object GetProfile(int Id)
		{
			var profile = (from User in context.Users
						   join Account in context.Accounts on User.UserId equals Account.UserId
						   where User.UserId == Id
						   select new ProfileVM
						   {
							   UserId = User.UserId,
							   FirstName = User.FirstName,
							   LastName = User.LastName,
							   Gender = (ViewModel.Gender)User.Gender,
							   Phone = User.Phone,
							   BirthDate = User.BirthDate,
							   Email = User.Email
						   });
			var result = profile.First();
			return result;
		}

		public string GetFullName(LoginVM loginVM)
		{
			var checkEmail = context.Users.Where(p => p.Email == loginVM.Email).FirstOrDefault();
			var Fullname = checkEmail.FirstName + " " + checkEmail.LastName;
			return Fullname;
		}

		public override int Delete(int id)
		{
			var find = context.Users.Find(id);
			find.Status = Status.off;
			var result = context.SaveChanges();
			return result;
		}

		public int UpdatePassword(LoginVM login)
		{
			var checkEmail = context.Users.Where(p => p.Email == login.Email).FirstOrDefault();
			if (checkEmail == null)
			{
				return 0;
			}
			else
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

		public int GetId(LoginVM login)
		{
			var dataExist = context.Users.Where(fn => fn.Email == login.Email).FirstOrDefault();
			var userId = dataExist.UserId;
			return userId;
		}

		public IEnumerable<DiscussionVM> GetDiscussion()
		{
			var data1 = (from d in context.Discussions
						 join c in context.Categories on d.CategoryId equals c.CategoryId
						 join u in context.Users on d.UserId equals u.UserId
						 where d.Status == Status.@on
						 select new DiscussionVM
						 {
							 DisId = d.DisId,
							 FirstName = u.FirstName,
							 LastName = u.LastName,
							 Title = d.Title,
							 Content = d.Content,
							 DateDis = d.DateDis,
							 CategoryName = c.CategoryName
						 });
			return data1;
		}

		public Object GetDiscussionId(int id)
		{
			var data1 = (from d in context.Discussions
						 join c in context.Categories on d.CategoryId equals c.CategoryId
						 join u in context.Users on d.UserId equals u.UserId
						 where d.Status == Status.@on && d.DisId == id
						 select new DiscussionVM
						 {
							 DisId = d.DisId,
							 FirstName = u.FirstName,
							 LastName = u.LastName,
							 Title = d.Title,
							 Content = d.Content,
							 DateDis = d.DateDis,
							 CategoryName = c.CategoryName,
							 StatusComt = (ViewModel.GenericUriParserOptions)d.StatusComt
						 });
			return data1;
		}

		public Object GetDiscussionByCat(int id)
		{
			var data1 = (from d in context.Discussions
						 join c in context.Categories on d.CategoryId equals c.CategoryId
						 join u in context.Users on d.UserId equals u.UserId
						 where d.Status == Status.@on && d.CategoryId == id
						 select new DiscussionVM
						 {
							 DisId = d.DisId,
							 FirstName = u.FirstName,
							 LastName = u.LastName,
							 Title = d.Title,
							 Content = d.Content,
							 DateDis = d.DateDis,
							 CategoryName = c.CategoryName
						 });
			return data1;
		}

		public Object GetDiscussionByUser(int id)
		{
			var data1 = (from d in context.Discussions
						 join c in context.Categories on d.CategoryId equals c.CategoryId
						 join u in context.Users on d.UserId equals u.UserId
						 where d.Status == Status.@on && d.UserId == id
						 select new DiscussionVM
						 {
							 DisId = d.DisId,
							 FirstName = u.FirstName,
							 LastName = u.LastName,
							 Title = d.Title,
							 Content = d.Content,
							 DateDis = d.DateDis,
							 CategoryName = c.CategoryName,
							 StatusComt = (ViewModel.GenericUriParserOptions)d.StatusComt
						 });
			return data1;
		}

		public IEnumerable<CommentVM> GetComment(int id)
		{
			var data1 = (from u in context.Users
						 join c in context.Comments on u.UserId equals c.UserId
						 where c.DisId == id
						 select new CommentVM
						 {
							 FirstName = u.FirstName,
							 LastName = u.LastName,
							 Content = c.Content,
							 DateCom = c.DateComment
						 });
			return data1;
		}

		public IEnumerable GetReplies()
		{
			var result = from u in context.Users
						 join c in context.Comments on u.UserId equals c.UserId
						 join ac in context.Accounts on u.UserId equals ac.UserId
						 join acr in context.AccountRoles on u.UserId equals acr.UserId
						 where c.Status == Status.@on && acr.RoleId == 2
						 group c by c.DisId into a
						 select new
						 {
							 DisId = a.Key,
							 value = a.Count()
						 };
			return result;
		}

		/*public object GetRepliesId(int id)
		{
			var result = from u in context.Users
						 join c in context.Comments on u.UserId equals c.UserId
						 join ac in context.Accounts on u.UserId equals ac.UserId
						 join acr in context.AccountRoles on u.UserId equals acr.UserId
						 where c.Status == Status.@on && c.DisId == id && acr.RoleId == 2
						 group c by c.DisId into a
						 select new
						 {
							 value = a.Count()
						 };
			return result;
		}*/

		public IEnumerable GetGender()
		{
			var result = from u in context.Users
						 join ac in context.Accounts on u.UserId equals ac.UserId
						 join acr in context.AccountRoles on u.UserId equals acr.UserId
						 where u.Status == Status.@on && acr.RoleId == 2
						 group u by u.Gender into x
						 select new
						 {
							 Gender = (ViewModel.Gender)x.Key,
							 value = x.Count()
						 };
			return result;
		}

		public IEnumerable GetUserDis()
		{
			var result = from u in context.Users
						 join d in context.Discussions on u.UserId equals d.UserId
						 join ac in context.Accounts on u.UserId equals ac.UserId
						 join acr in context.AccountRoles on u.UserId equals acr.UserId
						 where d.Status == Status.@on && acr.RoleId == 2
						 group d by d.UserId into a
						 select new
						 {
							 UserId = a.Key,
							 value = a.Count()
						 };
			return result;
		}

		public IEnumerable GetCatDis()
		{
            var result = from c in context.Categories
                         join d in context.Discussions on c.CategoryId equals d.CategoryId
                         group d by c.CategoryName into x
                         select new
                         {
                             categoryName = x.Key,
                             value = x.Count()
                         };
			return result;
		}
	}
}