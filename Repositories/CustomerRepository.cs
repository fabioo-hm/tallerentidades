using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Repositories
{
using Microsoft.EntityFrameworkCore;
using TareaEntidades.Entities;
using TareaEntidades.Abstractions;

namespace TareaEntidades.Infrastructure.Repositories
{
    public sealed class CustomerRepository(AppDbContext db) : ICustomerRepository
    {
        public Task<Customer?> GetByIdAsync(int id, CancellationToken ct = default)
            => db.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, ct);

        public Task<Customer?> GetByEmailAsync(string email, CancellationToken ct = default)
            => db.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email, ct);

        public Task<IReadOnlyList<Customer>> GetByNameAsync(string name, CancellationToken ct = default)
            => db.Customers
                .AsNoTracking()
                .Where(c => c.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<Customer>)t.Result, ct);

        public Task<IReadOnlyList<Customer>> GetByCityIdAsync(string cityId, CancellationToken ct = default)
            => db.Customers
                .AsNoTracking()
                .Where(c => c.CityOrMunicipalityId == cityId)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<Customer>)t.Result, ct);

        public Task<IReadOnlyList<Customer>> GetByAudienceIdAsync(int audienceId, CancellationToken ct = default)
            => db.Customers
                .AsNoTracking()
                .Where(c => c.AudienceId == audienceId)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<Customer>)t.Result, ct);

        public Task<IReadOnlyList<Customer>> GetAllAsync(CancellationToken ct = default)
            => db.Customers
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<Customer>)t.Result, ct);

        public async Task AddAsync(Customer customer, CancellationToken ct = default)
        {
            db.Customers.Add(customer);
            await db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Customer customer, CancellationToken ct = default)
        {
            db.Customers.Update(customer);
            await db.SaveChangesAsync(ct);
        }

        public async Task RemoveAsync(Customer customer, CancellationToken ct = default)
        {
            db.Customers.Remove(customer);
            await db.SaveChangesAsync(ct);
        }

        public Task<bool> ExistsIdAsync(int id, CancellationToken ct = default)
            => db.Customers
                .AsNoTracking()
                .AnyAsync(c => c.Id == id, ct);

        public async Task<IReadOnlyList<Customer>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
        {
            var query = db.Customers.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(c =>
                    c.Name.ToUpper().Contains(term) ||
                    c.Email!.ToUpper().Contains(term));
            }

            return await query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
        {
            var query = db.Customers.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(c =>
                    c.Name.ToUpper().Contains(term) ||
                    c.Email!.ToUpper().Contains(term));
            }

            return query.CountAsync(ct);
        }
    }
}