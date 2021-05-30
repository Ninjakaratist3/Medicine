using Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class Clinic : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string OpeningHours { get; set; }

        public int SpecialistsNumber { get; set; }
    }
}
