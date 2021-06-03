using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository;
using Medicine.ViewModels.Clinic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Medicine.Controllers
{
    [Route("clinics")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IRepository<Clinic> _clinicRepository;
        private readonly IRepository<Doctor> _doctorRepository;

        public ClinicController(IRepository<Clinic> clinicRepository, IRepository<Doctor> doctorRepository)
        {
            _clinicRepository = clinicRepository;
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public IActionResult GetAllClinics()
        {
            var clinics = _clinicRepository.Query()
                .Select(c => new ClinicViewModel() { 
                    Name = c.Name,
                    Address = c.Address,
                    OpeningHours = c.OpeningHours,
                    SpecialistsCount = c.SpecialistsCount
                })
                .ToList();

            return Ok(clinics);
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
        public IActionResult Create(ClinicForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var clinic = new Clinic()
            {
                Name = model.Name,
                Address = model.Address,
                OpeningHours = model.OpeningHours,
                SpecialistsCount = model.SpecialistsCount
            };

            _clinicRepository.Add(clinic);
            _clinicRepository.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, ClinicForm model)
        {
            var clinic = _clinicRepository.GetById(id);

            if (clinic == null || model == null)
            {
                return BadRequest();
            }

            clinic.Name = model.Name;
            clinic.OpeningHours = model.OpeningHours;
            clinic.SpecialistsCount = model.SpecialistsCount;

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
