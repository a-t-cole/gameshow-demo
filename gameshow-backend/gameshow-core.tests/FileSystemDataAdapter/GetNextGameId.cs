using gameshow_core.BusinessLogic;
using gameshow_core.Models; 
using System;
using Xunit;
using NSubstitute;
using NSubstitute.Extensions;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace gameshow_core.tests.FileSystemDataAdapter
{
    public class GetNextGameId
    {
        private readonly BusinessLogic.FileSystemDataAdapter _dataAdapter;
        public GetNextGameId() 
        {
            _dataAdapter = Substitute.ForPartsOf<BusinessLogic.FileSystemDataAdapter>("UnitTest", Substitute.For<IDeserializationHelper>(), Substitute.For<ILogger>()); 

        }
        [Fact]
        public void NoExistingFiles()
        {
            _dataAdapter.Configure().GetAllGames().Returns(new List<Game>());

            _dataAdapter.GetNextGameId().Should().Be(1);
        }

        [Fact]
        public void ExistingFiles_ReturnsNext() 
        {
            var games = new List<Game>();
            for (var i = 0; i < 5; i++) 
            {
                games.Add(new Game() { Id = i });
            }
            _dataAdapter.Configure().GetAllGames().Returns(games);

            _dataAdapter.GetNextGameId().Should().Be(5);
        }

        [Fact]
        public void ExistingFiles_NonSequential_Returns() 
        {
            var games = new List<Game>();
            for (var i = 0; i < 5; i++)
            {
                games.Add(new Game() { Id = i });
            }
            games.Add(new Game() { Id = 100 });
            _dataAdapter.Configure().GetAllGames().Returns(games);

            _dataAdapter.GetNextGameId().Should().Be(101);
        }
    }
}
