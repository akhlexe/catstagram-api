using CatsTagram.Data;
using CatsTagram.Data.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<CatListingResponseModel>> ByUser(string userId)
        {
            return await this.data
                .Cats
                .Where(c => c.UserId == userId)
                .Select(c => new CatListingResponseModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();
        }
    }
}
