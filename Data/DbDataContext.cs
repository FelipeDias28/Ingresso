using Ingresso.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ingresso.Data
{
    public class DbDataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<StatusEvent> StatusEvents { get; set; }
        public DbSet<TypeEvent> TypeEvents { get; set; }
        public DbSet<TypeUser> TypeUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseSqlite(connectionString: "DataSource=ticket_event.db;Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasOne(ev => ev.TypeEvent)
                .WithMany(te => te.Events)
                .HasForeignKey(ev => ev.TypeEventId);

            modelBuilder.Entity<Event>()
                .HasOne(ev => ev.StatusEvent)
                .WithMany(se => se.Events)
                .HasForeignKey(ev => ev.StatusEventId);

            modelBuilder.Entity<Event>()
                .HasOne(ev => ev.Address)
                .WithMany(ad => ad.Events)
                .HasForeignKey(ev => ev.AddressId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.TypeUser)
                .WithMany(tu => tu.Users)
                .HasForeignKey(u => u.TypeUserId);


            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(ev => ev.Tickets)
                .HasForeignKey(tp => tp.EventId);

            modelBuilder.Entity<Ticket>()
                .HasOne(tp => tp.User)
                .WithMany(us => us.Tickets)
                .HasForeignKey(tp => tp.UserId);
        }
    }
}
