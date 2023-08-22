using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace ClientApi.DBContext
{
    public partial class ClientDbContext : DbContext
    {
        public ClientDbContext()
        {
        }

        public ClientDbContext(DbContextOptions<ClientDbContext> options)
        : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
