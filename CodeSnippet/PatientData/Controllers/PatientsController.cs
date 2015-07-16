using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }
        // you'll know that this Get method will respond to a request that comes into /api/patients and it's an Http Get Request
        public IMongoCollection<Patient> Get()
        {
            return _patients;
        }
    }
}
