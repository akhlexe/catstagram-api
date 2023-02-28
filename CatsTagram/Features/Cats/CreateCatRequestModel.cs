using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Features.Cats
{
    using static Data.Validation.Cat;

    public class CreateCatRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
