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

        public DbSet<MovieSharing.Models.Reservatie> Reservatie { get; set; } = default!;

        // any unique string id
        string ADMIN_ID = Guid.NewGuid().ToString("D");
        string User1_ID = Guid.NewGuid().ToString("D");
        string User2_ID = Guid.NewGuid().ToString("D");
        string User3_ID = Guid.NewGuid().ToString("D");
        string User4_ID = Guid.NewGuid().ToString("D");

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
                Voornaam = "Robin",
                Achternaam = "Roeland"
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
            },
            new Lid
            {
                Id = User3_ID,
                UserName = "user3@test.com",
                NormalizedUserName = "USER3@TEST.COM",
                Email = "user3@test.com",
                NormalizedEmail = "USER3@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Start123#"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Deleted = false,
                Voornaam = "User3",
                Achternaam = "Test3"
            },
            new Lid
            {
                Id = User4_ID,
                UserName = "user4@test.com",
                NormalizedUserName = "USER4@TEST.COM",
                Email = "user4@test.com",
                NormalizedEmail = "USER4@TEST.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Start123#"),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Deleted = false,
                Voornaam = "User4",
                Achternaam = "Test4"
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
            },
            new IdentityUserRole<string>
            {
                RoleId = USERROLE_ID,
                UserId = User3_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = USERROLE_ID,
                UserId = User4_ID
            });
        }

        private void SeedFilms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
            new Film
            {
                Id = 1,
                Title = "Top Gun",
                Regisseur = "Tony Scott",
                Acteurs = "Tom Cruise, Tim Robbins, Kelly McGillis",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 2,
                Title = "Maverick",
                Regisseur = "Joseph Kosinski",
                Acteurs = "Tom Cruise, Jennifer Connelly, Miles Teller",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 3,
                Title = "Spy",
                Regisseur = "Paul Feig",
                Acteurs = "Jason Statham, Melissa McCArthy, Rose Byrne, Jude Law",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 4,
                Title = "How to train your dragon",
                Regisseur = "Dean DeBlois, Chris Sanders",
                Acteurs = "Jay Baruchel, Gerard Butler, Christopher Mintz-Plasse, Craig Ferguson",
                Genre = "Animation",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 5,
                Title = "Brave",
                Regisseur = "Mark Andrews, Brenda Chapman, Steve Purcell",
                Acteurs = "Kelly Macdonald, Billy Connolly, Emma Thompson, Craig Ferguson",
                Genre = "Animation",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 6,
                Title = "Fast & Furious",
                Regisseur = "Justin Lin",
                Acteurs = "Vin Diesel, Paul Walker, Michelle Rodriguez",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 7,
                Title = "Barbie",
                Regisseur = "Greta Gerwig",
                Acteurs = "Margot Robbie, Ryan Gosling, Issa Rae",
                Genre = "Fantasy",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 8,
                Title = "Ghost",
                Regisseur = "Jerry Zucker",
                Acteurs = "Patrick Swayze, Demi Moore, Whoopi Goldberg",
                Genre = "Drama",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 9,
                Title = "Ted",
                Regisseur = "Seth MacFarlane",
                Acteurs = "Mark Wahlberg, Mila Kunis, Seth MacFarlane",
                Genre = "Comedy",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 10,
                Title = "Deadpool",
                Regisseur = "Tim Miller",
                Acteurs = "Ryan Reynolds, Morena Baccarin, T.J. Miller",
                Genre = "Comedy",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 11,
                Title = "The wolf of Wallstreet",
                Regisseur = "Martin Scorsese",
                Acteurs = "Leonardo DiCaprio, Jonah Hill, Margot Robbie",
                Genre = "Crime",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 12,
                Title = "Runaway Bride",
                Regisseur = "Garry Marshall",
                Acteurs = "Julia Roberts, Richard Gere, Joan Cusack",
                Genre = "Romance",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 13,
                Title = "Point Break",
                Regisseur = "Kathryn Bigelow",
                Acteurs = "Patrick Swayze, Keanu Reeves, Gary Busey",
                Genre = "Crime",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 14,
                Title = "The Matrix",
                Regisseur = "Lana Wachowski, Lilly Wachowski",
                Acteurs = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss",
                Genre = "Sci-Fi",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 15,
                Title = "Aquaman and the Lost Kingdom",
                Regisseur = "James Wan",
                Acteurs = "Jason Momoa, Patrick Wilson, Yahya Abdul-Mateen II",
                Genre = "Fantasy",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 16,
                Title = "Interstellar",
                Regisseur = "Christopher Nolan",
                Acteurs = "Matthew McConaughey, Anne Hathaway, Jessica Chastain",
                Genre = "Sci-Fi",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 17,
                Title = "Inception",
                Regisseur = "Christopher Nolan",
                Acteurs = "Leonardo DiCaprio, Joseph Gordon-Levitt, Elliot Page",
                Genre = "Sci-Fi",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 18,
                Title = "Star Wars",
                Regisseur = "George Lucas",
                Acteurs = "Mark Hamill, Harrison Ford, Carrie Fisher",
                Genre = "Adventure",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 19,
                Title = "John Wick",
                Regisseur = "Chad Stahelski, David Leitch",
                Acteurs = "Keanu Reeves, Michael Nyqvist, Alfie Allen",
                Genre = "Crime",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 20,
                Title = "The Day After Tomorrow",
                Regisseur = "Roland Emmerich",
                Acteurs = "Dennis Quaid, Jake Gyllenhaal, Emmy Rossum",
                Genre = "Sci-Fi",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 21,
                Title = "Django Unchained",
                Regisseur = "Quentin Tarantino",
                Acteurs = "Jamie Foxx, Christoph Waltz, Leonardo DiCaprio",
                Genre = "Western",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 22,
                Title = "Dances with Wolves",
                Regisseur = "Kevin Costner",
                Acteurs = "Kevin Costner, Mary McDonnel, Graham Greene",
                Genre = "Western",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 23,
                Title = "Mission Impossible",
                Regisseur = "Brian De Palma",
                Acteurs = "Tom Cruise, Jon Voight, Emmanuelle Béart",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 24,
                Title = "The Day the Earth Stood still",
                Regisseur = "Scott Derrickson",
                Acteurs = "Keanu Reeves, Jennifer Connelly, Kathy Bates",
                Genre = "Sci-Fi",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 25,
                Title = "X-Men",
                Regisseur = "Bryan Singer",
                Acteurs = "Patrick Stewart, Hugh Jackman, Ian McKellen",
                Genre = "Sci-Fi",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 26,
                Title = "Notting Hill",
                Regisseur = "Roger Michell",
                Acteurs = "Hugh Grant, Julia Roberts, Richard McCabe",
                Genre = "Romance",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 27,
                Title = "Se7en",
                Regisseur = "David Fincher",
                Acteurs = "Morgan Freeman, Brad Pitt, Kevin Spacey",
                Genre = "Mystery",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 28,
                Title = "American Pie",
                Regisseur = "Paul Weitz, Chris Weitz",
                Acteurs = "Jason Biggs, Chris Klein, Thomas Ian Nicholas",
                Genre = "Comedy",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 29,
                Title = "Schindler's List",
                Regisseur = "Steven Spielberg",
                Acteurs = "Liam Neeson, Ralph Fiennes, Ben Kingsley",
                Genre = "History",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            },
            new Film
            {
                Id = 30,
                Title = "Jack Reacher",
                Regisseur = "Christopher McQuarrie",
                Acteurs = "Tom Cruise, Rosamund Pike, Richard Jenkins",
                Genre = "Action",
                Prijs = 19.99F,
                Aantal = 1,
                Deleted = false
            });
        }
    }
}
