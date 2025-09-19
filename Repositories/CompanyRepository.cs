using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Repositories
{
public sealed class CompanyRepository(AppDbContext db) : ICompanyRepository
    {
        public Task<Company?> GetByIdAsync(string id, CancellationToken ct = default)
            => db.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, ct);

        public Task<Company?> GetByNameAsync(string name, CancellationToken ct = default)
            => db.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name, ct);

        public Task<Company?> GetByEmailAsync(string email, CancellationToken ct = default)
            => db.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Email == email, ct);

        public Task<IReadOnlyList<Company>> GetByCityIdAsync(string cityId, CancellationToken ct = default)
            => db.Companies
                .AsNoTracking()
                .Where(c => c.CityOrMunicipalityId == cityId)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<Company>)t.Result, ct);

        public Task<IReadOnlyList<Company>> GetByCategoryIdAsync(int categoryId, CancellationToken ct = default)
            => db.Companies
                .AsNoTracking()
                .Where(c => c.CategoryCompanyId == categoryId)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<Company>)t.Result, ct);

        public Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken ct = default)
            => db.Companies
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<Company>)t.Result, ct);

        public async Task AddAsync(Company company, CancellationToken ct = default)
        {
            db.Companies.Add(company);
            await db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Company company, CancellationToken ct = default)
        {
            db.Companies.Update(company);
            await db.SaveChangesAsync(ct);
        }

        public async Task RemoveAsync(Company company, CancellationToken ct = default)
        {
            db.Companies.Remove(company);
            await db.SaveChangesAsync(ct);
        }

        public Task<bool> ExistsIdAsync(string id, CancellationToken ct = default)
            => db.Companies
                .AsNoTracking()
                .AnyAsync(c => c.Id == id, ct);

        public async Task<IReadOnlyList<Company>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
        {
            var query = db.Companies.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(c =>
                    c.Name.ToUpper().Contains(term) ||
                    c.Email!.ToUpper().Contains(term) ||
                    c.Id.ToUpper().Contains(term));
            }

            return await query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
        {
            var query = db.Companies.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(c =>
                    c.Name.ToUpper().Contains(term) ||
                    c.Email!.ToUpper().Contains(term) ||
                    c.Id.ToUpper().Contains(term));
            }

            return query.CountAsync(ct);
        }
    }
}