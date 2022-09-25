using Microsoft.EntityFrameworkCore;
using RpgTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTask.Data.RpgDbContext
{
    public class RpgTaskDbContext : DbContext
    {
        public DbSet<DbArcher> Archers { get; set; }
        public DbSet<DbWarrior> Warriors { get; set; }
        public DbSet<DbMage> Mages { get; set; }
        public DbSet<DbHero> Heroes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.; Database = RpgTask; Trusted_Connection = True;");
        }
    }
}
