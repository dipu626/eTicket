using eticket.Data.Base;
using eticket.Models;

namespace eticket.Data.Services
{
    public interface ICinemasService : IEntityBaseRepository<Cinema>
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task UpdateAsync(int id, Cinema newCinema);
        Task DeleteAsync(int id);
    }
}
