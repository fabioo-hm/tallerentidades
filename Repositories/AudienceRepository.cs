using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Repositories;

public sealed class AudienceRepository(AppDbContext db) : IAudienceRepository
{
    public Task<Audience?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Audiences.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, ct);

    public Task<Audience?> GetByDescriptionAsync(string description, CancellationToken ct = default)
        => db.Audiences.AsNoTracking().FirstOrDefaultAsync(a => a.Description == description, ct);

    public async Task<IReadOnlyList<Audience>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Audiences
            .AsNoTracking()
            .OrderBy(a => a.Description)
            .ToListAsync(ct);
    }

    public async Task AddAsync(Audience audience, CancellationToken ct = default)
    {
        db.Audiences.Add(audience);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Audience audience, CancellationToken ct = default)
    {
        db.Audiences.Update(audience);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Audience audience, CancellationToken ct = default)
    {
        db.Audiences.Remove(audience);
        await db.SaveChangesAsync(ct);
    }

    public Task<bool> ExistsIdAsync(int id, CancellationToken ct = default)
        => db.Audiences.AsNoTracking().AnyAsync(a => a.Id == id, ct);

    public async Task<IReadOnlyList<Audience>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Audiences.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(a => a.Description.ToUpper().Contains(term));
        }

        return await query
            .OrderBy(a => a.Description)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Audiences.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(a => a.Description.ToUpper().Contains(term));
        }

        return query.CountAsync(ct);
    }
}