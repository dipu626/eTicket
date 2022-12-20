using eticket.Data.Base;
using eticket.Models;

namespace eticket.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemaService(AppDbContext context) : base(context)
        {

        }
    }
}
