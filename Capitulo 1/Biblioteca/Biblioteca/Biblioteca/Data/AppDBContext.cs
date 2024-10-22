using Microsoft.EntityFrameworkCore;
using ReservacionesRESTFULL.Bussiness.Entities;

namespace ReservacionesRESTFULL.Data
{
    //Esta clase representa al contexto (Conexión a BD)
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        //Declarando entidades
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Autor>().HasMany(t => t.Books)
                .WithOne(t => t.Autor)
                .HasForeignKey(r => r.AutorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
