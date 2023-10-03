using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using static ClientManagement;

public class ClientManagement
{

    public class Client
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Другие свойства клиента

    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        // Другие DbSet'ы для других сущностей, если нужно
    }
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
