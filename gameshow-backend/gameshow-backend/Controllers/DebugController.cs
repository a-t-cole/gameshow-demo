using gameshow_backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gameshow_backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DebugController : ControllerBase
    {
        private readonly IPushAPI _pushApi; 
        public DebugController(IPushAPI pushApi) 
        {
            this._pushApi = pushApi; 
        }

        [HttpGet]
        public void Push(string message) 
        {
            this._pushApi.Push(message, "DebugController");
        }
    }
}
