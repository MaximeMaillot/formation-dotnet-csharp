using demo_api.Data;
using demo_api.Models;
using EFHelper.Repositories;

namespace demo_api.Repositories
{
    public class ContactRepository : GenericRepository<Contact>
    { 
        public ContactRepository(ApplicationDbContext context) : base(context) { }
    }
}
