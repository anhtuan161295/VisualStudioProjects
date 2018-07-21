using Ass13MVCWebRole.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Ass13MVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        private string url = "http://localhost:6221/api/NoteBooks/";
        HttpClient httpClient = new HttpClient();

        private static int oldFromPrice = 0;
        private static int oldToPrice = 0;
        private static bool oldWifi = false;
        private static IEnumerable<NoteBook> oldNoteBooks;

        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string txtFromPrice, string txtToPrice, bool txtWifi)
        {
            if (string.IsNullOrEmpty(txtFromPrice))
            {
                ModelState.AddModelError("", "From Price is required");
            }
            else if (string.IsNullOrEmpty(txtToPrice))
            {
                ModelState.AddModelError("", "To Price is required");
            }
            else if (!txtFromPrice.IsInt())
            {
                ModelState.AddModelError("", "From Price must be a number");
            }
            else if (!txtToPrice.IsInt())
            {
                ModelState.AddModelError("", "To Price must be a number");
            }
            else if (txtFromPrice.IsInt() && txtToPrice.IsInt() && int.Parse(txtFromPrice) > int.Parse(txtToPrice))
            {
                ModelState.AddModelError("", "From Price must less than To Price");
            }
            else
            {
                var model = Task.Factory.StartNew(() =>
                   JsonConvert.DeserializeObject<IEnumerable<NoteBook>>(httpClient.GetStringAsync(url).Result)
           ).Result;
                //var model =
                //JsonConvert.DeserializeObjectAsync<IEnumerable<NoteBook>>(httpClient.GetStringAsync(url).Result).Result;

                var model2 =
                    model.Where(a => a.NoteBookPrice >= int.Parse(txtFromPrice) && a.NoteBookPrice <= int.Parse(txtToPrice) && a.Wifi == txtWifi)
                        .ToList();

                oldFromPrice = int.Parse(txtFromPrice);
                oldToPrice = int.Parse(txtToPrice);
                oldWifi = txtWifi;
                oldNoteBooks = model2;

                return View("Result", model2);
            }

            return View("Result", oldNoteBooks);
        }

        public ActionResult Delete(string id)
        {
            // Xóa trước rồi mới lấy dữ liệu
            var model = httpClient.DeleteAsync(url + id).Result;
            var model1 = Task.Factory.StartNew(() =>
                    JsonConvert.DeserializeObject<IEnumerable<NoteBook>>(httpClient.GetStringAsync(url).Result)
            ).Result;

            var model2 =
                model1.Where(a => a.NoteBookPrice >= oldFromPrice && a.NoteBookPrice <= oldToPrice && a.Wifi == oldWifi)
                    .ToList();

            if (model.IsSuccessStatusCode)
            {
                return View("Result", model2);
            }

            return View("Result", model2);
        }
    }
}