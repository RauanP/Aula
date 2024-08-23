using Aula2407.Models;
using Microsoft.EntityFrameworkCore;
namespace Aula2407.Data
{
    public class AulaContext : DbContext
    {
        public AulaContext(DbContextOptions<AulaContext> options) : base(options)
        {

        }
        public DbSet<Aula2407.Models.Cliente> Clientes { get; set; } = default!;

        public DbSet<Aula2407.Models.Produto> Produtos { get; set; } = default!;
    }
}
