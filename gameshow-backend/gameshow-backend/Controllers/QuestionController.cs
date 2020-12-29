using gameshow_backend.Models.Responses;
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
    public class QuestionController : ControllerBase
    {
        private readonly GameManager _gameManager;

        public QuestionController(GameManager gameManager) 
        {
            this._gameManager = gameManager; 
        }

        [HttpGet]
        public GetQuestionResponse GetConnectionQuestion() 
        {

            return new GetQuestionResponse();
        }
    }
}
