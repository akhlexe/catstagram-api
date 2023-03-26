using CatsTagram.Data.Models;
using System.ComponentModel.DataAnnotations;

using static CatsTagram.Data.Validation.User;

namespace CatsTagram.Features.Profiles.Models
{
    public class UpdateProfileRequestModel
    {
        [EmailAddress]
        public string? Email { get; set; }

        public string? UserName { get; set; }

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
