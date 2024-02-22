using MediatR;
using Application.Responses;

namespace Application.Queries.MyResourceService
{
    public class GetAllMyResourcesQuery : IRequest<List<MyResourceResponse>>
    {

    }
}
