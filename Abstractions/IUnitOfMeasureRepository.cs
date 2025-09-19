using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IUnitOfMeasureRepository
    {
        Task<UnitOfMeasure?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<UnitOfMeasure>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(UnitOfMeasure unitOfMeasure, CancellationToken ct = default);
        Task UpdateAsync(UnitOfMeasure unitOfMeasure, CancellationToken ct = default);
        Task RemoveAsync(UnitOfMeasure unitOfMeasure, CancellationToken ct = default);

        // 🔎 Personalizados
        Task<UnitOfMeasure?> GetByDescriptionAsync(string description, CancellationToken ct = default);
        Task<bool> ExistsByDescriptionAsync(string description, CancellationToken ct = default);
        Task<IReadOnlyList<CompanyProduct>> GetCompanyProductsByUnitAsync(int unitId, CancellationToken ct = default);

        // 📑 Paginación y conteo
        Task<IReadOnlyList<UnitOfMeasure>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}