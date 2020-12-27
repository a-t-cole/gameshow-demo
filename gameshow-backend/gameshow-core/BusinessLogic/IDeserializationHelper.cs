using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace gameshow_core.BusinessLogic
{
    public interface IDeserializationHelper
    {
        T Deserialize<T>(string json);
        ValueTask<T> DeserializeAsync<T>(Stream stream);
        string Serialize<T>(T data);
    }
}
