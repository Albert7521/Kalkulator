using Kalkulator.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Kalkulator.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        // Другие DbSet'ы для других сущностей, если нужно
    }
    
}
