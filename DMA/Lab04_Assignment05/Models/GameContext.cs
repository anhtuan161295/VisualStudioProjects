using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_Assignment05.Models
{
    class GameContext : DataContext
    {
        public GameContext(string fileOrConnection)
            : base(fileOrConnection)
        {
        }

        public GameContext(string fileOrConnection, MappingSource mapping)
            : base(fileOrConnection, mapping)
        {
        }

        public Table<Game> Games
        {
            get { return GetTable<Game>(); }
        }
    }
}