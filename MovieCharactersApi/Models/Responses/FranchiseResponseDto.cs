﻿namespace MovieCharactersApi.Models.Responses;

public class FranchiseResponseDto
{
    /// <summary>
    /// ID of the franchise
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the franchise
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Description of the franchise
    /// </summary>
    public string? Description { get; set; }
}
