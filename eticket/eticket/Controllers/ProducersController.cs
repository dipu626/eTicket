using eticket.Data;
using eticket.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eticket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService producerService)
        {
            _service = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }
    }
}
