using Administration.Application.Contributors.DTOs;
using MediatR;

namespace Administration.Application.Contributors.Queries
{
    public record GetUserByIdQuery(Guid Id) : IRequest<UserResponseDto>;

}
