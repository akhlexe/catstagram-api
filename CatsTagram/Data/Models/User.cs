using Microsoft.AspNetCore.Identity;

namespace CatsTagram.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();
    }
}
