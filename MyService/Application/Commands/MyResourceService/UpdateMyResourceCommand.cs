using MediatR;

namespace Application.Commands.MyResourceService
{
    public class UpdateMyResourceCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public string Name { get; set; }
        
    
    }
}
