using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.ViewModels.Doctor
{
    public class DoctorViewModel
    {
        public string Name { get; set; }

        public string Specialization { get; set; }

        public int Rating { get; set; }

        public int Price { get; set; }

        public string Location { get; set; }

        public Models.Entities.Clinic Clinic { get; set; }
    }
}
