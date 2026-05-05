using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Entities;
using OnionApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Persistence.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser, AppRole, int>(options)
    {
        public DbSet<Category>Categories { get; set; }
        
        public DbSet<About>Abouts { get; set; }
        public DbSet<Banner>Banners { get; set; }
        public DbSet<Brand>Brands { get; set; }
        public DbSet<Car>Cars { get; set; }
        public DbSet<CarDescription>CarDescriptions { get; set; }
        public DbSet<CarFeature>CarFeatures { get; set; }
        public DbSet<CarPricing>CarPricings { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<Feature>Features { get; set; }
        public DbSet<FooterAddress>FooterAddresses { get; set; }
        public DbSet<Location>Locations { get; set; }
        public DbSet<Pricing>Pricings { get; set; }
        public DbSet<Service>Services { get; set; }
        public DbSet<SocialMedia>SocialMedias { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickUpLocation)
                .WithMany(y => y.PickUpReservation)
                .HasForeignKey(z => z.PickUpLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(y => y.DropOffReservation)
                .HasForeignKey(z => z.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<AppRole>().HasData(
                 new AppRole { Id = (int)RolesType.Admin, Name = RolesType.Admin.ToString(), NormalizedName = RolesType.Admin.ToString().ToUpperInvariant() },
                 new AppRole { Id = (int)RolesType.Member, Name = RolesType.Member.ToString(), NormalizedName = RolesType.Member.ToString().ToUpperInvariant() },
                 new AppRole { Id = (int)RolesType.Visitor, Name = RolesType.Visitor.ToString(), NormalizedName = RolesType.Visitor.ToString().ToUpperInvariant() },
                 new AppRole { Id = (int)RolesType.Manager, Name = RolesType.Manager.ToString(), NormalizedName = RolesType.Manager.ToString().ToUpperInvariant() }
             );

            base.OnModelCreating(modelBuilder);
        }

    }
}