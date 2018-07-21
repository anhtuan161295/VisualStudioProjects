using Lab04WebAPIServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab04WebAPIServices.Controllers
{
    public class GamesController : ApiController
    {
        public IEnumerable<Game> GetGameList()
        {
            return GameContext.gameList;
        }

        public IHttpActionResult PostGame(Game newGame)
        {
            GameContext.gameList.Add(newGame);
            return Ok();
        }
    }
}