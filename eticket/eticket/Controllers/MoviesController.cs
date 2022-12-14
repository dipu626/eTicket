using eticket.Data.Services;
using eticket.Data.ViewModel;
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
            await SetDataIntoViewBagAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (ModelState.IsValid == false)
            {
                await SetDataIntoViewBagAsync();
                return View(movie);
            }
            await _moviesService.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Movies/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _moviesService.GetByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies?.Select(n => n.ActorId).ToList(),
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
            };

            await SetDataIntoViewBagAsync();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
            {
                return View("NotFound");
            }
            if (ModelState.IsValid == false)
            {
                await SetDataIntoViewBagAsync();
                return View(movie);
            }
            await _moviesService.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var movies = await _moviesService.GetAllAsync(n => n.Cinema);

            if (movies != null && !string.IsNullOrEmpty(searchString))
            {
                var filterdMovies = movies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View(nameof(Index), filterdMovies);
            }

            return View(nameof(Index), movies);
        }

        #region Helper Methods

        private async Task SetDataIntoViewBagAsync()
        {
            var movieDropdownItems = await _moviesService.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropdownItems.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownItems.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownItems.Actors, "Id", "FullName");
        }

        #endregion
    }
}
