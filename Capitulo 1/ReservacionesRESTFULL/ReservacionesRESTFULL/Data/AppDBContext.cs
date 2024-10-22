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
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Reservation>()
                .Property(t => t.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>().HasMany(t => t.Reservations)
                .WithOne(t => t.Room)
                .HasForeignKey(r => r.RoomId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
