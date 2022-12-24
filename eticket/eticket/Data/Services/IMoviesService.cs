using eticket.Data.Base;
using eticket.Data.ViewModel;
using eticket.Models;

namespace eticket.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownsVM> GetNewMovieDropdownValues();

        Task AddNewMovieAsync(NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM movie);
    }
}
