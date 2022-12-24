using eticket.Data.Base;
using eticket.Models;

namespace eticket.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context)
        {

        }
    }
}
