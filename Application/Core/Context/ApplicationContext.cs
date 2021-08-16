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
        DbSet<Product> IApplicationContext.Products { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }
    }
}
