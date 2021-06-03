using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository;
using Medicine.Services;
using Medicine.ViewModels.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Medicine.Controllers
{
    [Route("doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var doctors = _doctorService.GetAll();

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var doctor = _doctorService.Get(id);

            return Ok(doctor);
        }

        [HttpGet("by-clinic/{clinicId}")]
        public IActionResult GetByClinicId(int clinicId)
        {
            var doctorsByClinic = _doctorService.GetByClinicId(clinicId);

            return Ok(doctorsByClinic);
        }

        [HttpPost]
        public IActionResult Create(DoctorForm model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _doctorService.Create(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, DoctorForm model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _doctorService.Update(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _doctorService.Delete(id);

            return Ok();
        }
    }
}
