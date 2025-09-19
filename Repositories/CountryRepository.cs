using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Repositories;
public sealed class CountryRepository(AppDbContext db) : ICountryRepository
{
    public Task<Country?> GetByIsoCodeAsync(string isoCode, CancellationToken ct = default)
        => db.Countries
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.IsoCode!.ToUpper() == isoCode.ToUpper(), ct);

    public Task<Country?> GetByNameAsync(string name, CancellationToken ct = default)
        => db.Countries
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name!.ToUpper() == name.ToUpper(), ct);

    public async Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Countries
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .ToListAsync(ct);
    }

    public async Task AddAsync(Country country, CancellationToken ct = default)
    {
        db.Countries.Add(country);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Country country, CancellationToken ct = default)
    {
        db.Countries.Update(country);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Country country, CancellationToken ct = default)
    {
        db.Countries.Remove(country);
        await db.SaveChangesAsync(ct);
    }

    public Task<bool> ExistsIsoCodeAsync(string isoCode, CancellationToken ct = default)
        => db.Countries
            .AsNoTracking()
            .AnyAsync(c => c.IsoCode!.ToUpper() == isoCode.ToUpper(), ct);

    public async Task<IReadOnlyList<Country>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Countries.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(c =>
                c.Name!.ToUpper().Contains(term) ||
                c.IsoCode!.ToUpper().Contains(term));
        }

        return await query
            .OrderBy(c => c.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Countries.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(c =>
                c.Name!.ToUpper().Contains(term) ||
                c.IsoCode!.ToUpper().Contains(term));
        }

        return query.CountAsync(ct);
    }
}