using Medicine.ViewModels.Doctor;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Services
{
    public interface IDoctorService
    {
        public List<DoctorViewModel> GetAll();

        public DoctorViewModel Get(long id);

        public DoctorViewModel GetByClinicId(long clinicId);

        public void Create(DoctorForm model);

        public void Update(long id, DoctorForm model);

        public void Delete(long id);
    }
}
