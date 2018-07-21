using Lab04MVCWebRole.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Lab04MVCWebRole.Controllers
{
    public class BooksController : Controller
    {
        ServiceReference1.Service1Client sc = new Service1Client();

        // GET: Books
        public ActionResult Create()
        {
            TempData["pub"] = new SelectList(sc.GetPublishers(), "PublisherId", "PublisherName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            TempData["pub"] = new SelectList(sc.GetPublishers(), "PublisherId", "PublisherName");

            try
            {
                sc.addBook(book);
                ModelState.AddModelError("", "Add book completed");
            }
            catch (Exception)
            {
            }

            return View();
        }
    }
}