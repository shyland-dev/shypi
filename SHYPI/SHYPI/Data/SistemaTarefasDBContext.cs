using Microsoft.EntityFrameworkCore;
using SHYPI.Data.Map;
using SHYPI.Models;

namespace SHYPI.Data {
    public class SistemaTarefasDBContext : DbContext {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options) {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
