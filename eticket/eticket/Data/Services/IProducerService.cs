using eticket.Data.Base;
using eticket.Models;

namespace eticket.Data.Services
{
    public interface IProducerService : IEntityBaseRepository<Producer>
    {
        Task<IEnumerable<Producer>> GetAllAsync();
        Task<Producer> GetByIdAsync(int id);
        Task AddAsync(Producer producer);
        Task UpdateAsync(int id, Producer newProducer);
        Task DeleteAsync(int id);
    }
}
