using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace gameshow_backend.Services
{
    public class PushAPI : Hub, IPushAPI
    {
        protected IHubContext<PushAPI> _context;
        private readonly ILogger _logger; 

        public PushAPI(IHubContext<PushAPI> context, ILogger logger)
        {
            this._context = context;
            this._logger = logger; 
        }
        public async Task Push(string content, string user)
        {
            try
            {
                await _context.Clients.All.SendAsync("Message", user, content);
            }
            catch (Exception e) 
            {
                _logger.LogError("Couldn't push message", e);
            }
        }
        public async Task PushObject<T>(T data, string pushAs)
        {
            try
            {
                await  _context.Clients.All.SendAsync(pushAs, data);
            }
            catch (Exception e) 
            {
                _logger.LogError("Couldn't push object", e);
            }
        }   
    }
}
