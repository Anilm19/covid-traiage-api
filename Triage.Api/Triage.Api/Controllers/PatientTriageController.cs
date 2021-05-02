using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity;
using Services;
using Triage.Api.Controllers.Base;

namespace Triage.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientTriageController : DataApiBaseController<PatientTriage, IEntityService<PatientTriage>>
    {
        private readonly IPatientTriageService _patientTriageService;

        public PatientTriageController(ILogger<PatientTriageController> logger,
                IEntityService<PatientTriage> service,
                IPatientTriageService patientTriageService) : base(service, logger)
        {
            _patientTriageService = patientTriageService;
        }
        [HttpGet("getbypatientid/{patientId}")]
        public virtual IActionResult GetTraigeByPatinetId(string patientId)
        {
            return Ok(_patientTriageService.GetTraigeByPatinetId(patientId));
        }
    }
}
