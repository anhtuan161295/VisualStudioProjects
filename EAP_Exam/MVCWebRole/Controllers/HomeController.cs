using MVCWebRole.Models;
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

namespace MVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        // Web API
        private string url = "http://localhost:2537/api/Employees/";

        HttpClient httpClient = new HttpClient();

        // GET: Home
        public ActionResult Index()
        {
            // Web API
            var model = JsonConvert.DeserializeObjectAsync<IEnumerable<Employees>>(httpClient.GetStringAsync(url).Result).Result;

            return View(model);
        }

        //public ActionResult Details(int id)
        //{
        //    // Web API
        //    var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Employees>().Result;

        //    return View(model);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees newEmployee)
        {
            // Web API
            var model = httpClient.PostAsJsonAsync(url, newEmployee).Result;
            if (model.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Add employee completed");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            // Web API
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Employees>().Result;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Employees editEmployee)
        {
            var model = httpClient.PutAsJsonAsync(url, editEmployee).Result;
            if (model.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Update employee completed");
            }

            return View(editEmployee);
        }

        //public ActionResult DeleteDoctor(int id)
        //{
        //    // Web API
        //    var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Doctor>().Result;

        //    // WCF Rest
        //    //var model = JsonConvert.DeserializeObjectAsync<Doctor>(wc.DownloadString(url + "GetDoctorsById/" + id)).Result;
        //    return View(model);
        //}

        //[HttpPost, ActionName("DeleteDoctor")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    // Web API
        //    var model = httpClient.DeleteAsync(url + id).Result;
        //    if (model.IsSuccessStatusCode)
        //    {
        //    }

        //    // WCF Rest
        //    //MemoryStream ms = new MemoryStream();
        //    //DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Doctor));
        //    //dc.WriteObject(ms, id);
        //    //wc.Headers["Content-type"] = "application/json";
        //    //wc.UploadData(url + "DeleteDoctor", "DELETE", ms.ToArray());

        //    return RedirectToAction("Index");
        //}
    }
}