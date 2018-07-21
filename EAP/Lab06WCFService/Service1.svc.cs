using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab06WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        MovieContext db = new MovieContext();

        public List<Movie> GetMovies()
        {
            return db.MovieList.ToList();
        }

        public List<Movie> GetMoviesByDirector(string directorName)
        {
            var model = db.MovieList.Where(u => u.Director.Contains(directorName)).ToList();
            return model;
        }

        public void PostMovie(Movie newMovie)
        {
            db.MovieList.Add(newMovie);
            db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = db.MovieList.Find(id);
            if (movie != null)
            {
                db.MovieList.Remove(movie);
                db.SaveChanges();
            }
        }

        public Movie GetMovieById(string id)
        {
            var movie = db.MovieList.Find(int.Parse(id));
            return movie;
        }

        public void PutMovie(Movie editMovie)
        {
            db.Entry(editMovie).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}