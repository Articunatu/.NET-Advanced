using APIUser_Tutorial.Models;
using APIUser_Tutorial.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepo;

        public UsersController(IUserRepository uRepo)
        {
            this._userRepo = uRepo;
        }

        [HttpGet]
        public IActionResult ReadUsers()
        {
            return Ok(_userRepo.ReadAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult ReadSingleUser(int id)
        {
            var U = _userRepo.ReadUser(id);
            if (U != null)
            {
                return Ok(U);
            }

            return NotFound($"User With ID {id} Not Found");
        }

        [HttpPost]
        public IActionResult CreateNewUser(User newUser)
        {
            _userRepo.CreateUser(newUser);
            return Created(HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host + HttpContext.Request.Path +
                "/" + newUser.ID, newUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var userToDelete = _userRepo.ReadUser(id);
            if (userToDelete!= null)
            {
                _userRepo.DeleteUser(userToDelete);
                return Ok();
            }
            return NotFound($"The user with id {id} was not found to be deleted");
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, User userToUpdate)
        {
            var existuser = _userRepo.ReadUser(id);
            if (existuser != null)
            {
                userToUpdate.ID = existuser.ID;
                _userRepo.UpdateUser(userToUpdate);
            }
            return Ok();
        }
    }
}
