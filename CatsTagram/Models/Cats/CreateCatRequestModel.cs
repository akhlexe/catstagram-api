using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Models.Cats
{
    using static Data.Validation.Cat;

    public class CreateCatRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
