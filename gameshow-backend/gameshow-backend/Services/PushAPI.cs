using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR; 

namespace gameshow_backend.Services
{   
    public class PushAPI : Hub, IPushAPI    
    {
        protected IHubContext<PushAPI> _context;
        public PushAPI(IHubContext<PushAPI> context) 
        {
            this._context = context; 
        }
        public async Task Push(string content, string user)
        {
            await _context.Clients.All.SendAsync("Message", user, content); 
        }
    }
}
