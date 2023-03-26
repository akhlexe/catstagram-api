using CatsTagram.Features.Cats.Models;
using CatsTagram.Infrastructure.Services;

namespace CatsTagram.Features.Cats
{
    public interface ICatsService
    {
        Task<int> CreateAsync(string imageUrl, string description, string userId);

        Task<IEnumerable<CatListingServiceModel>> ByUserAsync(string userId);

        Task<CatDetailsServiceModel> DetailsAsync(int id);

        Task<Result> UpdateAsync(int id, string description, string userId);

        Task<Result> DeleteAsync(int id, string userId);
    }
}
