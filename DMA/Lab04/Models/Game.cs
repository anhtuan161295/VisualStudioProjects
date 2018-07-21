using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Models
{
    [Table]
    class Game
    {
        [Column(IsPrimaryKey = true)]
        public string Title { get; set; }

        [Column(CanBeNull = false)]
        public string Year { get; set; }

        [Column(CanBeNull = false)]
        public double Price { get; set; }
    }

    class GameContext : DataContext
    {
        public GameContext(string GameConn)
            : base(GameConn)
        {
        }

        public Table<Game> Games
        {
            get { return GetTable<Game>(); }
        }

        //public GameContext(string fileOrConnection)
        //    : base(fileOrConnection)
        //{
        //}

        //public GameContext(string fileOrConnection, MappingSource mapping)
        //    : base(fileOrConnection, mapping)
        //{
        //}
    }
}