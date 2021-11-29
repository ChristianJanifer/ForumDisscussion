using API_Forum.ViewModel;
using Client.Base.Controllers;
using Client.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginsController : BaseController<LoginVM, LoginRepository, string>
    {
        private readonly LoginRepository log;
        public LoginsController(LoginRepository repository) : base(repository)
        {
            this.log = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reset()
        {
            return View();
        }

        public IActionResult ErrorLogin()
        {
            return View();
        }

        public JsonResult ResetPassword(LoginVM entity)
        {
            var result = log.ResetPassword(entity);
            return Json(result);
        }

        public async Task<IActionResult> Login(LoginVM login)
        {
            var jwtToken = await log.Login(login);
            var token = jwtToken.Token;
            var role = jwtToken.Roles;
            var id = jwtToken.UserId;

            if (token == null)
            {
                return RedirectToAction("ErrorLogin", "Logins");
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetInt32("UserId", id);

            foreach (var x in role)
            {
                if (x is "Admin")
                {
                    return RedirectToAction("Dashboard", "Admins");
                }
                else
                {
                    return RedirectToAction("LihatDiskusi", "Discussions");
                }
            }

            return RedirectToAction("Profile", "Users");
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}