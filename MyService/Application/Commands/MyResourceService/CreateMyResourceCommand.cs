using MediatR;

namespace Application.Commands.MyResourceService
{
    public class CreateMyResourceCommand : IRequest<int>
    {
        public int Id  { get; set; }
    
        
        public string Name { get; set; }
        
    
    }
}
