using eticket.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticket.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allCinemas = _context.Cinemas.ToList();
            return View(allCinemas);
        }

        public void Filter()
        {
            throw new NotImplementedException();
        }
    }
}
