using Dominio.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.DataBase
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { }

        public DbSet<Tarefa> ListaTarefas { get; set; }
    }
}