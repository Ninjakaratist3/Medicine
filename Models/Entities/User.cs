using Microsoft.AspNetCore.Identity;
using Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; } 

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public BodyParameters BodyParameters { get; set; }
    }
}
