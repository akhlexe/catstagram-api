using CatsTagram.Data;
using CatsTagram.Data.Models;

namespace CatsTagram.Features.Cats
{
    public class CatsService : ICatsService
    {
        private readonly CatstagramDbContext data;

        public CatsService(CatstagramDbContext data) => this.data = data;

        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var cat = new Cat
            {
                Description = description,
                UserId = userId,
                ImageUrl = imageUrl,
            };

            data.Add(cat);
            await data.SaveChangesAsync();

            return cat.Id;
        }
    }
}
