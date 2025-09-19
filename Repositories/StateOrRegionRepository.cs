using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Repositories
{
    public sealed class StateOrRegionRepository(AppDbContext db) : IStateOrRegionRepository
    {
        public Task<StateOrRegion?> GetByCodeAsync(string code, CancellationToken ct = default)
            => db.StateOrRegions
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Code == code, ct);

        public Task<StateOrRegion?> GetByNameAsync(string name, CancellationToken ct = default)
            => db.StateOrRegions
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Name == name, ct);

        public Task<StateOrRegion?> GetByCode3166Async(string code3166, CancellationToken ct = default)
            => db.StateOrRegions
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Code3166 == code3166, ct);

        public Task<IReadOnlyList<StateOrRegion>> GetByCountryIsoCodeAsync(string countryIsoCode, CancellationToken ct = default)
            => db.StateOrRegions
                .AsNoTracking()
                .Where(s => s.Country.IsoCode == countryIsoCode)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<StateOrRegion>)t.Result, ct);

        public Task<IReadOnlyList<StateOrRegion>> GetAllAsync(CancellationToken ct = default)
            => db.StateOrRegions
                .AsNoTracking()
                .OrderBy(s => s.Name)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<StateOrRegion>)t.Result, ct);

        public async Task AddAsync(StateOrRegion stateOrRegion, CancellationToken ct = default)
        {
            db.StateOrRegions.Add(stateOrRegion);
            await db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(StateOrRegion stateOrRegion, CancellationToken ct = default)
        {
            db.StateOrRegions.Update(stateOrRegion);
            await db.SaveChangesAsync(ct);
        }

        public async Task RemoveAsync(StateOrRegion stateOrRegion, CancellationToken ct = default)
        {
            db.StateOrRegions.Remove(stateOrRegion);
            await db.SaveChangesAsync(ct);
        }

        public Task<bool> ExistsCodeAsync(string code, CancellationToken ct = default)
            => db.StateOrRegions
                .AsNoTracking()
                .AnyAsync(s => s.Code == code, ct);

        public async Task<IReadOnlyList<StateOrRegion>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
        {
            var query = db.StateOrRegions.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(s =>
                    s.Name.ToUpper().Contains(term) ||
                    s.Code.ToUpper().Contains(term) ||
                    (s.Code3166 != null && s.Code3166.ToUpper().Contains(term)));
            }

            return await query
                .OrderBy(s => s.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
        {
            var query = db.StateOrRegions.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(s =>
                    s.Name.ToUpper().Contains(term) ||
                    s.Code.ToUpper().Contains(term) ||
                    (s.Code3166 != null && s.Code3166.ToUpper().Contains(term)));
            }

            return query.CountAsync(ct);
        }
    }
}