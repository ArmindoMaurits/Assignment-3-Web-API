﻿using MovieCharactersApi.Data.Enums;

namespace MovieCharactersApi.Models.Responses
{
    public class CharacterResponseDto
    {
        public int Id { get; set; }

        public required string FullName { get; set; }

        public string? Alias { get; set; }

        public Gender Gender { get; set; } = Gender.Other;

        /// <summary>
        /// URL to a picture of this character, we do not store the image itself.
        /// </summary>
        public string? PictureUrl { get; set; }
    }
}
