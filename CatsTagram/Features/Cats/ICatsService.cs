using CatsTagram.Features.Cats.Models;

namespace CatsTagram.Features.Cats
{
    public interface ICatsService
    {
        public Task<int> Create(string imageUrl, string description, string userId);

        public Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);

        public Task<CatDetailsServiceModel> Details(int id);

        public Task<bool> Update(int id, string description, string userId);
    }
}
