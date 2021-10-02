using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Context
{
    public class ApplicationContext : IdentityDbContext, IApplicationContext
    {
        DbSet<User> IApplicationContext.Users { get; set; }
        DbSet<Role> IApplicationContext.Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options) { }
    }
}
