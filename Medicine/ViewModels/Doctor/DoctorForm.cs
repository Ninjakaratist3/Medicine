using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.ViewModels.Doctor
{
    public class DoctorForm
    {
        [Required]
        public string Name { get; set; }

        public string Specialization { get; set; }

        public int Rating { get; set; }

        public int Price { get; set; }

        public string Location { get; set; }

        public long ClinicId { get; set; }
    }
}
