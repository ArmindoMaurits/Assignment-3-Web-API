using MovieCharactersApi.Data.Enums;

namespace MovieCharactersApi.Models.Requests
{
    public class CharacterCreateRequestDto
    {
        /// <summary>
        /// Full name of the character
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Alias of the character
        /// </summary>
        public string? Alias { get; set; }

        /// <summary>
        /// Gender of the character
        /// </summary>
        public Gender Gender { get; set; } = Gender.Other;

        /// <summary>
        /// URL to a picture of this character, we do not store the image itself.
        /// </summary>
        public string? PictureUrl { get; set; }
    }
}
