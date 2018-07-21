using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab06WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "GetMovies")]
        List<Movie> GetMovies();

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "GetMoviesByDirector/{directorName}")]
        List<Movie> GetMoviesByDirector(string directorName);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "PostMovie")]
        void PostMovie(Movie newMovie);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "DeleteMovie")]
        void DeleteMovie(int id);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "GetMovieById/{id}")]
        Movie GetMovieById(string id);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "PutMovie")]
        void PutMovie(Movie editMovie);
    }
}