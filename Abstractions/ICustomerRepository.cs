using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Customer?> GetByEmailAsync(string email, CancellationToken ct = default);
        Task<IReadOnlyList<Customer>> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IReadOnlyList<Customer>> GetByCityIdAsync(string cityId, CancellationToken ct = default);
        Task<IReadOnlyList<Customer>> GetByAudienceIdAsync(int audienceId, CancellationToken ct = default);
        Task<IReadOnlyList<Customer>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Customer customer, CancellationToken ct = default);
        Task UpdateAsync(Customer customer, CancellationToken ct = default);
        Task RemoveAsync(Customer customer, CancellationToken ct = default);
        Task<bool> ExistsIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<Customer>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}