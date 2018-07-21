using CustomerLib;
using Lab09WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab09WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        CustomerContext db = new CustomerContext();

        public IHttpActionResult GetCustomers()
        {
            return Ok(db.CustomerList);
        }

        public IHttpActionResult PostCustomer(Customer newCustomer)
        {
            db.CustomerList.Add(newCustomer);
            db.SaveChanges();
            return Ok();
        }

        //[ActionName("Login")]
        //[HttpPost]
        //[Route("ControllerAndAction")]
        //public IHttpActionResult Login(Customer cusLog)
        //{
        //    var model = db.CustomerList.SingleOrDefault(a => a.Username.Equals(cusLog.Username));
        //    if (model != null)
        //    {
        //        if (model.Passcode.Equals(cusLog.Passcode))
        //        {
        //            return Ok();
        //        }
        //    }
        //    return StatusCode(HttpStatusCode.NotFound);
        //}

        [ActionName("Login")]
        [HttpGet]
        //[Route("api/[controller]/[action]/[username]/[passcode]")]
        public IHttpActionResult Login(string username, string passcode)
        {
            var model = db.CustomerList.SingleOrDefault(a => a.Username.Equals(username));
            if (model != null)
            {
                if (model.Passcode.Equals(passcode))
                {
                    return Ok();
                }
            }
            return StatusCode(HttpStatusCode.NotFound);
        }
    }
}