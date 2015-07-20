using Pacientes.Entities;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
    public class PacientesController : ApiController
    {

        IEnumerable<Paciente> _paciente;

        private PacienteDb db = new PacienteDb();

        public PacientesController()
        {
            _paciente = db.Pacientes.ToList();
        }

        // you'll know that this Get method will respond to a request that comes into /api/patientes and it's an Http Get Request
        public IEnumerable<Paciente> Get()
        {
            return _paciente;
        }
    }
}
