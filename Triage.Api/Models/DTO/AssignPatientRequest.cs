using System.Collections.Generic;

namespace Models.DTO
{
    public class AssignPatientRequest
    {
        public string UserId { get; set; }
        public IEnumerable<string> PatientIds { get; set; }
    }
}
