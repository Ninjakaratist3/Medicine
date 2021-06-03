﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Medicine.ViewModels.Account
{
    public class RegisterForm
    {
        [Required(ErrorMessage = "Укажите ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        public Models.Entities.User ConvertToUser()
        {
            var passwordHasher = new PasswordHasher<Models.Entities.User>();

            var user = new Models.Entities.User();
            user.Email = this.Email;
            user.Name = this.Name;
            user.Password = passwordHasher.HashPassword(user, this.Password);

            return user;
        }
    }
}
