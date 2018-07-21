using Lab02WebClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab02WebClient.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private string url = "http://localhost:3343/api/News/"; // Cuối url phải có dấu /

        // GET: Home
        public ActionResult Index()
        {
            //var model = JsonConvert.DeserializeObjectAsync<IEnumerable<News>>(httpClient.GetStringAsync(url).Result).Result;
            var model1 =
                Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<IEnumerable<News>>(httpClient.GetStringAsync(url).Result)).Result;
            return View(model1);
        }

        public ActionResult Details(int id)
        {
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<News>().Result;
            //var model = JsonConvert.DeserializeObjectAsync<IEnumerable<News>>(httpClient.GetStringAsync(url).Result).Result;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(News news, HttpPostedFileBase file)
        {
            if (file != null)
            {
                news.Photo = "/Images/" + Path.GetFileName(file.FileName);
            }
            else if (file == null)
            {
                //do nothing
            }
            var model = httpClient.PostAsJsonAsync<News>(url, news).Result;
            if (model.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Add news completed");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<News>().Result;

            return View(model);
        }

        [HttpPost]
        //HttpPostedFileBase file, string oldPhoto
        public ActionResult Edit(News news, HttpPostedFileBase file)
        {
            if (file != null)
            {
                news.Photo = "/Images/" + Path.GetFileName(file.FileName);
            }
            else if (file == null)
            {
                //do nothing
            }
            var model = httpClient.PutAsJsonAsync(url, news).Result;
            if (model.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Update news completed");
            }
            return View(news);
        }

        public ActionResult Delete(int id)
        {
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<News>().Result;

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = httpClient.DeleteAsync(url + id).Result;
            if (model.IsSuccessStatusCode)
            {
                //do nothing
                //ModelState.AddModelError("", "Delete news completed");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}