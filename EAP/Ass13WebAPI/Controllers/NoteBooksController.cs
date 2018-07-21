using Ass13WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ass13WebAPI.Controllers
{
    public class NoteBooksController : ApiController
    {
        public static NoteBookContext db = new NoteBookContext();

        //Make notebook List with the price in the range : fromPrice -> toPrice
        public IQueryable<NoteBook> GetNoteBookList()
        {
            return db.NoteBookList;
        }

        //Delete notebook with NoteBookID.
        public IHttpActionResult DeleteNoteBook(string id)
        {
            var nb = db.NoteBookList.Find(id);
            if (nb != null)
            {
                db.NoteBookList.Remove(nb);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}