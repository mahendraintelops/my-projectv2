using MediatR;

namespace Application.Commands.MyResourceService
{
    public class DeleteMyResourceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
