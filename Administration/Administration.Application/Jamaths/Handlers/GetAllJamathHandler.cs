using Administration.Application.Jamaths.DTOs;
using Administration.Application.Jamaths.Queries;
using Administration.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Administration.Application.Jamaths.Handlers
{
    public class GetAllJamathHandler : IRequestHandler<GetAllJamathQuery, List<JamathDto>>
    {
        private readonly IJamathRepository _jamathRepository;
        private readonly IMapper _mapper;

        public GetAllJamathHandler(IJamathRepository jamathRepository, IMapper mapper)
        {
            _jamathRepository = jamathRepository;
            _mapper = mapper;
        }

        public async Task<List<JamathDto>> Handle(GetAllJamathQuery request, CancellationToken cancellationToken)
        {
            var jamaths = await _jamathRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<JamathDto>>(jamaths);
        }
    }
}
