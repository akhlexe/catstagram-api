using CatsTagram.Features.Cats.Models;

namespace CatsTagram.Features.Cats
{
    public interface ICatsService
    {
        public Task<int> CreateAsync(string imageUrl, string description, string userId);

        public Task<IEnumerable<CatListingServiceModel>> ByUserAsync(string userId);

        public Task<CatDetailsServiceModel> DetailsAsync(int id);

        public Task<bool> UpdateAsync(int id, string description, string userId);

        public Task<bool> DeleteAsync(int id, string userId);
    }
}
