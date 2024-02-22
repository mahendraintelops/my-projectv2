using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.MyResourceService;
using Application.Exceptions;
using Application.Handlers.MyResourceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.MyResourceService
{
    public class DeleteMyResourceCommandHandlerTests
    {
        private readonly Mock<IMyResourceRepository> _myResourceRepository;
        private readonly Mock<ILogger<DeleteMyResourceCommandHandler>> _logger;

        public DeleteMyResourceCommandHandlerTests()
        {
            _myResourceRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsMyResourceNotFoundExceptionWhenMyResourceNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteMyResourceCommand { Id = Id }; // Create a request object

            _myResourceRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((MyResource)null); // Mock the repository to return null

            var handler = new DeleteMyResourceCommandHandler(_myResourceRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<MyResourceNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
