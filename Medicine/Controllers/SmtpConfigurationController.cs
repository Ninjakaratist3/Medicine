using EmailSender.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Configurations;

namespace Medicine.Controllers
{
    [Route("smtp-configuration")]
    [ApiController]
    public class SmtpConfigurationController : ControllerBase
    {
        private readonly ISmtpConfigurationService _smtpConfigurationService;

        public SmtpConfigurationController(ISmtpConfigurationService smtpConfigurationService)
        {
            _smtpConfigurationService = smtpConfigurationService;
        }

        [HttpPut]
        public IActionResult Update(SmtpConfiguration model)
        {
            _smtpConfigurationService.UpdateConfiguration(model);

            return Ok();
        }
    }
}
