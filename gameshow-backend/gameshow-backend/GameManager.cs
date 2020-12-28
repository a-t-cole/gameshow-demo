using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameshow_core.Models; 

namespace gameshow_backend
{
    public class GameManager
    {
        public Game CurrentGame { get; set; }
        public int Team1Score { get; set; }
        public string Team1Name { get; set; } = "Team 1";
        public int Team2Score { get; set; }
        public string Team2Name { get; set; } = "Team 2";

        public void ResetScores() 
        {
            Team1Name = "Team 1";
            Team2Name = "Team 2";
            Team1Score = 0;
            Team2Score = 0; 
        }
        public void LoadNewGame(Game game) 
        {
            ResetScores();
            CurrentGame = game; 
        }
    }
}
