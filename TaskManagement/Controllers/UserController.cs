using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagement.BLL.Dtos;
using TaskManagement.BLL.Interfaces;

//namespace TaskManagement.Controllers
namespace TaskManagement.WebAPI.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(UserRegisterDto dto)
        {
            try
            {
                _userService.RegisterUser(dto);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateUser(int id, UserRegisterDto dto)
        {
            try
            {
                _userService.UpdateUser(id, dto);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete]
        //[Route("{id:int}")]
        //public IHttpActionResult DeleteUser(int id)
        //{
        //    try
        //    {
        //        _userService.DeleteUser(id);
        //        return Ok("User deleted successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                var existingUser = _userService.GetUserById(id);
                if (existingUser == null)
                    return NotFound();

                _userService.DeleteUser(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

