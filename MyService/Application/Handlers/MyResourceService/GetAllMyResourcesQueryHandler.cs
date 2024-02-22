using AutoMapper;
using MediatR;
using Application.Queries.MyResourceService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.MyResourceService
{
    public class GetAllMyResourcesQueryHandler : IRequestHandler<GetAllMyResourcesQuery, List<MyResourceResponse>>
    {
        private readonly IMyResourceRepository _myResourceRepository;
        private readonly IMapper _mapper;
        public GetAllMyResourcesQueryHandler(IMyResourceRepository myResourceRepository, IMapper mapper)
        {
            _myResourceRepository = myResourceRepository;
            _mapper = mapper;
        }
        public async Task<List<MyResourceResponse>> Handle(GetAllMyResourcesQuery request, CancellationToken cancellationToken)
        {
            var generatedMyResource = await _myResourceRepository.GetAllAsync();
            var myResourceEntity = _mapper.Map<List<MyResourceResponse>>(generatedMyResource);
            return myResourceEntity;
        }
    }
}
