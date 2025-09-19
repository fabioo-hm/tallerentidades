using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ITypeIdentificationRepository
    {
        Task<TypeIdentification?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<TypeIdentification>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(TypeIdentification typeIdentification, CancellationToken ct = default);
        Task UpdateAsync(TypeIdentification typeIdentification, CancellationToken ct = default);
        Task RemoveAsync(TypeIdentification typeIdentification, CancellationToken ct = default);

        // 🔎 Personalizados
        Task<TypeIdentification?> GetByDescriptionAsync(string description, CancellationToken ct = default);
        Task<TypeIdentification?> GetBySufixAsync(string sufix, CancellationToken ct = default);
        Task<bool> ExistsByDescriptionAsync(string description, CancellationToken ct = default);
        Task<bool> ExistsBySufixAsync(string sufix, CancellationToken ct = default);
        Task<IReadOnlyList<Company>> GetCompaniesByTypeAsync(int typeId, CancellationToken ct = default);

        // Paginación y conteo
        Task<IReadOnlyList<TypeIdentification>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}