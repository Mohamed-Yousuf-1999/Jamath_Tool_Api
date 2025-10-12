using Administration.Application.Contributors.DTOs;
using Administration.Application.Contributors.Queries;
using Administration.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Administration.Application.Contributors.Handlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            
            return _mapper.Map<List<UserResponseDto>>(users);
        }
    }
}
