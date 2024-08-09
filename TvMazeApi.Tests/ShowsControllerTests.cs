using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using TvMazeApi.Controllers;
using FakeItEasy;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TvMazeApi.Tests
{
    public class ShowsControllerTests
    {
        private readonly IShowRepository _showRepository;
        private readonly ShowService _showService;
        private readonly ShowsController _showsController;

        public ShowsControllerTests()
        {
            _showRepository = A.Fake<IShowRepository>();
            _showService = A.Fake<ShowService>();
            _showsController = new ShowsController(_showService);
        }
        [Fact]
        public async Task GetShow_Returns_Ok_With_ShowAsync() 
        {
            var fakeShows = A.CollectionOfDummy<Show>(10).ToList();
            A.CallTo(() => _showService.GetShowsAsync()).Returns(Task.FromResult(fakeShows));

            // Act
            var result = await _showsController.GetShows();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShows = okResult.Value as List<Show>;
            Assert.Equal(fakeShows.Count, returnedShows.Count);

        }

        [Fact]
        public async Task GetShowById_ShouldReturnNotFound()
        {
            // Arrange
            A.CallTo(() => _showService.GetShowByIdAsync(A<int>.Ignored)).Returns((Show)null);

            // Act
            var result = await _showsController.GetShowByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetShowById_ShouldReturnShow()
        {
            int id = 1;
            var newShow = new Show { Id = 1 };

            // Arrange
            A.CallTo(() => _showService.GetShowByIdAsync(id)).Returns(Task.FromResult(newShow));

            var result = await _showsController.GetShowByIdAsync(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShow = okResult.Value as Show;
            var show = Assert.IsType<Show>(returnedShow);
        }
    }
}
