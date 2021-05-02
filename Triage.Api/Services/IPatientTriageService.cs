using Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IPatientTriageService
    {
        IEnumerable<PatientTriage> GetTraigeByPatinetId(string patinetId);
    }
}
