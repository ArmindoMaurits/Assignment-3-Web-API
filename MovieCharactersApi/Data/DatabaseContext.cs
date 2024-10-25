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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Characters)
            .WithMany(c => c.Movies)
            .UsingEntity(j => j.ToTable("MovieCharacters"));

        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Franchise)
            .WithMany(f => f.Movies)
            .HasForeignKey(m => m.FranchiseId);

        // After setting up the tables, insert seed data in database.
        SeedData(modelBuilder);
    }

    /// <summary>
    /// Seeds the database with initial data.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void SeedData(ModelBuilder modelBuilder)
    {
        // You are to create some dummy data using seeded data.
        // You are to add at least 3 movies, with some characters and franchises

        var marvelFranchise = new Franchise()
        {
            Id = 1,
            Name = "Marvel Cinematic Universe",
            Description = "A franchise of superhero movies based on characters from Marvel Comics."
        };
        var lotrFranchise = new Franchise()
        {
            Id = 2,
            Name = "The Lord of the Rings",
            Description = "A franchise of fantasy movies based on the books by J.R.R. Tolkien."
        };
        var harryPotterFranchise = new Franchise()
        {
            Id = 3,
            Name = "Harry Potter",
            Description = "A franchise of fantasy movies based on the books by J.K. Rowling."
        };

        modelBuilder.Entity<Franchise>().HasData(
            new List<Franchise>() {
                marvelFranchise,
                lotrFranchise,
                harryPotterFranchise
            });

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
                    FranchiseId = 1,
                    Franchise = marvelFranchise,
                    Characters = new List<Character>()
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
                        }
                    }
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
                    FranchiseId = 1,
                    Franchise = marvelFranchise,
                    Characters = new List<Character>()
                    {
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
                        }
                    }
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
                    FranchiseId = 2,
                    Franchise = lotrFranchise,
                    Characters = new List<Character>()
                    {
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
                    }
                }
            });
    }
}