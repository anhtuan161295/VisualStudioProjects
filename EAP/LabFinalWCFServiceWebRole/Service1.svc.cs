using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LabFinalWCFServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DoctorContext db = new DoctorContext();

        public List<Doctor> GetDoctors()
        {
            return db.DoctorList.ToList();
        }

        public Doctor GetDoctorsById(string id)
        {
            var doc = db.DoctorList.Find(int.Parse(id));
            return doc;
        }

        public void PostDoctor(Doctor newDoctor)
        {
            db.DoctorList.Add(newDoctor);
            db.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doc = db.DoctorList.Find(id);
            if (doc != null)
            {
                db.DoctorList.Remove(doc);
                db.SaveChanges();
            }
        }
    }
}