using Administration.Application.Contributors.DTOs;
using Administration.Application.Contributors.Queries;
using Administration.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Administration.Application.Contributors.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            var result = _mapper.Map<UserResponseDto>(user);    
            return result;

        }
    }
}
