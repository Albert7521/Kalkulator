using Kalkulator.Models;
using System.Data.Entity;

namespace Kalkulator
{
    public class ClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public Client GetById(int id)
        {
            return _context.Clients.Find(id);
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = GetById(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

    }
}
