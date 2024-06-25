
using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccesLayer.Concrete
{
    public class Context : IdentityDbContext<User, UserRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-COQ9ECD\\SQLEXPRESS;database=MessageProhectDb;integrated security=true");
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<XXXX> XXXXes { get; set; }

    }
}
