using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace gameshow_core.tests.FileSystemDataAdapter
{
    public class BaseFileSystemTest : IDisposable
    {
        public readonly string tempFolder; 
        public BaseFileSystemTest() 
        {
            tempFolder = Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempFolder);
        }

        public void Dispose()
        {
            var di = new DirectoryInfo(tempFolder);
            foreach (var f in di.EnumerateFiles()) 
            {
                f.Delete(); 
            }
            Directory.Delete(tempFolder);
        }
    }
}
