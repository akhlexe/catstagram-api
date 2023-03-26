using CatsTagram.Data.Models.Base;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();

        public DateTime CreatedOn { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
