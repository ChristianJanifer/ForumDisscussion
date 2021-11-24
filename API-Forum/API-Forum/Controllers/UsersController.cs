using API_Forum.Controllers.Base;
using API_Forum.Models;
using API_Forum.Repository.Data;
using API_Forum.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_Forum.Controllers
{
    public class UsersController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository user;
        public IConfiguration _configuration;
        public UsersController(UserRepository userRepository, IConfiguration configuration) : base(userRepository)
        {
            this.user = userRepository;
            this._configuration = configuration;
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

        [HttpPut("ResetPassword")]
        public ActionResult ResetPassword(LoginVM login)
        {
            var result = user.UpdatePassword(login);
            if(result == 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Email tidak terdaftar" });
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            var result = user.Login(loginVM);
            if (result == 0)
            {
                var data = new LoginDataVM()
                {
                    Email = loginVM.Email,
                    Roles = user.GetRole(loginVM)
                };
                var claims = new List<Claim>
                {
                new Claim("email", data.Email)
                };
                foreach (var item in data.Roles)
                {
                    claims.Add(new Claim("roles", item.ToString()));
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(30),
                            signingCredentials: signIn
                            );
                var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("TokenSecurity", idtoken.ToString()));
                return Ok(new JWTokenVM { Messages = "Login Berhasil", Token = idtoken, Roles = user.GetRole(loginVM) });
            }
            else if (result == 1)
            {
                return BadRequest(new JWTokenVM { Messages = "Email/Password Salah", Token = null });
            }
            else
            {
                return BadRequest(new JWTokenVM { Messages = "Email/Password Salah", Token = null });
            }
        }

        [HttpGet("GetDiscussion")]
        public ActionResult GetDiscussion()
        {
            var result = user.GetDiscussion();
            return Ok(result);
        }

        [HttpGet("GetComment/{id}")]
        public ActionResult GetComment(int id)
        {
            var result = user.GetComment(id);
            return Ok(result);
        }
    }
}
