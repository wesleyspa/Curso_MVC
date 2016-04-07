using System.Data.Entity;

namespace Aula12_MVC_EF.Models
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
    }
}