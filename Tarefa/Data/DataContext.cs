using Microsoft.EntityFrameworkCore;
using Tarefa.Models;

namespace Tarefa.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TarefaModel> Tarefas { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }

    }

}
