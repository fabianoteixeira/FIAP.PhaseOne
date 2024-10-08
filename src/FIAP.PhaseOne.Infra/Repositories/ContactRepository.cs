using FIAP.PhaseOne.Application.Interfaces;
using FIAP.PhaseOne.Domain.ContactAggregate;
using FIAP.PhaseOne.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.PhaseOne.Infra.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Contact contact, CancellationToken ct)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<Contact?> GetById(Guid id, CancellationToken ct) =>
            await _context.Contacts.Include(c => c.Phone)
                                    .Include(c => c.Address)
                                    .FirstOrDefaultAsync(c => c.Id == id, ct);

        public async Task Update(Contact contact, CancellationToken ct)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id, CancellationToken ct)
        {
            var contact = await GetById(id, ct);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync(ct);
            }
        }

        public async Task<IEnumerable<Contact>> GetAll(
            int page, 
            int limit, 
            CancellationToken ct) =>
                await _context.Contacts
                    .Include(c => c.Phone)
                    .Include(c => c.Address)
                    .Skip(page * limit)
                    .Take(limit)
                    .ToListAsync(ct);
    }

}
