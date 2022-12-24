using eticket.Data;
using eticket.Data.Services;
using eticket.Models;
using Microsoft.AspNetCore.Mvc;

namespace eticket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _producerService.GetAllAsync();
            return View(allProducers);
        }

        //Get: Producers/Delete/Id
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            await _producerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Edit/Id
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _producerService.GetByIdAsync(id);
            if (producer == null )
            {
                return View("NotFound");
            }
            return View(producer);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")]Producer producer)
        {
            await _producerService.UpdateAsync(id, producer);
            return RedirectToAction("Index");
        }

        //Get: Producers/Details/Id
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _producerService.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);  
        }
    }
}
