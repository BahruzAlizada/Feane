using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OK3QKVJ;Database=Feane;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;");
        }

        public DbSet<Slider> Sliders { get;set; }
        public DbSet<Testimonial> Testimonials { get;set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get;set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
