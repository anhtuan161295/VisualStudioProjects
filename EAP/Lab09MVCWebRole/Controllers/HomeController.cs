using CustomerLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab09MVCWebRole.Controllers
{
    public class HomeController : Controller
    {
        private string url = "http://localhost:2694/api/Customers/";
        HttpClient httpClient = new HttpClient();

        // GET: Home
        public ActionResult Index()
        {
            //var model = JsonConvert.DeserializeObjectAsync<IEnumerable<Customer>>(httpClient.GetStringAsync(url).Result).Result;

            var model = Task.Factory.StartNew(() =>
                        JsonConvert.DeserializeObject<IEnumerable<Customer>>(httpClient.GetStringAsync(url).Result)
            ).Result;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer newCustomer)
        {
            try
            {
                var model = httpClient.PostAsJsonAsync(url, newCustomer).Result;
                if (model.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Add customer completed");
                }
                else
                {
                    //do nothing
                }
            }
            catch (Exception)
            {
                //do nothing
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer cusLog)
        {
            //var data = Task.Factory.StartNew(() =>
            //            JsonConvert.DeserializeObject<IEnumerable<Customer>>(httpClient.GetStringAsync(url).Result)
            //).Result;
            //var model = data.SingleOrDefault(a => a.Username.Equals(cusLog.Username));

            string urlLog = url + "Login" + "/" + cusLog.Username + "/" + cusLog.Passcode;

            //string urlLog = url + "Login";

            try
            {
                //var model = httpClient.PostAsJsonAsync(urlLog, cusLog).Result;
                var model = httpClient.GetAsync(urlLog).Result;
                if (model.IsSuccessStatusCode)
                {
                    return Content("<script>alert('Login success');</script>");
                }
                else
                {
                    return Content("<script>alert('Username not found');</script>");
                }
            }
            catch (Exception)
            {
                //do nothing
            }

            return View();
        }
    }
}