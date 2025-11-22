using Administration.Domain.Entities;

namespace Administration.Domain.Repositories
{
    public interface IJamathRepository
    {
        Task CreateAsync(Jamathperiod jamath);
        Task<Jamathperiod> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<Jamathperiod>> GetAllAsync(CancellationToken cancellationToken);
        Task SaveChangesAsync();
    }
}
