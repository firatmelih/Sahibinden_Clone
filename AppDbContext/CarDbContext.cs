using Car.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.AppDbContext
{
    public class CarDbContext : IdentityDbContext<IdentityUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) :
            base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
