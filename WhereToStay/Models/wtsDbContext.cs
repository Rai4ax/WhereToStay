using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhereToStay.Models;

namespace WhereToStay.Models
{
    public class wtsDbContext : IdentityDbContext
    {
        public wtsDbContext(DbContextOptions<wtsDbContext> options) : base(options)
        {

        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<contactMessages> contactMessages {get; set ;}
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HotelImage>()
                .HasKey(hi => hi.Id);
            modelBuilder.Entity<HotelImage>()
                .Property(b => b.Id)
                .UseIdentityColumn()
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true);
            modelBuilder.Entity<HotelImage>()
                .HasOne(hi => hi.Hotel)
                .WithMany(h => h.HotelImages)
                .HasForeignKey(hi => hi.HotelId);
            modelBuilder.Entity<HotelImage>()
                .HasOne(hi => hi.Image)
                .WithMany(i => i.HotelImages)
                .HasForeignKey(hi => hi.ImageId);

            modelBuilder.Entity<HotelRoom>()
                .HasKey(hr => hr.Id);
            modelBuilder.Entity<HotelRoom>()
                .Property(b => b.Id)
                .UseIdentityColumn()
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true);
            modelBuilder.Entity<HotelRoom>()
                .HasOne(hr => hr.Hotel)
                .WithMany(h => h.HotelRooms)
                .HasForeignKey(hr => hr.HotelId);
            modelBuilder.Entity<HotelRoom>()
                .HasOne(hr => hr.Room)
                .WithMany(r => r.HotelRooms)
                .HasForeignKey(hr => hr.RoomId);

           

        }
        public DbSet<WhereToStay.Models.HotelImage> HotelImage { get; set; }
        public DbSet<WhereToStay.Models.HotelRoom> HotelRoom { get; set; }
    }
}
