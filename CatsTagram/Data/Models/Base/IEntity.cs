using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Data.Models.Base
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        string? CreatedBy { get; set; }

        DateTime? ModifiedOn { get; set; }

        string? ModifiedBy { get; set; }
    }
}
