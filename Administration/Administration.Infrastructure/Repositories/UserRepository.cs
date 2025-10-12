using Administration.Domain.Entities;
using Administration.Domain.Repositories;
using Administration.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Administration.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AdministrationDbContext _context;

        public UserRepository(AdministrationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User contributor)
        {
            await _context.AddAsync(contributor);
        }
         

        public async Task DeleteAsync(User contributor, CancellationToken cancellationToken)
        {
            _context.Users.Remove(contributor);
            await Task.CompletedTask;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
            => await _context.Users.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _context.Users.FindAsync(new object[] { id }, cancellationToken);

        public async Task<User?> GetFatherDetail(Guid? fatherId, CancellationToken cancellationToken)
            => await _context.Users.FindAsync(new object[] { fatherId }, cancellationToken);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task UpdateAsync(User contributor, CancellationToken cancellationToken)
        {
            _context.Users.Update(contributor);
            await Task.CompletedTask;
        }
    }
}
