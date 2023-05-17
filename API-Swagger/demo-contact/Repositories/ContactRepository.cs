using demo_contact.Data;
using demo_contact.Models;
using EFHelper.Repositories;

namespace demo_contact.Repositories
{
    public class ContactRepository : GenericRepository<Contact>
    { 
        public ContactRepository(ApplicationDbContext context) : base(context) { }
    }
}
