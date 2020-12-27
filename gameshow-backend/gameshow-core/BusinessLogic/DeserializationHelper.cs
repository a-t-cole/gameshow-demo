using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace gameshow_core.BusinessLogic
{
    public class DeserializationHelper : IDeserializationHelper
    {
        private readonly ILogger _logger;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            
        };
        public DeserializationHelper(ILoggerFactory loggerFactory) 
        {
            this._logger = loggerFactory.CreateLogger(nameof(DeserializationHelper));   
        }
        public T Deserialize<T>(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json)) 
                {
                    return default(T); 
                }
                return JsonSerializer.Deserialize<T>(json, options); 
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deserializing string");
                return default(T); 
            }
        }

        public ValueTask<T> DeserializeAsync<T>(Stream stream) 
        {
            try
            {
                return JsonSerializer.DeserializeAsync<T>(stream, options);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deserializing stream");
                return new ValueTask<T>(default(T));
            }
        
        }
        public string Serialize<T>(T data) 
        {
            return JsonSerializer.Serialize<T>(data, options);
        }
    }
}
