using CarRentPro.Data;
using CarRentPro.DTO;
using CarRentPro.Enums;
using CarRentPro.Models;
using CarRentPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentPro.Controllers
{
    
    [RoutePrefix("api/user")]
    public class UserApiController : ApiController
    {

        private UserService userService = new UserService();


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IHttpActionResult Login(LoginDto dto)
        {
            try
            {
                var user = userService.LoginUser(dto.Email, dto.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/UserApi 
        [HttpGet]

        [Route("")]
        [Authorize]

        public IHttpActionResult GetUsers()
        {
            var users = userService.GetUsers();

            return Ok(users);
        }


        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult GetUserByID(int id)
        {
            var user = userService.GetUserByID(id);
            if(user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IHttpActionResult CreateUser(CreateUserDTO dto)
        {
            var user=userService.CreateUser(dto);
            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult UpdateUser(int id, CreateUserDTO dto)
        {
            var user = userService.UpdateUser(id, dto);
            return Ok(user);

        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = userService.DeleteUser(id);
            return Ok(user);
        }


    }
}
