using API_Forum.Controllers.Base;
using API_Forum.Models;
using API_Forum.Repository.Data;
using API_Forum.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API_Forum.Controllers
{
    public class UsersController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository user;
        public UsersController(UserRepository userRepository) : base(userRepository)
        {
            this.user = userRepository;
        }

        [Route("Register")]
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            var result = user.Register(registerVM);
            if (result == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Email sudah terdaftar" });
            }
            else if (result == 3)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Nomor telepon sudah terdaftar" });
            }
            else
            {
                return Ok(new { HttpStatusCode.OK });
            }

        }

        [HttpGet("Profile")]
        public ActionResult GetProfile()
        {
            
                var result = user.GetProfileAll();
                return Ok(result);
            
        }

        [HttpGet("Profile/{Id}")]
        public ActionResult GetProfile(int Id)
        {
                var result = user.GetProfile(Id);
                return Ok(result);
        }
    }
}
