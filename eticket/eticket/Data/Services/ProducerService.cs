using eticket.Data.Base;
using eticket.Models;

namespace eticket.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context)
        {

        }
    }
}
