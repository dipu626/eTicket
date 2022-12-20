using eticket.Data.Base;
using eticket.Models;

namespace eticket.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task UpdateAsync(int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}
