using eticket.Data.Services;
using eticket.Models;
using Microsoft.AspNetCore.Mvc;

namespace eticket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemaService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemaService = cinemasService;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _cinemaService.GetAllAsync();
            return View(allCinemas);
        }

        public void Filter()
        {
            throw new NotImplementedException();
        }

        // Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemaService.AddAsync(cinema);
            return RedirectToAction("Index");
        }

        //Get: Cinemas/Details/Id
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        //Get: Cinemas/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _cinemaService.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/Id
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("NotFound");
            }

            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _cinemaService.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            await _cinemaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
