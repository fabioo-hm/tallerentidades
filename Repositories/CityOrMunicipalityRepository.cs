using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Repositories
{
    public sealed class CityOrMunicipalityRepository(AppDbContext db) : ICityOrMunicipalityRepository
    {
        public Task<CityOrMunicipality?> GetByCodeAsync(string code, CancellationToken ct = default)
            => db.CitiesOrMunicipalities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Code == code, ct);

        public Task<CityOrMunicipality?> GetByNameAsync(string name, CancellationToken ct = default)
            => db.CitiesOrMunicipalities
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name, ct);

        public Task<IReadOnlyList<CityOrMunicipality>> GetByStateOrRegionCodeAsync(string stateOrRegionCode, CancellationToken ct = default)
            => db.CitiesOrMunicipalities
                .AsNoTracking()
                .Where(c => c.StateOrRegion.Code == stateOrRegionCode)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<CityOrMunicipality>)t.Result, ct);

        public Task<IReadOnlyList<CityOrMunicipality>> GetAllAsync(CancellationToken ct = default)
            => db.CitiesOrMunicipalities
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync(ct)
                .ContinueWith(t => (IReadOnlyList<CityOrMunicipality>)t.Result, ct);

        public async Task AddAsync(CityOrMunicipality cityOrMunicipality, CancellationToken ct = default)
        {
            db.CitiesOrMunicipalities.Add(cityOrMunicipality);
            await db.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(CityOrMunicipality cityOrMunicipality, CancellationToken ct = default)
        {
            db.CitiesOrMunicipalities.Update(cityOrMunicipality);
            await db.SaveChangesAsync(ct);
        }

        public async Task RemoveAsync(CityOrMunicipality cityOrMunicipality, CancellationToken ct = default)
        {
            db.CitiesOrMunicipalities.Remove(cityOrMunicipality);
            await db.SaveChangesAsync(ct);
        }

        public Task<bool> ExistsCodeAsync(string code, CancellationToken ct = default)
            => db.CitiesOrMunicipalities
                .AsNoTracking()
                .AnyAsync(c => c.Code == code, ct);

        public async Task<IReadOnlyList<CityOrMunicipality>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default)
        {
            var query = db.CitiesOrMunicipalities.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(c =>
                    c.Name.ToUpper().Contains(term) ||
                    c.Code.ToUpper().Contains(term));
            }

            return await query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
        {
            var query = db.CitiesOrMunicipalities.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(c =>
                    c.Name.ToUpper().Contains(term) ||
                    c.Code.ToUpper().Contains(term));
            }

            return query.CountAsync(ct);
        }
    }
}