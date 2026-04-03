using CarRentPro.DTO;
using CarRentPro.Helper;
using CarRentPro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;




namespace CarRentPro.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private UserRepository userRepo = new UserRepository();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginDto dto)
        {
            
            
            var user = userRepo.ValidateUser(dto.Email, dto.Password);
            if (user == null)
                return Unauthorized();
            var token = JwtTokenHelper.GenerateToken(user.Id, user.Email, user.Role.ToString());

            return Ok(new
            {
                Token = token,
                ExpiresIn = 7200 // 2 hours in seconds
            });

        }
    }
}
