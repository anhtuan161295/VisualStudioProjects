using LabFinalMVCWebRole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace LabFinalMVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        // Web API
        private string url = "http://localhost:3352/api/Doctors/";

        HttpClient httpClient = new HttpClient();

        // WCF Rest
        //private string url = "http://localhost:2362/Service1.svc/";

        //WebClient wc = new WebClient();

        // GET: Home
        public ActionResult Index()
        {
            // Web API
            var model = JsonConvert.DeserializeObjectAsync<IEnumerable<Doctor>>(httpClient.GetStringAsync(url).Result).Result;

            // WCF Rest
            //var model = JsonConvert.DeserializeObjectAsync<List<Doctor>>(wc.DownloadString(url + "GetDoctors")).Result;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            // Web API
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Doctor>().Result;

            // WCF Rest
            //var model = JsonConvert.DeserializeObjectAsync<Doctor>(wc.DownloadString(url + "GetDoctorsById/" + id)).Result;
            return View(model);
        }

        public ActionResult CreateDoctor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor newDoctor)
        {
            // Web API
            var model = httpClient.PostAsJsonAsync(url, newDoctor).Result;
            if (model.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Add doctor completed");
            }

            // WCF Rest
            //MemoryStream ms = new MemoryStream();
            //DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Doctor));
            //dc.WriteObject(ms, newDoctor);
            //wc.Headers["Content-type"] = "application/json";
            //wc.UploadData(url + "PostDoctor", "POST", ms.ToArray());
            //ModelState.AddModelError("", "Add doctor completed");

            return View();
        }

        //public ActionResult Edit(int id)
        //{
        //    // Web API
        //    //var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Doctor>().Result;

        //    // WCF Rest
        //    //var model = JsonConvert.DeserializeObjectAsync<Doctor>(wc.DownloadString(url + "GetDoctorsById/" + id)).Result;
        //    //return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(Doctor editDoctor)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Doctor));
        //    dc.WriteObject(ms, editDoctor);
        //    wc.Headers["Content-type"] = "application/json";
        //    wc.UploadData(url + "PutMovie", "PUT", ms.ToArray());
        //    ModelState.AddModelError("", "Update movie completed");

        //    return View(editDoctor);
        //}

        public ActionResult DeleteDoctor(int id)
        {
            // Web API
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Doctor>().Result;

            // WCF Rest
            //var model = JsonConvert.DeserializeObjectAsync<Doctor>(wc.DownloadString(url + "GetDoctorsById/" + id)).Result;
            return View(model);
        }

        [HttpPost, ActionName("DeleteDoctor")]
        public ActionResult DeleteConfirmed(int id)
        {
            // Web API
            var model = httpClient.DeleteAsync(url + id).Result;
            if (model.IsSuccessStatusCode)
            {
            }

            // WCF Rest
            //MemoryStream ms = new MemoryStream();
            //DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Doctor));
            //dc.WriteObject(ms, id);
            //wc.Headers["Content-type"] = "application/json";
            //wc.UploadData(url + "DeleteDoctor", "DELETE", ms.ToArray());

            return RedirectToAction("Index");
        }
    }
}