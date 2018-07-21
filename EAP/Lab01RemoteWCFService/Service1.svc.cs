using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab01RemoteWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Patient> displayAll()
        {
            return PatientContext.pList.ToList();
            //throw new NotImplementedException();
        }

        public void createPatient(Patient newPatient)
        {
            PatientContext.pList.Add(newPatient);
            //throw new NotImplementedException();
        }

        public Patient detailsPatient(int id)
        {
            return PatientContext.pList.SingleOrDefault(u => u.PatientId.Equals(id));
            //throw new NotImplementedException();
        }

        public void editPatient(Patient newPatient)
        {
            var pat = PatientContext.pList.SingleOrDefault(u => u.PatientId.Equals(newPatient.PatientId));
            if (pat != null)
            {
                pat.PatientName = newPatient.PatientName;
                pat.Age = newPatient.Age;
                pat.Address = newPatient.Address;
                pat.Dated = newPatient.Dated;
                pat.Hour = newPatient.Hour;
            }
            //throw new NotImplementedException();
        }

        public void deletePatient(int id)
        {
            var pat = PatientContext.pList.SingleOrDefault(u => u.PatientId.Equals(id));
            if (pat != null)
            {
                PatientContext.pList.Remove(pat);
            }
            //throw new NotImplementedException();
        }
    }
}