using DBRepository;
using Medicine.ViewModels.Doctor;
using Models.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Medicine.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _doctorRepository;
        private readonly IRepository<Clinic> _clinicRepository;

        public DoctorService(IRepository<Doctor> doctorRepository, IRepository<Clinic> clinicRepository)
        {
            _doctorRepository = doctorRepository;
            _clinicRepository = clinicRepository;
        }

        public List<DoctorViewModel> GetAll()
        {
            var doctors = _doctorRepository.Query()
                .Select(x => new DoctorViewModel()
                {
                    Name = x.Name,
                    Specialization = x.Specialization,
                    Rating = x.Rating,
                    Price = x.Price,
                    Location = x.Location,
                    Clinic = x.Clinic
                })
                .ToList();

            if (doctors == null)
            {
                throw new NullReferenceException();
            }

            return doctors;
        }

        public DoctorViewModel Get(long id)
        {
            var doctor = _doctorRepository.Query()
                .Select(x => new DoctorViewModel()
                {
                    Name = x.Name,
                    Specialization = x.Specialization,
                    Rating = x.Rating,
                    Price = x.Price,
                    Location = x.Location,
                    Clinic = x.Clinic
                })
                .FirstOrDefault();

            if (doctor == null)
            {
                throw new NullReferenceException();
            }

            return doctor;
        }

        public DoctorViewModel GetByClinicId(long clinicId)
        {
            var doctor = _doctorRepository.Query()
                .Where(d => d.Clinic.Id == clinicId)
                .Select(x => new DoctorViewModel()
                {
                    Name = x.Name,
                    Specialization = x.Specialization,
                    Rating = x.Rating,
                    Price = x.Price,
                    Location = x.Location,
                    Clinic = x.Clinic
                })
                .FirstOrDefault();

            if (doctor == null)
            {
                throw new NullReferenceException();
            }

            return doctor;
        }

        public void Create(DoctorForm model)
        {
            var doctor = new Doctor()
            {
                Name = model.Name,
                Specialization = model.Specialization,
                Rating = model.Rating,
                Price = model.Price,
                Location = model.Location,
                Clinic = _clinicRepository.GetById(model.ClinicId)
            };

            _doctorRepository.Add(doctor);
            _doctorRepository.SaveChanges();
        }

        public void Update(long id, DoctorForm model)
        {
            var doctor = _doctorRepository.GetById(id);

            if (doctor == null)
            {
                throw new NullReferenceException();
            }

            doctor.Name = model.Name;
            doctor.Specialization = model.Specialization;
            doctor.Rating = model.Rating;
            doctor.Price = model.Price;
            doctor.Location = model.Location;
            doctor.Clinic = _clinicRepository.GetById(model.ClinicId);

            _doctorRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            var doctor = _doctorRepository.GetById(id);

            if (doctor == null)
            {
                throw new NullReferenceException();
            }

            _doctorRepository.Remove(doctor);
            _doctorRepository.SaveChanges();
        }
    }
}
