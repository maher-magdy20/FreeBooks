using Domin.Entity;
using infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infarstuructre.Data
{
    public class FreeBookDbContext : IdentityDbContext<ApplicationUser>
    {
        public FreeBookDbContext(DbContextOptions<FreeBookDbContext>options):base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityUser>().ToTable("User", "Identity");
            //builder.Entity<IdentityRole>().ToTable("Roles", "Identity");
            //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Identity");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Identity");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Identity");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Identity");
            //builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Identity");


            builder.Entity<Cateogry>().Property(x=>x.Id).HasDefaultValueSql("(newid())");
            builder.Entity<LogCateogry>().Property(x=>x.Id).HasDefaultValueSql("(newid())");
            builder.Entity<SubCateogry>().Property(x=>x.Id).HasDefaultValueSql("(newid())");
            builder.Entity<LogSubGateogry>().Property(x=>x.Id).HasDefaultValueSql("(newid())");
            builder.Entity<Book>().Property(x=>x.Id).HasDefaultValueSql("(newid())");
            builder.Entity<LogBook>().Property(x=>x.Id).HasDefaultValueSql("(newid())");
        }
        public DbSet<Cateogry> cateogries { get; set; }
        public DbSet<LogCateogry> logCateogries { get; set; }
        public DbSet<SubCateogry> SubCateogries { get; set; }
        public DbSet<LogSubGateogry> logSubGateogries { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }
    }
}
