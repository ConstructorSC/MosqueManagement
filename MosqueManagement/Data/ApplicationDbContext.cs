using Microsoft.EntityFrameworkCore;
using MosqueManagement.Models;

namespace MosqueManagement.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<HumanResource> HumanResources { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
