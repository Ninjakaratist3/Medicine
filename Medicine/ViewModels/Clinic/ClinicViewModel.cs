using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.ViewModels.Clinic
{
    public class ClinicViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string OpeningHours { get; set; }

        public int SpecialistsCount { get; set; }
    }
}
