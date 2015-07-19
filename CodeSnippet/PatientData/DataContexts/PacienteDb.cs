using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientData.Models
{
    public class PacienteDb : DbContext
    {
        public PacienteDb()
               :base("DefaultConnection")
        {

        }

    }
}