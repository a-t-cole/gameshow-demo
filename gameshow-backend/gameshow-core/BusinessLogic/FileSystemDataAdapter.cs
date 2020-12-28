using gameshow_core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Linq; 

namespace gameshow_core.BusinessLogic
{
    public class FileSystemDataAdapter : IDataAdapter
    {
        private readonly string _dataFolder;
        private readonly IDeserializationHelper _deserializationHelper;
        private readonly ILogger _logger;

        public FileSystemDataAdapter(IConfigProvider configProvider, IDeserializationHelper deserializationHelper, ILogger logger) 
        {
            var folder = configProvider.GetDataFolder();
            ValidateDataFolder(folder);
            this._dataFolder = folder;
            this._deserializationHelper = deserializationHelper;
            this._logger = logger;
        }
        public FileSystemDataAdapter(string dataFolder, IDeserializationHelper deserializationHelper, ILogger logger) 
        {
            ValidateDataFolder(dataFolder);
            this._dataFolder = dataFolder;
            this._logger = logger;
            this._deserializationHelper = deserializationHelper;
        }

        private void ValidateDataFolder(string dataFolder) 
        {
            if (string.IsNullOrWhiteSpace(dataFolder))
            {
                throw new ArgumentException(nameof(dataFolder));
            }
            else if (!Directory.Exists(dataFolder))
            {
                if (dataFolder != "UnitTest")
                    throw new Exception($"Directory {dataFolder} does not exist.");
            }
        }

        public virtual IEnumerable<Game> GetAllGames()
        {
            var result = new List<Game>(); 
            var files = Directory.GetFiles(_dataFolder);

            foreach (var f in files) 
            {
                result.Add(GetGameByPath(f));
            }
            return result;
        }

        private Game GetGameByPath(string path) 
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                return _deserializationHelper.Deserialize<Game>(json);
            }
            else
            {
                return null;
            }
        }
        public Game GetGameById(string id)
        {
            string file = $"{id}.json";
            var path = Path.Combine(_dataFolder, file);
            return GetGameByPath(path);
        }

        public void SaveGame(Game game) 
        {
            var filename = $"{game.Id}.json";
            try
            {
                File.WriteAllText(Path.Combine(_dataFolder, filename), _deserializationHelper.Serialize<Game>(game));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Couldn't save game");
                throw new Exception("Couldn't save game");
            }
            
        }

        public int GetNextGameId() 
        {
            var games = GetAllGames();
            if (games.Count() > 0)
            {
                return games.Max(x => x.Id) + 1;
            }
            else 
            {
                return 1; 
            }
        }
    }
}

