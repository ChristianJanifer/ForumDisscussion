using API_Forum.Models;
using API_Forum.ViewModel;
using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class UsersController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository user;
        public UsersController(UserRepository repository) : base(repository)
        {
            this.user = repository;
        }

        /*[Authorize]*/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ProfileMember()
        {
            return View();
        }

        public IActionResult ProfileAdmin()
        {
            return View();
        }

        public async Task<JsonResult> GetProfile()
        {
            var result = await user.GetProfile();
            return Json(result);
        }

        public async Task<JsonResult> ProfileUser(int id)
        {
            var result = await user.Profile(id);
            return Json(result);
        }

        public async Task<JsonResult> GetAllMember()
        {
            var result = await user.GetAllMember();
            return Json(result);
        }

        public JsonResult DeleteUser(int id)
        {
            var result = user.DeleteUser(id);
            return Json(result);
        }

        public async Task<JsonResult> GetLanding()
        {
            var result = await user.GetLanding();
            return Json(result);
        }

        public async Task<JsonResult> GetDiscussionbyId(int id)
        {
            var result = await user.GetDiscussionbyId(id);
            return Json(result);
        }

        public async Task<JsonResult> GetReplybyId(int id)
        {
            var result = await user.GetReplybyId(id);
            return Json(result);
        }

        public async Task<JsonResult> GetDiscussionByCat(int id)
        {
            var result = await user.GetDiscussionByCat(id);
            return Json(result);
        }
    }
}
