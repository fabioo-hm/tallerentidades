using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ITypeProductRepository
    {
        Task<TypeProduct?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<TypeProduct>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(TypeProduct typeProduct, CancellationToken ct = default);
        Task UpdateAsync(TypeProduct typeProduct, CancellationToken ct = default);
        Task RemoveAsync(TypeProduct typeProduct, CancellationToken ct = default);

        // 🔎 Personalizados
        Task<TypeProduct?> GetByDescriptionAsync(string description, CancellationToken ct = default);
        Task<bool> ExistsByDescriptionAsync(string description, CancellationToken ct = default);
        Task<IReadOnlyList<Product>> GetProductsByTypeAsync(int typeProductId, CancellationToken ct = default);

        // 📑 Paginación y conteo
        Task<IReadOnlyList<TypeProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}