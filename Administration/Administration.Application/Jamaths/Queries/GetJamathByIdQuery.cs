using Administration.Application.Jamaths.DTOs;
using MediatR;

namespace Administration.Application.Jamaths.Queries
{
    public record GetJamathByIdQuery(int id) : IRequest<JamathDto>;
}
