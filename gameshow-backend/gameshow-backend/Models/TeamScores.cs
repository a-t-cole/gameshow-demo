using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_backend.Models
{
    public class TeamScores
    {
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }

        public TeamScores() { }
        public TeamScores(GameManager gameManager) 
        {
            this.Team1Name = gameManager.Team1Name;
            this.Team2Name = gameManager.Team2Name;
            this.Team1Score = gameManager.Team1Score;
            this.Team2Score = gameManager.Team2Score; 
        }
    }
}
