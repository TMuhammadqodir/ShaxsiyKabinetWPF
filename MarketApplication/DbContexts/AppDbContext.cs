using MarketApplication.Constants;
using MarketApplication.Entities.Categories;
using MarketApplication.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApplication.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }

        public DbSet<Note> notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = DbConstant.CONNECTION_STRING; 

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
