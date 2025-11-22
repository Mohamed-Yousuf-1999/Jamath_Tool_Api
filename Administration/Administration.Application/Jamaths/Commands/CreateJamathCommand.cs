using MediatR;

namespace Administration.Application.Jamaths.Commands
{
    public record CreateJamathCommand(DateTime fromDate, DateTime toDate) : IRequest<int>;
}
