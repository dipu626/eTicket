using eticket.Data.Base;
using eticket.Data.ViewModel;
using eticket.Models;
using Microsoft.EntityFrameworkCore;

namespace eticket.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                                        .Include(c => c.Cinema)
                                        .Include(p => p.Producer)
                                        .Include(am => am.Actors_Movies)
                                        .ThenInclude(a => a.Actor)
                                        .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownsVM
            {
                Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(a => a.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(a => a.Name).ToListAsync()
            };
            return response;
        }
    }
}
