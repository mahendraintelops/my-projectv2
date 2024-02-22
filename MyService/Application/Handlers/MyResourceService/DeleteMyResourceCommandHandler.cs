using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.MyResourceService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.MyResourceService
{
    public class DeleteMyResourceCommandHandler : IRequestHandler<DeleteMyResourceCommand>
    {
        private readonly IMyResourceRepository _myResourceRepository;
        private readonly ILogger<DeleteMyResourceCommandHandler> _logger;

        public DeleteMyResourceCommandHandler(IMyResourceRepository myResourceRepository, ILogger<DeleteMyResourceCommandHandler> logger)
        {
            _myResourceRepository = myResourceRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteMyResourceCommand request, CancellationToken cancellationToken)
        {
            var myResourceToDelete = await _myResourceRepository.GetByIdAsync(request.Id);
            if (myResourceToDelete == null)
            {
                throw new MyResourceNotFoundException(nameof(MyResource), request.Id);
            }

            await _myResourceRepository.DeleteAsync(myResourceToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
