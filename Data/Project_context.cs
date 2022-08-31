using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDAW1.Entities;
using TestDAW1.Model.Entities;

namespace TestDAW1.Data
{
    public class Project_context: IdentityDbContext<User, Role, int,
         IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
         IdentityRoleClaim<int>, IdentityUserToken<int>>
    {//constructor
        public Project_context()
        {
        }

        public Project_context(DbContextOptions<Project_context> options): base(options) { }
   //ca sa stie sa le mapeze in tabela
        public DbSet<HairStylist> HairStylists { get; set; }
        public DbSet<HairService> HairServices { get; set; }

        public DbSet<PersonalData> Datas{ get; set; }

        public DbSet<BridePackage> BridePackages { get; set; }

        public DbSet<EmployeeBridePackage> EmployeeBridePackages { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one to many cu lambda expresii
            modelBuilder.Entity<HairStylist>()
                .HasMany(hs => hs.HairServices)
                .WithOne(hserv => hserv.HairStylist);

            //one to one cu lambda expresii
            modelBuilder.Entity<HairStylist>()
                .HasOne(hs => hs.PersonalData)
                .WithOne(pd => pd.HairStylist);

            //many to many cu lambda expresii
            modelBuilder.Entity<EmployeeBridePackage>()
                .HasKey(ebp => new { ebp.HairStylistId, ebp.BridePackageId });

            modelBuilder.Entity<EmployeeBridePackage>()
             .HasOne(hs => hs.HairStylist)
             .WithMany(hserv => hserv.EmployeeBridePackages)
             .HasForeignKey(h => h.HairStylistId);

            modelBuilder.Entity<EmployeeBridePackage>()
            .HasOne(hs => hs.BridePackage)
            .WithMany(hserv => hserv.EmployeeBridePackages)
            .HasForeignKey(h => h.BridePackageId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
