using AutoMapper;
using Moq;
using Application.Handlers.MyResourceService;
using Application.Queries.MyResourceService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.MyResourceService
{
    public class GetMyResourceByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsMyResourceResponse()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyResource, MyResourceResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var Id = 1; 
            var obj = new MyResource { Id = Id, /* other properties */ };

            var RepositoryMock = new Mock<IMyResourceRepository>();
            RepositoryMock.Setup(repo => repo.GetByIdAsync(Id)).ReturnsAsync(obj);

            var query = new GetMyResourceByIdQuery(Id);
            var handler = new GetMyResourceByIdQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MyResourceResponse>(result);
            // Add assertions to check the mapping and properties 
            Assert.Equal(Id, result.Id);
            // Add more assertions as needed
        }
    }
}
