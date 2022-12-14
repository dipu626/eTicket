using eticket.Data;
using eticket.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eticket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService= actorsService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetAll();
            return View(data);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {

            return View();
        }
    }
}
