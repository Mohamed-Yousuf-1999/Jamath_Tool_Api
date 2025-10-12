using Administration.Application.Contributors.DTOs;
using MediatR;

namespace Administration.Application.Contributors.Queries
{
    public record GetAllUsersQuery : IRequest<List<UserResponseDto>>;

}
