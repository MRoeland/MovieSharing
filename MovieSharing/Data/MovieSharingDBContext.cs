using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideotheekWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MovieSharing.Models;

namespace MovieSharing.Data
{
    public class MovieSharingDBContext : IdentityDbContext<Lid>
    {
        public DbSet<VideotheekWebApp.Models.Film> Films { get; set; } = default!;

        // any unique string id
        string ADMIN_ID = Guid.NewGuid().ToString("D");
        string User1_ID = Guid.NewGuid().ToString("D");
        string User2_ID = Guid.NewGuid().ToString("D");

        string ADMINROLE_ID = Guid.NewGuid().ToString("D");
        string USERROLE_ID = Guid.NewGuid().ToString("D");

        public MovieSharingDBContext(DbContextOptions<MovieSharingDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())//.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MovieSharingDBContext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.SeedRoles(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedUserRoles(modelBuilder);

            this.SeedFilms(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = ADMINROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            },
            new IdentityRole
            {
                Id = USERROLE_ID,
                Name = "user",
                NormalizedName = "user"
            });
        }
        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<Lid>();
            modelBuilder.Entity<Lid>().HasData(
            new Lid
            {
                Id = ADMIN_ID,
                UserName = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Start123#"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PhoneNumberConfirmed = true,
                Deleted = false,
                Voornaam = "Matthias",
                Achternaam = "Roeland"
            },
            new Lid
            {
                Id = User1_ID,
                UserName = "user1@test.com",
                NormalizedUserName = "USER1@TEST.COM",
                Email = "user1@test.com",
                NormalizedEmail = "USER1@TEST.COM",
                EmailConfirmed = true,//false,
                PasswordHash = hasher.HashPassword(null, "Start123#"),
                SecurityStamp = Guid.NewGuid().ToString("D"),//string.Empty,
                Deleted = false,
                Voornaam = "User1",
                Achternaam = "Test1"
            },
            new Lid
            {
                Id = User2_ID,
                UserName = "user2@test.com",
                NormalizedUserName = "USER2@TEST.COM",
                Email = "user2@test.com",
                NormalizedEmail = "USER2@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Start123#"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Deleted = false,
                Voornaam = "User2",
                Achternaam = "Test2"
            });
        }
        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = ADMINROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = USERROLE_ID,
                UserId = User1_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = USERROLE_ID,
                UserId = User2_ID
            });
        }

        private void SeedFilms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
            new Film
            {
                Id = 1,
                Title = "Top Gun",
                Regiseur = "Tony Scott",
                Acteurs = "Tom Cruise",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 2,
                Title = "Maverick",
                Regiseur = "Joseph Kosinski",
                Acteurs = "Tom Cruise",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            });
        }

        public DbSet<MovieSharing.Models.Reservatie> Reservatie { get; set; } = default!;
    }
}
