using System.ComponentModel.DataAnnotations;

namespace MovieCharactersApi.Data.Entities
{
    public class MovieCharacter
    {
        public required int MovieId { get; set; }

        public required int CharacterId { get; set; }

        public virtual Character Character { get; set; }

        public virtual Movie Movie { get; set; }
    }
}