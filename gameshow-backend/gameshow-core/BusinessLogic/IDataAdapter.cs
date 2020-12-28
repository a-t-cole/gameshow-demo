using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameshow_core.Models; 

namespace gameshow_core.BusinessLogic
{
    public interface IDataAdapter
    {
        Game GetGameById(string id);
        IEnumerable<Game> GetAllGames();
        void SaveGame(Game game);
        int GetNextGameId();

    }
}
