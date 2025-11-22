using Administration.Application.Jamaths.DTOs;
using Administration.Application.Jamaths.Queries;
using Administration.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.Jamaths.Handlers
{
    public class GetJamathByIdHandler
    {
        private readonly IJamathRepository _jamathRepository;
        private readonly IMapper _mapper;

        public GetJamathByIdHandler(IJamathRepository jamathRepository, IMapper mapper)
        {
            _jamathRepository = jamathRepository;
            _mapper = mapper;
        }

        public async Task<JamathDto> Handle(GetJamathByIdQuery request, CancellationToken cancellationToken)
        {
            var jamath = await _jamathRepository.GetByIdAsync(request.id, cancellationToken);
            var result = _mapper.Map<JamathDto>(jamath);
            return result;
        }
    }
}
