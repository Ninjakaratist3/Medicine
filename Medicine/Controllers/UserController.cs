using DBRepository;
using Medicine.ViewModels;
using Medicine.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userEmail = HttpContext.User.Identity.Name;

            if (userEmail == null)
            {
                return Unauthorized();
            }

            var user = _userRepository.Query()
                .Include(u => u.Role)
                .Include(u => u.BodyParameters)
                .Where(u => u.Email == userEmail)
                .FirstOrDefault();

            if (user == null)
            {
                return Forbid();    
            }

            var userViewModel = new UserViewModel().ConvertFromUser(user); 

            return Ok(userViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, UserForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _userRepository.Query()
                .Include(u => u.Role)
                .Include(u => u.BodyParameters)
                .Where(u => u.Id == id)
                .FirstOrDefault();

            if (user == null)
            {
                return BadRequest();
            }

            ConvertUserFormToUser(model, user);
            _userRepository.SaveChanges();

            return Ok();
        }

        private User ConvertUserFormToUser(UserForm userForm, User user)
        {
            user.Name = userForm.Name;
            user.Surname = userForm.Surname;
            user.MiddleName = userForm.MiddleName;
            user.DateOfBirth = userForm.DateOfBirth;
            user.Email = userForm.Email;
            user.PhoneNumber = userForm.PhoneNumber;
            user.Role = userForm.Role;
            user.BodyParameters = userForm.BodyParameters;

            return user;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _userRepository.Query().Where(u => u.Id == id).FirstOrDefault();

            if (user == null)
            {
                return BadRequest();
            }

            _userRepository.Remove(user);
            _userRepository.SaveChanges();

            return Ok();
        }
    }
}
