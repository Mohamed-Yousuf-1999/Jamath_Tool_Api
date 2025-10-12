using Administration.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Administration.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task CreateAsync(User contributor);
        Task UpdateAsync (User contributor, CancellationToken cancellationToken);
        Task DeleteAsync (User contributor, CancellationToken cancellationToken);
        Task SaveChangesAsync ();
        Task<User?> GetFatherDetail(Guid? fatherId, CancellationToken cancellationToken);
    }
}
