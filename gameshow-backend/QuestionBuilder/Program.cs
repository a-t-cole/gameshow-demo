using System;
using gameshow_core.Models;
using gameshow_core.Models.Rounds;
using gameshow_core.Models.Classes; 
using gameshow_core.BusinessLogic;
using Microsoft.Extensions.Logging;
using System.Collections.Generic; 
namespace QuestionBuilder
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string _dataFolder = @"C:\Dev\gameshow-demo\gameshow-backend\Data\Games";
            ILogger logger = new LoggerFactory().CreateLogger("QuestionBuilder");
            IDataAdapter dataAdapter = new FileSystemDataAdapter(_dataFolder, new DeserializationHelper(logger), logger);
            var builder = new DummyDataBuilder();
            var game = new Game()
            {
                Id = dataAdapter.GetNextGameId(),
                Round1 = builder.GetConnectionRound(ConnectionType.CONNECTION),
                Round2 = builder.GetConnectionRound(ConnectionType.SEQUENCE),
                Round3 = new WallRound() {Wall1 = builder.GetWallRound(), Wall2 = builder.GetWallRound() },
                Round4 = new MissingVowelRound()
            };
            dataAdapter.SaveGame(game);
            game.Id = 2;
            dataAdapter.SaveGame(game);
            game.Id = 3;
            dataAdapter.SaveGame(game);
        }
    }
}
