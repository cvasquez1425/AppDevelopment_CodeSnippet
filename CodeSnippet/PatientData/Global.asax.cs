using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using MongoDB.Driver;
using MongoDB.Bson;
using PatientData.Models;
using System.Threading.Tasks;

namespace PatientData
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // to see the db with some initial data when the application starts up
            //await MongoConfig.Seed();
        }

        public async Task<Patient> Seed()
        {
            var patients = PatientDb.Open();

            // I can take a Mongo Collection, turn it into something that is IQueryable, and then I can Linq statements.
            //if (!patients.      AsQueryable().Any(p => p.Name == "Scott"))
            //{

            //} 


            var data = new List<Patient>()
            {
                new Patient { Name = "Scott",
                              Ailments    = new List<Ailment>() { new Ailment {Name = "Crazy" }},
                              Medications = new List<Medication> { new Medication { Name = "Traquilizer", Doses = 2 }}
                            },
                new Patient { Name = "Joy",
                              Ailments    = new List<Ailment>() { new Ailment {Name = "Loco"}},
                              Medications = new List<Medication> { new Medication {Name = "Equizofrenia", Doses = 3}}
                            },
                new Patient { Name = "Sarah",
                              Ailments    = new List<Ailment>() { new Ailment {Name = "Cucu"}},
                              Medications = new List<Medication> { new Medication {Name = "Crazy Loco", Doses = 4}}
                            }
            };

            await patients.InsertOneAsync(data); 
        }
    }
}
