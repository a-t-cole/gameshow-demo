using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq; 
using System.Text;
using Xunit;
using FluentAssertions;
using NSubstitute;
using Microsoft.Extensions.Logging;
using gameshow_core.BusinessLogic;
using gameshow_core.Models;

namespace gameshow_core.tests.FileSystemDataAdapter
{
    public class GetAllGames
    {
        [Fact]
        public void NormalFlow() 
        {
            using (var testEnv = new BaseFileSystemTest())
            {
                var logger = Substitute.For<ILogger>();
                var adapter = new gameshow_core.BusinessLogic.FileSystemDataAdapter(testEnv.tempFolder, new DeserializationHelper(logger), logger);

                for (var i = 1; i < 6; i++)
                {
                    var game = new Game() { Id = i };
                    adapter.SaveGame(game);
                }
                var result = adapter.GetAllGames();
                result.Count().Should().Be(5);
                result.Select(x => x.Id).Should().BeEquivalentTo(new List<int>() { 1, 2, 3, 4, 5 });
            }            
        }
    }
}
