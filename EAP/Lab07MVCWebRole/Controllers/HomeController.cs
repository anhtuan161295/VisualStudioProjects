using Lab07MVCWebRole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Lab07MVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient = new HttpClient();
        private string url = "http://localhost:2756/api/Albums/";

        // GET: Home
        public ActionResult Index()
        {
            var model =
                JsonConvert.DeserializeObjectAsync<IEnumerable<Album>>(httpClient.GetStringAsync(url).Result).Result;

            var list = from a in model
                       group a by a.Genre into b
                       select new
                       {
                           GenreName = b.Key,
                           GenreValue = b.Key
                       };

            var newlist = new SelectList(list, "GenreName", "GenreValue");
            ViewBag.Genres = newlist;

            return View(model);
        }

        public ActionResult IndexByGenre(string GenreName)
        {
            var model =
                JsonConvert.DeserializeObjectAsync<IEnumerable<Album>>(httpClient.GetStringAsync(url).Result).Result;

            var list = from a in model
                       group a by a.Genre into b
                       select new
                       {
                           GenreName = b.Key,
                           GenreValue = b.Key
                       };

            var newlist = new SelectList(list, "GenreName", "GenreValue");
            ViewBag.Genres = newlist;

            var model2 = model.Where(a => a.Genre.Equals(GenreName)).ToList();

            return View("Index", model2);
        }

        public ActionResult Details(int id)
        {
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Album>().Result;
            //var model = JsonConvert.DeserializeObjectAsync<Album>(httpClient.GetStringAsync(url + id).Result).Result;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album newAlbum)
        {
            var model = httpClient.PostAsJsonAsync(url, newAlbum).Result;
            if (model.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Add album completed");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = httpClient.GetAsync(url + id).Result.Content.ReadAsAsync<Album>().Result;
            //var model = JsonConvert.DeserializeObjectAsync<Album>(httpClient.GetStringAsync(url + id).Result).Result;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Album editAlbum)
        {
            var model = httpClient.PutAsJsonAsync(url, editAlbum).Result;
            if (model.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Update album completed");
            }
            return View(editAlbum);
        }

        public ActionResult Delete(int id)
        {
            var model =
               JsonConvert.DeserializeObjectAsync<Album>(httpClient.GetStringAsync(url + id).Result).Result;
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = httpClient.DeleteAsync(url + id).Result;
            if (model.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}