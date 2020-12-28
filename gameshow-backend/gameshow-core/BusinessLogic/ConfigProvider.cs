
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;

namespace gameshow_core.BusinessLogic
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly string _dataFolder; 
        public ConfigProvider(IConfiguration configuration) 
        {
            this._dataFolder = configuration["DataFolder"];
        }

        public string GetDataFolder()
        {
            return this._dataFolder; 
        }
    }
}
