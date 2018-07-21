using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01RemoteWCFService
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int Hour { get; set; }
        public string Dated { get; set; }
    }

    public class PatientContext
    {
        public static List<Patient> pList = new List<Patient>()
        {
            new Patient() {PatientId = 0, PatientName = "Long",Age = 22,Address = "Tan Binh,VN",Hour = 16,Dated = "23/07/2016"},
            new Patient() {PatientId = 1, PatientName = "An",Age = 22,Address = "Tan Binh,VN",Hour = 16,Dated = "23/07/2016"},
            new Patient() {PatientId = 2, PatientName = "Chi",Age = 22,Address = "Tan Binh,VN",Hour = 16,Dated = "23/07/2016"},
            new Patient() {PatientId = 3, PatientName = "Nghi",Age = 22,Address = "Tan Binh,VN",Hour = 16,Dated = "23/07/2016"}
        };
    }
}