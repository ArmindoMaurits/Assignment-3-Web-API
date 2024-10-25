using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MovieCharactersApi.Data.Enums;

namespace MovieCharactersApi.Data.Entities;

public class Character
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public required string FullName { get; set; }

    public string? Alias { get; set; }

    public Gender Gender { get; set; } = Gender.Other;

    /// <summary>
    /// URL to a picture of this character, we do not store the image itself.
    /// </summary>
    public string? PictureUrl { get; set; }

    /// <summary>
    /// Movies this character has played in.
    /// </summary>
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}