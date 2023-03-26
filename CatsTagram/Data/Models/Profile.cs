using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Data.Models
{
    using static Validation.User;

    public class Profile
    {
        [MaxLength(MaxNameLength)]
        public string? Name { get; set; }

        public string? PhotoUrl { get; set; }

        public string? WebSite { get; set; }

        [MaxLength(MaxBiographyLength)]
        public string? Biography { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
