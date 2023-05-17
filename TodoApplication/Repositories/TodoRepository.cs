using TodoApplication.Models;
using TodoApplication.Data;
using EFHelper.Repositories;

namespace TodoApplication.Repositories
{
    public class TodoRepository : GenericRepository<Todo>
    {
        public TodoRepository(ApplicationDbContext context) : base(context) { }
    }
}
