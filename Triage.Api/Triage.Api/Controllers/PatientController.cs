using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using Services;
using Triage.Api.Controllers.Base;

namespace Triage.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController : DataApiBaseController<Patient, IEntityService<Patient>>
    {
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger,
                IEntityService<Patient> service,
                IPatientService patientService) : base(service, logger)
        {
            _patientService = patientService;
        }
        [HttpGet("getbyicmrid/{icmrid}")]
        public virtual IActionResult GetByEmail(string icmrid)
        {
            return Ok(_patientService.GetPatinetByICMRID(icmrid));
        }
        [HttpGet("getpatientdetails/{id}")]
        public virtual IActionResult GetPatientDetails(string id)
        {
            return Ok(_patientService.GetPatientDetailsById(id));
        }
    }
}
