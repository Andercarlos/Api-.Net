
using Microsoft.EntityFrameworkCore;
using usuario.Model;

namespace usuario.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {

        }
        // TABELA QUE SERÁ CRIADA
        public DbSet<Usuario> TabelaUsuarios {get;set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder){
                        
            var modificar = modelBuilder.Entity<Usuario>();

            modificar.ToTable("tb_usuario");
            modificar.HasKey(x => x.id);
            modificar.Property(x => x.id).IsRequired().ValueGeneratedOnAdd();
            modificar.Property(x => x.dataNasc).HasColumnName("nascimento").IsRequired();


        }

        
    
    }
}