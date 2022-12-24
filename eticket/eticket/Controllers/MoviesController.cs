using eticket.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eticket.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public async Task<IActionResult> Index()
        {
            //var allMovies = _context.Movies.Include(it => it.Cinema).OrderBy(it => it.Name).ToList();
            var allMovies = await _moviesService.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        //Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownItems = await _moviesService.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownItems.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownItems.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownItems.Actors, "Id", "FullName");

            return View();
        }
    }
}
