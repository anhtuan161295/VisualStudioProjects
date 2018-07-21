using Lab02WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab02WebAPI.Controllers
{
    public class NewsController : ApiController
    {
        NewsContext db = new NewsContext();

        public IQueryable<News> GetNews()
        {
            return db.NewsList;
        }

        public News GetNewsById(int id)
        {
            return db.NewsList.Find(id);
        }

        public IHttpActionResult PostNews(News news)
        {
            db.NewsList.Add(news);
            db.SaveChanges();
            //return StatusCode(HttpStatusCode.OK);
            return Ok();
        }

        public IHttpActionResult PutNews(News news)
        {
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
            //return StatusCode(HttpStatusCode.OK);
            return Ok();
        }

        public IHttpActionResult DeleteNews(int id)
        {
            var model = db.NewsList.Find(id);

            db.NewsList.Remove(model);
            db.SaveChanges();
            //return StatusCode(HttpStatusCode.OK);
            return Ok();
        }
    }
}