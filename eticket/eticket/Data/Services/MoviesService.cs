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

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            if (data.ActorIds != null && data.ActorIds.Count > 0)
            {
                foreach (var actorId in data.ActorIds)
                {
                    var newActorMovie = new Actor_Movie
                    {
                        ActorId = actorId,
                        MovieId = newMovie.Id
                    };
                    await _context.Actors_Movies.AddAsync(newActorMovie);
                }
                await _context.SaveChangesAsync();
            }
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

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            if (data.ActorIds != null && data.ActorIds.Count > 0)
            {
                foreach (var actorId in data.ActorIds)
                {
                    var newActorMovie = new Actor_Movie
                    {
                        ActorId = actorId,
                        MovieId = data.Id
                    };
                    await _context.Actors_Movies.AddAsync(newActorMovie);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
