using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameshow_core.Models; 

namespace gameshow_backend.BusinessLogic
{
    interface IDataAdapter
    {
        Game GetGameById(string id);
        IEnumerable<Game> GetAllGames();
        void SaveGame(Game game);
        int GetNextGameId();

    }
}
