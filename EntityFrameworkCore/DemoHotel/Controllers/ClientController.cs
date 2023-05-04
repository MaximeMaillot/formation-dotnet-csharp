using DemoHotel.Data;
using DemoHotel.Models;
using System.Linq.Expressions;

namespace DemoHotel.Controllers
{
    internal class ClientController
    {
        private HotelDbContext _dbContext;

        public ClientController(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Client GetById(int id)
        {
            return _dbContext.Clients.Find(id);
        }

        public List<Client> GetAll(Expression<Func<Client, bool>> predicate)
        {
            return _dbContext.Clients.Where(predicate).ToList();
        }

        public List<Client> GetAll()
        {
            return _dbContext.Clients.ToList();
        }

        public Client Get(Expression<Func<Client, bool>> predicate)
        {
            return _dbContext.Clients.FirstOrDefault(predicate);
        }

        public Client Get(int id)
        {
            return _dbContext.Clients.Find(id);
        }

        public bool Update(Client client)
        {
            var clientFromDb = GetById(client.Id);
            if (clientFromDb == null)
            {
                return false;
            }
            // Moins optimisé car possibilité de update des valeurs non modifiés
            //_dbContext.Clients.Update(client);

            if (clientFromDb.Prenom != client.Prenom)
                clientFromDb.Prenom = client.Prenom;
            if (clientFromDb.Nom != client.Nom)
                clientFromDb.Nom = client.Nom;
            if (clientFromDb.Telephone != client.Telephone)
                clientFromDb.Telephone = client.Telephone;

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var client = GetById(id);
            if (client == null)
            {
                return false;
            }
            _dbContext.Clients.Remove(client);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
