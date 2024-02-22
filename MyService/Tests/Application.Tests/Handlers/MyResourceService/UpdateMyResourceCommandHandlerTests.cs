using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.MyResourceService;
using Application.Exceptions;
using Application.Handlers.MyResourceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.MyResourceService
{
    public class UpdateMyResourceCommandHandlerTests
    {
        private readonly Mock<IMyResourceRepository> _myResourceRepository;
        private readonly Mock<ILogger<UpdateMyResourceCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateMyResourceCommandHandlerTests()
        {
            _myResourceRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsMyResourceNotFoundExceptionWhenMyResourceNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateMyResourceCommand { Id = Id }; // Create a request object

            _myResourceRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((MyResource)null); // Mock the repository to return null

            var handler = new UpdateMyResourceCommandHandler(_myResourceRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<MyResourceNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
