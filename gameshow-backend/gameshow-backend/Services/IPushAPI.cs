using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_backend.Services
{
    public interface IPushAPI
    {
        Task Push(string content, string user);
    }
}
