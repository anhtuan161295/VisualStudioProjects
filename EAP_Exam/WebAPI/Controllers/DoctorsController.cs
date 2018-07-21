using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DoctorsController : ApiController
    {
        DoctorContext db = new DoctorContext();

        public List<Doctor> GetDoctors()
        {
            return db.DoctorList.ToList();
        }

        public Doctor GetDoctorsById(int id)
        {
            var doc = db.DoctorList.Find(id);
            return doc;
        }

        public IHttpActionResult PostDoctor(Doctor newDoctor)
        {
            db.DoctorList.Add(newDoctor);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult DeleteDoctor(int id)
        {
            var doc = db.DoctorList.Find(id);
            if (doc != null)
            {
                db.DoctorList.Remove(doc);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}