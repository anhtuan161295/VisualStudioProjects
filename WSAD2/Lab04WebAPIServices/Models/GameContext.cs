using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Lab04WebAPIServices.Models
{
    public class GameContext
    {
        public static ObservableCollection<Game> gameList = new ObservableCollection<Game>
        {
            new Game{Id = 1, Title = "Chess", Genre = "IQ", ReleaseOfYear = "2000"}
        };
    }
}