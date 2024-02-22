using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.MyResourceService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.MyResourceService
{
    public class CreateMyResourceCommandHandler : IRequestHandler<CreateMyResourceCommand, int>
    {
        private readonly IMyResourceRepository _myResourceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateMyResourceCommandHandler> _logger;

        public CreateMyResourceCommandHandler(IMyResourceRepository myResourceRepository, IMapper mapper, ILogger<CreateMyResourceCommandHandler> logger)
        {
            _myResourceRepository = myResourceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateMyResourceCommand request, CancellationToken cancellationToken)
        {
            var myResourceEntity = _mapper.Map<MyResource>(request);

            /*****************************************************************************/
            var generatedMyResource = await _myResourceRepository.AddAsync(myResourceEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedMyResource} successfully created.");
            return generatedMyResource.Id;
        }
    }
}
