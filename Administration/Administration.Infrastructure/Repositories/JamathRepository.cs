using Administration.Domain.Entities;
using Administration.Domain.Repositories;
using Administration.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Infrastructure.Repositories
{
    public class JamathRepository : IJamathRepository
    {
        private readonly AdministrationDbContext _context;

        public JamathRepository(AdministrationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Jamathperiod jamath)
        {
            await _context.AddAsync(jamath);
        }

        public async Task<List<Jamathperiod>> GetAllAsync(CancellationToken cancellationToken)
        {
            var jamathList = await _context.Jamathperiods.ToListAsync();
            return jamathList;
        }

        public async Task<Jamathperiod> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var jamath = await _context.Jamathperiods.FirstOrDefaultAsync(x => x.Id == id);
            return jamath;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
