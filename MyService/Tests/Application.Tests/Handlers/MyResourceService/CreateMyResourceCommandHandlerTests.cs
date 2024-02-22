using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.MyResourceService;
using Application.Handlers.MyResourceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.MyResourceService
{
    public class CreateMyResourceCommandHandlerTests
    {
        private readonly Mock<IMyResourceRepository> _myResourceRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateMyResourceCommandHandler>> _logger;

        public CreateMyResourceCommandHandlerTests()
        {
            _myResourceRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateMyResourceCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<MyResource>(request))
                .Returns(new MyResource()); 

            _myResourceRepository
                .Setup(r => r.AddAsync(It.IsAny<MyResource>()))
                .ReturnsAsync(new MyResource { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateMyResourceCommandHandler>>();
            var handler = new CreateMyResourceCommandHandler(_myResourceRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
