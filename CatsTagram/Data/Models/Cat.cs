using System.ComponentModel.DataAnnotations;
using static CatsTagram.Data.Validation.Cat;

namespace CatsTagram.Data.Models
{
    public class Cat
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
