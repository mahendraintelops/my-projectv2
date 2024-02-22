using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.MyResourceService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.MyResourceService
{
    public class UpdateMyResourceCommandHandler : IRequestHandler<UpdateMyResourceCommand>
    {
        private readonly IMyResourceRepository _myResourceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateMyResourceCommandHandler> _logger;

        public UpdateMyResourceCommandHandler(IMyResourceRepository myResourceRepository, IMapper mapper, ILogger<UpdateMyResourceCommandHandler> logger)
        {
            _myResourceRepository = myResourceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateMyResourceCommand request, CancellationToken cancellationToken)
        {
            var myResourceToUpdate = await _myResourceRepository.GetByIdAsync(request.Id);
            if (myResourceToUpdate == null)
            {
                throw new MyResourceNotFoundException(nameof(MyResource), request.Id);
            }

            _mapper.Map(request, myResourceToUpdate, typeof(UpdateMyResourceCommand), typeof(MyResource));
            await _myResourceRepository.UpdateAsync(myResourceToUpdate);
            _logger.LogInformation($"MyResource is successfully updated");
        }
    }
}
