using AutoMapper;
using Moq;
using Application.Handlers.MyResourceService;
using Application.Queries.MyResourceService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.MyResourceService
{
    public class GetAllMyResourcesQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfMyResourceResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyResource, MyResourceResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<MyResource> 
        {
            new MyResource { Id = 1 },
            new MyResource { Id = 2 }

        };

            var RepositoryMock = new Mock<IMyResourceRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllMyResourcesQuery();
            var handler = new GetAllMyResourcesQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MyResourceResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
