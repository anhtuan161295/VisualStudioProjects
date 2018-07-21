using Lab06MVCWebRole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace Lab06MVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        private string url = "http://localhost:3671/Service1.svc/";
        WebClient wc = new WebClient();

        // GET: Home
        public ActionResult Index()
        {
            var model = JsonConvert.DeserializeObjectAsync<IEnumerable<Movie>>(wc.DownloadString(url + "GetMovies")).Result;
            return View(model);
        }

        public ActionResult FindByDirector(string txtDirector)
        {
            var model = JsonConvert.DeserializeObjectAsync<IEnumerable<Movie>>(wc.DownloadString(url + "GetMoviesByDirector/" + txtDirector)).Result;
            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            var model = JsonConvert.DeserializeObjectAsync<Movie>(wc.DownloadString(url + "GetMovieById/" + id)).Result;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Movie));
            dc.WriteObject(ms, newMovie);
            wc.Headers["Content-type"] = "application/json";
            wc.UploadData(url + "PostMovie", "POST", ms.ToArray());
            ModelState.AddModelError("", "Add movie completed");

            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = JsonConvert.DeserializeObjectAsync<Movie>(wc.DownloadString(url + "GetMovieById/" + id)).Result;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Movie editMovie)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Movie));
            dc.WriteObject(ms, editMovie);
            wc.Headers["Content-type"] = "application/json";
            wc.UploadData(url + "PutMovie", "PUT", ms.ToArray());
            ModelState.AddModelError("", "Update movie completed");

            return View(editMovie);
        }

        public ActionResult Delete(int id)
        {
            var model = JsonConvert.DeserializeObjectAsync<Movie>(wc.DownloadString(url + "GetMovieById/" + id)).Result;
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Movie));
            dc.WriteObject(ms, id);
            wc.Headers["Content-type"] = "application/json";
            wc.UploadData(url + "DeleteMovie", "DELETE", ms.ToArray());

            return RedirectToAction("Index");
        }
    }
}