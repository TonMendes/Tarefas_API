using Microsoft.EntityFrameworkCore;
using Tarefa_API.Entities;

namespace Tarefa_API.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
                
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
