using AutoMapper;
using MediatR;
using Application.Queries.MyResourceService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.MyResourceService
{
    public class GetMyResourceByIdQueryHandler : IRequestHandler<GetMyResourceByIdQuery, MyResourceResponse>
    {
        private readonly IMyResourceRepository _myResourceRepository;
        private readonly IMapper _mapper;
        public GetMyResourceByIdQueryHandler(IMyResourceRepository myResourceRepository, IMapper mapper)
        {
            _myResourceRepository = myResourceRepository;
            _mapper = mapper;
        }
        public async Task<MyResourceResponse> Handle(GetMyResourceByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedMyResource = await _myResourceRepository.GetByIdAsync(request.id);
            var myResourceEntity = _mapper.Map<MyResourceResponse>(generatedMyResource);
            return myResourceEntity;
        }
    }
}
