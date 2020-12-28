using gameshow_backend.Models;
using gameshow_backend.Models.Requests;
using gameshow_backend.Services;
using gameshow_core.BusinessLogic;
using gameshow_core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace gameshow_backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IPushAPI _pushAPI;
        private readonly GameManager _gameManager;
        private readonly IDataAdapter _dataAdapter; 
        public GameController(IPushAPI pushApi, GameManager gameManager, IDataAdapter dataAdapter) 
        {
            this._pushAPI = pushApi;
            this._gameManager = gameManager;
            this._dataAdapter = dataAdapter; 
        }

        [HttpGet]
        public Game GetGameById(int id)
        {
            var game = _dataAdapter.GetGameById(id.ToString());
            if (game == null)
            {
                throw new Exception("Game does not exist");
            }
            else 
            {
                return game; 
            }
        }
        [HttpPut]
        public Game SetGameById(int id) 
        {
            var game = _dataAdapter.GetGameById(id.ToString());
            if (game == null)
            {
                throw new Exception("Game does not exist");
            }
            else
            {
                _gameManager.CurrentGame = game; 
                return game;
            }
        }

        [HttpPost]
        public void RenameTeam(RenameTeamRequest request) 
        {
            switch (request.Team) 
            {
                case TeamType.Team1:
                    _gameManager.Team1Name = request.TeamName;
                    break;
                case TeamType.Team2:
                    _gameManager.Team2Name = request.TeamName;
                    break;
            }
        }
    }
}
