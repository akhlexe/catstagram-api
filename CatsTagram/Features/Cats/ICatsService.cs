using CatsTagram.Features.Cats.Models;

namespace CatsTagram.Features.Cats
{
    public interface ICatsService
    {
        Task<int> CreateAsync(string imageUrl, string description, string userId);

        Task<IEnumerable<CatListingServiceModel>> ByUserAsync(string userId);

        Task<CatDetailsServiceModel> DetailsAsync(int id);

        Task<bool> UpdateAsync(int id, string description, string userId);

        Task<bool> DeleteAsync(int id, string userId);
    }
}
