using Lab07WebAPIRole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab07WebAPIRole.Controllers
{
    public class AlbumsController : ApiController
    {
        AlbumContext db = new AlbumContext();

        public IQueryable<Album> GetAlbums()
        {
            return db.AlbumList;
        }

        public Album GetAlbumById(int id)
        {
            var album = db.AlbumList.SingleOrDefault(a => a.Id.Equals(id));
            return album;
        }

        public IHttpActionResult PostAlbum(Album newAlbum)
        {
            db.AlbumList.Add(newAlbum);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult PutAlbum(Album editAlbum)
        {
            var album = db.AlbumList.SingleOrDefault(a => a.Id.Equals(editAlbum.Id));
            if (album != null)
            {
                album.Title = editAlbum.Title;
                album.Genre = editAlbum.Genre;
                album.YearOfRelease = editAlbum.YearOfRelease;
            }
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult DeleteAlbum(int id)
        {
            var album = db.AlbumList.SingleOrDefault(a => a.Id.Equals(id));
            if (album != null)
            {
                db.AlbumList.Remove(album);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}