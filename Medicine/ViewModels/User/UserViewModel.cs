using Models.Entities;
using System;

namespace Medicine.ViewModels.User
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        public BodyParameters BodyParameters { get; set; }

        public UserViewModel ConvertFromUser(Models.Entities.User model)
        {
            var userViewModel = new UserViewModel()
            {
                Name = model.Name,
                Surname = model.Surname,
                MiddleName = model.MiddleName,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Role = model.Role,
                BodyParameters = model.BodyParameters
            };
            return userViewModel;
        }
    }
}
