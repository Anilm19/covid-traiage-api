using Models.Entity;
using MongoDB.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetByICMRID(string icmrid);
    }
}
