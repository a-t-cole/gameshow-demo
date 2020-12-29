using gameshow_backend.Models;
using gameshow_backend.Models.Requests;
using gameshow_backend.Services;
using gameshow_core.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly IPushAPI _pushAPI;
        private readonly GameManager _gameManager;
        private readonly IDataAdapter _dataAdapter;
        public ScoresController(IPushAPI pushApi, GameManager gameManager, IDataAdapter dataAdapter)
        {
            this._pushAPI = pushApi;
            this._gameManager = gameManager;
            this._dataAdapter = dataAdapter;
        }
        [HttpGet]
        public TeamScores GetScores()
        {
            var scores = new TeamScores(_gameManager);
            _pushAPI.PushObject(scores, "SCORE_UPDATE");
            return scores;
        }
        [HttpPut]
        public TeamScores AdjustScore(int adjustment, TeamType team)
        {
            switch (team)
            {
                case TeamType.Team1:
                    _gameManager.Team1Score += adjustment;
                    break;
                case TeamType.Team2:
                    _gameManager.Team2Score += adjustment;
                    break;
            }
            var scores =  new TeamScores(_gameManager);
            _pushAPI.PushObject(scores, "SCORE_UPDATE");
            return scores;
        }

        [HttpPost]
        public void SetScoreByTeam(SetScoreByTeamRequest request) 
        {
            if (request.Team.HasValue && request.Score.HasValue) 
            {
                switch (request.Team.Value)
                {
                    case TeamType.Team1:
                        _gameManager.Team1Score = request.Score.Value;
                        break;
                    case TeamType.Team2:
                        _gameManager.Team2Score = request.Score.Value;
                        break;
                }
            }
        }

        [HttpGet]
        public void ResetScores() 
        {
            _gameManager.ResetScores(); 
        }
    }
}
