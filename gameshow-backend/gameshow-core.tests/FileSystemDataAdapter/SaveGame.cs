using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using NSubstitute;
using gameshow_core.BusinessLogic;
using Microsoft.Extensions.Logging;
using gameshow_core.Models;

namespace gameshow_core.tests.FileSystemDataAdapter
{
    public class SaveGame 
    {
        public SaveGame() 
        {
        
        }

        [Fact]
        public void SaveGame_NormalFlow() 
        {
            using (var testEnv = new BaseFileSystemTest()) 
            {
                var logger = Substitute.For<ILogger>(); 
                var adapter = new gameshow_core.BusinessLogic.FileSystemDataAdapter(testEnv.tempFolder, new DeserializationHelper(logger),logger );

                var game = new Game() { Id = 1 };
                adapter.SaveGame(game);
                adapter.GetGameById("1").Should().BeEquivalentTo(game);
            }
        }
    }
}
