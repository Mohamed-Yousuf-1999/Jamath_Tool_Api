using Administration.Application.Contributors.DTOs;
using Administration.Domain.DTOs;
using MediatR;

namespace Administration.Application.Contributors.Commands.CreateContributor
{
    public record CreateUserCommand(UserCreateRequestDto Request) : IRequest<UserResponseDto>;

}
