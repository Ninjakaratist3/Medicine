using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Medicine.Controllers
{
    [Route("clinics")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private IRepository<Clinic> _clinicRepository;
        private IRepository<Doctor> _doctorRepository;

        public ClinicController(IRepository<Clinic> clinicRepository, IRepository<Doctor> doctorRepository)
        {
            _clinicRepository = clinicRepository;
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public IActionResult GetAllClinics()
        {
            return Ok(_clinicRepository.Query().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var clinic = _clinicRepository.GetById(id);

            if (clinic == null)
            {
                return NotFound();
            }

            return Ok(clinic);
        }

        [HttpPost]
        public IActionResult Create(Clinic clinic)
        {
            if (clinic == null)
            {
                return NotFound();
            }

            _clinicRepository.Add(clinic);
            _clinicRepository.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Clinic newClinic)
        {
            var clinic = _clinicRepository.GetById(id);

            if (clinic == null || newClinic == null)
            {
                return NotFound();
            }

            clinic.Name = newClinic.Name;
            clinic.OpeningHours = newClinic.OpeningHours;
            clinic.SpecialistsNumber = newClinic.SpecialistsNumber;

            _clinicRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var clinic = _clinicRepository.GetById(id);

            if (clinic == null)
            {
                return NotFound();
            }

            DeleteDoctors(id);

            _clinicRepository.Remove(clinic);
            _clinicRepository.SaveChanges();

            return Ok();
        }

        private void DeleteDoctors(long clinicId)
        {
            var doctors = _doctorRepository.Query().Where(d => d.Id == clinicId).ToList();

            foreach (var doctor in doctors)
            {
                _doctorRepository.Remove(doctor);
            }

            _doctorRepository.SaveChanges();
        }
    }
}
