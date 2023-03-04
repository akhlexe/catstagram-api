using System.ComponentModel.DataAnnotations;
using static CatsTagram.Data.Validation.Cat

namespace CatsTagram.Features.Cats.Models
{
    public class UpdateCatRequestModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
