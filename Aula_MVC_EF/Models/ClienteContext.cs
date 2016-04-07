using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aula_MVC_EF.Models
{
    public class ClienteContext : DbContext
    {
        public ClienteContext() : base("ClienteContext")
        {
            Database.SetInitializer<ClienteContext>(null);
        }

        public DbSet<Cliente> clientes { get; set; }
    }
}