using Microsoft.EntityFrameworkCore;
using MovieCharactersApi.Data.Entities;

namespace MovieCharactersApi.Data;

public class DatabaseContext : DbContext
{
    /// <summary>
    /// Database context
    /// </summary>
    /// <param name="options"></param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DatabaseContext()
    {
    }

    public virtual DbSet<Character> Characters { get; set; }
    public virtual DbSet<Franchise> Franchises { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<MovieCharacter> MovieCharacters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Characters)
            .WithMany(c => c.Movies)
            .UsingEntity<MovieCharacter>(
                j => j
                    .HasOne(mc => mc.Character)
                    .WithMany(c => c.MovieCharacters)
                    .HasForeignKey(mc => mc.CharacterId),
                j => j
                    .HasOne(mc => mc.Movie)
                    .WithMany(m => m.MovieCharacters)
                    .HasForeignKey(mc => mc.MovieId)
            );

        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Franchise)
            .WithMany(f => f.Movies)
            .HasForeignKey(m => m.FranchiseId);

        modelBuilder.Entity<MovieCharacter>()
            .HasKey(mc => new { mc.CharacterId, mc.MovieId });

        // After setting up the tables, insert seed data in database.
        SeedData(modelBuilder);
    }

    /// <summary>
    /// Seeds the database with initial data.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Franchise>().HasData(
            new List<Franchise>() {
                new Franchise()
                {
                    Id = 1,
                    Name = "Marvel Cinematic Universe",
                    Description = "A franchise of superhero movies based on characters from Marvel Comics."
                },
                new Franchise()
                {
                    Id = 2,
                    Name = "The Lord of the Rings",
                    Description = "A franchise of fantasy movies based on the books by J.R.R. Tolkien."
                },
                new Franchise()
                {
                    Id = 3,
                    Name = "Harry Potter",
                    Description = "A franchise of fantasy movies based on the books by J.K. Rowling."
                }
            });

        var characters = new List<Character>()
        {
            new Character()
            {
                Id = 1,
                FullName = "Tony Stark",
                Gender = Enums.Gender.Male
            },
            new Character()
            {
                Id = 2,
                FullName = "Pepper Potts",
                Gender = Enums.Gender.Male
            },
            new Character()
            {
                Id = 3,
                FullName = "Thor",
                Gender = Enums.Gender.Male
            },
            new Character()
            {
                Id = 4,
                FullName = "Loki",
                Gender = Enums.Gender.Male
            },
            new Character()
            {
                Id = 5,
                FullName = "Frodo Baggins",
                Gender = Enums.Gender.Male
            },
            new Character()
            {
                Id = 6,
                FullName = "Aragorn",
                Gender = Enums.Gender.Male
            }
        };
        modelBuilder.Entity<Character>().HasData(characters);

        modelBuilder.Entity<Movie>().HasData(
            new List<Movie>() {
                new Movie()
                {
                    Id = 1,
                    Title = "Iron Man",
                    Genre = "Action, Adventure, Sci-Fi",
                    ReleaseYear = 2008,
                    Director = "Jon Favreau",
                    PictureUrl = "https://www.imdb.com/title/tt0371746/mediaviewer/rm4019253760/",
                    TrailerUrl = "https://www.youtube.com/watch?v=8hYlB38asDY",
                    FranchiseId = 1
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Thor",
                    Genre = "Action, Adventure, Fantasy",
                    ReleaseYear = 2011,
                    Director = "Kenneth Branagh",
                    PictureUrl = "https://www.imdb.com/title/tt0800369/mediaviewer/rm4019253760/",
                    TrailerUrl = "https://www.youtube.com/watch?v=JOddp-nlNvQ",
                    FranchiseId = 1
                },
                new Movie()
                {
                    Id = 3,
                    Title = "The Lord of the Rings: The Two Towers",
                    Genre = "Action, Adventure, Drama",
                    ReleaseYear = 2002,
                    Director = "Peter Jackson",
                    PictureUrl = "https://www.imdb.com/title/tt0167261/mediaviewer/rm4019253760/",
                    TrailerUrl = "https://www.youtube.com/watch?v=LbfMDwc4azU",
                    FranchiseId = 2
                }
            });

        modelBuilder.Entity<MovieCharacter>().HasData(new List<MovieCharacter>() 
        { 
            new MovieCharacter() 
            { 
                CharacterId = 1,
                MovieId = 1
            },
            new MovieCharacter()
            {
                CharacterId = 2,
                MovieId = 1
            },
            new MovieCharacter()
            {
                CharacterId = 3,
                MovieId = 2
            },
            new MovieCharacter()
            {
                CharacterId = 4,
                MovieId = 2
            },
            new MovieCharacter()
            {
                CharacterId = 5,
                MovieId = 3
            },
            new MovieCharacter()
            {
                CharacterId = 6,
                MovieId = 3
            }
        });
    }
}