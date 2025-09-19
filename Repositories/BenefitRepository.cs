using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Repositories;

public sealed class BenefitRepository(AppDbContext db) : IBenefitRepository
{
    public Task<Benefit?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Benefits.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, ct);

    public async Task<IReadOnlyList<Benefit>> GetByDescriptionAsync(string description, CancellationToken ct = default)
    {
        return await db.Benefits
            .AsNoTracking()
            .Where(b => b.Description.ToUpper().Contains(description.Trim().ToUpper()))
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<Benefit>> GetByAudienceIdAsync(int audienceId, CancellationToken ct = default)
    {
        return await db.Benefits
            .AsNoTracking()
            .Where(b => b.AudienceId == audienceId)
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<Benefit>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.Benefits
            .AsNoTracking()
            .OrderBy(b => b.Description)
            .ToListAsync(ct);
    }

    public async Task AddAsync(Benefit benefit, CancellationToken ct = default)
    {
        db.Benefits.Add(benefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Benefit benefit, CancellationToken ct = default)
    {
        db.Benefits.Update(benefit);
        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Benefit benefit, CancellationToken ct = default)
    {
        db.Benefits.Remove(benefit);
        await db.SaveChangesAsync(ct);
    }

    public Task<bool> ExistsIdAsync(int id, CancellationToken ct = default)
        => db.Benefits.AsNoTracking().AnyAsync(b => b.Id == id, ct);

    public async Task<IReadOnlyList<Benefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
    {
        var query = db.Benefits.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(b => b.Description.ToUpper().Contains(term));
        }

        return await query
            .OrderBy(b => b.Description)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Benefits.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(b => b.Description.ToUpper().Contains(term));
        }

        return query.CountAsync(ct);
    }
}