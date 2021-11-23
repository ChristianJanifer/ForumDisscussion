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
    public class RegistersController : BaseController<RegisterVM, RegisterRepository, string>
    {
        private readonly RegisterRepository register;
        public RegistersController(RegisterRepository repository) : base(repository)
        {
            this.register = repository;
        }

        /*[Authorize]*/
        public IActionResult Index()
        {
            return View();
        }

        /*public async Task<JsonResult> GetProfile()
        {
            var result = await employee.GetProfile();
            return Json(result);
        }*/

        /*public async Task<JsonResult> Profile(string id)
        {
            var result = await employee.Profile(id);
            return Json(result);
        }*/

        public JsonResult Register(RegisterVM entity)
        {
            var result = register.Register(entity);
            return Json(result);
        }

        /*[ValidateAntiForgeryToken]*/
        /*[HttpPost("Login/")]*/
        /*public async Task<IActionResult> Login(LoginVM login)
        {
            var jwtToken = await employee.Login(login);
            var token = jwtToken.Token;

            if (token == null)
            {

                return RedirectToAction("Index", "Home");
            }

            HttpContext.Session.SetString("JWToken", token);

            return RedirectToAction("Dashboard", "Home");
        }*/

        /*[Authorize]*/
        /* [HttpGet("Logout")]*/
        /*public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }*/
    }
}
