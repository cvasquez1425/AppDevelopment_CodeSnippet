using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace PatientData.Models
{
    public static class PatientDb
    {
        internal static MongoCollection<PatientData> Open()
        {
            var client = new MongoClient("mongodb://localhost");  // in order to connect to Mongo I need a MongoClient and I want to connect to a server running here on my machine on local host.
            //var server = client.GetServer();     part of the old API, simply call GetDatabase directly on the client to get an IMongoDatabase and GetCollection on it to get an IMongoCollection
            var db = client.GetDatabase("PatientDb");
            var collection = db.GetCollection<PatientData>("Patients");
            return collection;
        }
    }
}