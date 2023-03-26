using System.ComponentModel.DataAnnotations;
using static CatsTagram.Data.Validation.Cat;

namespace CatsTagram.Features.Cats.Models
{
    public class UpdateCatRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
