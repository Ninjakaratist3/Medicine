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
    [Route("doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IRepository<Doctor> _doctorRepository;

        public DoctorController(IRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctorRepository.Query().ToList();
        }

        [HttpGet("by-clinic/{clinicId}")]
        public IEnumerable<Doctor> GetDoctorsByClinic(int clinicId)
        {
            return _doctorRepository.Query().Where(d => d.Id == clinicId).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var doctor = _doctorRepository.GetById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorRepository.Add(doctor);
            _doctorRepository.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Doctor newDoctor)
        {
            var doctor = _doctorRepository.GetById(id);

            if (doctor == null || newDoctor == null)
            {
                return NotFound();
            }

            doctor.Name = newDoctor.Name;
            doctor.Location = newDoctor.Location;
            doctor.Price = newDoctor.Price;
            doctor.Rating = newDoctor.Rating;
            doctor.Specialization = newDoctor.Specialization;

            _doctorRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = _doctorRepository.GetById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _doctorRepository.Remove(doctor);
            _doctorRepository.SaveChanges();

            return Ok();
        }
    }
}
