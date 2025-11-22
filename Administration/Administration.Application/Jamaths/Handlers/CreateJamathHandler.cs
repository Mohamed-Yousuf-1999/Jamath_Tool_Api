using Administration.Application.Jamaths.Commands;
using Administration.Domain.Entities;
using Administration.Domain.Repositories;
using MediatR;

namespace Administration.Application.Jamaths.Handlers
{
    public class CreateJamathHandler : IRequestHandler<CreateJamathCommand, int>
    {
        private readonly IJamathRepository _jamathRepository;

        public CreateJamathHandler(IJamathRepository jamathRepository)
        {
            _jamathRepository = jamathRepository;
        }

        public async Task<int> Handle(CreateJamathCommand request, CancellationToken cancellationToken)
        {
            var jamath = new Jamathperiod
            {
                FromDate = request.fromDate,
                ToDate = request.toDate,
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,                
            };

            await _jamathRepository.CreateAsync(jamath);
            await _jamathRepository.SaveChangesAsync();
            return jamath.Id;
        }
    }
}
