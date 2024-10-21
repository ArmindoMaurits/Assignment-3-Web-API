﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieCharactersApi.Data.Entities;

/// <summary>
/// Franchise of a movie, for example Star Wars, Pokémon,
/// Harry Potter, Marvel Cinematic Universe, etc.
/// </summary>
public class Franchise
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Name of the franchise, for example Star Wars or Pokémon.
    /// </summary>
    public required string Name { get; set; }

    public string? Description { get; set; }
}