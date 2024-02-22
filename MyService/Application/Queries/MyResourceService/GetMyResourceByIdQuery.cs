using MediatR;
using Application.Responses;

namespace Application.Queries.MyResourceService
{
    public class GetMyResourceByIdQuery : IRequest<MyResourceResponse>
    {
        public int id { get; set; }

        public GetMyResourceByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
